/* Creating Schema */
CREATE SCHEMA inventory;
CREATE SCHEMA shipment;

/* Creating Tables */
CREATE TABLE inventory.warehouses (
    warehouse_id SERIAL PRIMARY KEY,
    warehouse_name VARCHAR(100) NOT NULL,
    location VARCHAR(100) NOT NULL
);

CREATE TABLE inventory.products (
    product_id SERIAL PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    price NUMERIC(10,2) NOT NULL CHECK (price >= 0),
    reorder_level INT NOT NULL CHECK (reorder_level >= 0)
);

CREATE TABLE inventory.suppliers (
    supplier_id SERIAL PRIMARY KEY,
    supplier_name VARCHAR(100) NOT NULL
);

CREATE TABLE inventory.inventory (
    warehouse_id INT REFERENCES inventory.warehouses(warehouse_id),
    product_id INT REFERENCES inventory.products(product_id),
    stock_quantity INT NOT NULL CHECK (stock_quantity >= 0),
    PRIMARY KEY (warehouse_id, product_id)
);

CREATE TABLE inventory.purchases (
    purchase_id SERIAL PRIMARY KEY,
    supplier_id INT REFERENCES inventory.suppliers(supplier_id),
    product_id INT REFERENCES inventory.products(product_id),
    warehouse_id INT REFERENCES inventory.warehouses(warehouse_id),
    quantity INT NOT NULL CHECK (quantity > 0),
    purchase_date DATE DEFAULT CURRENT_DATE
);

CREATE TABLE shipment.shipments (
    shipment_id SERIAL PRIMARY KEY,
    product_id INT REFERENCES inventory.products(product_id),
    warehouse_id INT REFERENCES inventory.warehouses(warehouse_id),
    quantity INT NOT NULL CHECK (quantity > 0),
    shipment_date DATE DEFAULT CURRENT_DATE
);

/* Inserting data in the tables */
INSERT INTO inventory.warehouses
(warehouse_name, location)
VALUES
('Warehouse-1','Chandigarh'),
('Warehouse-2','Mohali'),
('Warehouse-3','Rajpura');

INSERT INTO inventory.products
(product_name, price, reorder_level)
VALUES
('Laptop',55000,10),
('Mobile Phone', 25000, 20),
('Headphones',1500, 25),
('Monitor',12000,15),
('Mouse',800,30);

INSERT INTO inventory.suppliers
(supplier_name)
VALUES
('Tech supplier'),
('ABC Electronics'),
('Gada Electronics');

INSERT INTO inventory.inventory
(warehouse_id,product_id,stock_quantity)
VALUES
(1,1,25),
(1,2,15),
(1,3,50),
(1,4,5),
(1,5,30),
(2,1,8),
(2,2,40),
(2,3,20),
(2,4,25),
(2,5,10),
(3,1,15),
(3,2,10),
(3,3,60),
(3,4,20),
(3,5,5);

/* Warehouse inventory reports */
SELECT
	w.warehouse_name,
	p.product_name,
	i.stock_quantity,
	p.price,
	i.stock_quantity*p.price AS inventory_value
FROM inventory.inventory i
JOIN inventory.warehouses w
	ON i.warehouse_id=w.warehouse_id
JOIN inventory.products p
	ON i.product_id=p.product_id
ORDER BY w.warehouse_name,p.product_name;

/* Warehouse with low stock */
WITH low_stock AS (
	SELECT 
		i.warehouse_id,
		i.product_id,
		i.stock_quantity
	FROM inventory.inventory i
	JOIN inventory.products p
		ON i.product_id=p.product_id
	WHERE i.stock_quantity<p.reorder_level
)
SELECT 
	w.warehouse_name,
	p.product_name,
	low_stock.stock_quantity,
	p.reorder_level
FROM low_stock
JOIN inventory.warehouses w
	ON low_Stock.warehouse_id=w.warehouse_id
JOIN inventory.products p
	ON low_stock.product_id=p.product_id;

/* Products with stock below average */
SELECT
	p.product_name,
	i.stock_quantity
FROM inventory.inventory i
JOIN inventory.products p
	ON i.product_id=p.product_id
WHERE i.stock_quantity < (
	SELECT AVG(i2.stock_quantity)
	FROM inventory.inventory i2
	WHERE i2.product_id=i.product_id
);

/* Reorder candidates */
CREATE TEMP TABLE reorder_candidates
AS
SELECT
	i.warehouse_id,
	i.product_id,
	i.stock_quantity,
	p.reorder_level,
	p.reorder_level-i.stock_quantity AS reorder_quantity
FROM inventory.inventory i
JOIN inventory.products p
	ON i.product_id=p.product_id
WHERE i.stock_quantity<p.reorder_level;

SELECT * FROM reorder_candidates;

/* Warehouse stock status */
CREATE VIEW inventory.warehouse_stock_status AS
SELECT 
	w.warehouse_name,
	p.product_name,
	i.stock_quantity,
	p.reorder_level,
	CASE
		WHEN i.stock_quantity = 0 THEN 'OUT OF STOCK'
		WHEN i.stock_quantity < p.reorder_level THEN 'LOW STOCK'
		ELSE 'AVAILABLE'
	END AS stock_status
FROM inventory.inventory i
JOIN inventory.warehouses w
	ON i.warehouse_id = w.warehouse_id
JOIN inventory.products p
 ON i.product_id = p.product_id;

SELECT * FROM inventory.warehouse_stock_status;

/* Calculate total inventory value */
CREATE OR REPLACE FUNCTION inventory.total_inventory_value()
RETURNS NUMERIC
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN (
        SELECT COALESCE(
            SUM(i.stock_quantity * p.price),
            0
        )
        FROM inventory.inventory AS i
        JOIN inventory.products AS p
            ON i.product_id = p.product_id
    );
END;
$$;

SELECT inventory.total_inventory_value();

/* Transfer stock between warehouses */
CREATE OR REPLACE PROCEDURE inventory.transfer_stock(
    p_product_id INT,
    p_from_warehouse INT,
    p_to_warehouse INT,
    p_quantity INT
)
LANGUAGE plpgsql
AS $$
BEGIN

    IF p_quantity <= 0 THEN
        RAISE EXCEPTION 'quantity must be positive';
    END IF;

    UPDATE inventory.inventory
    SET stock_quantity = stock_quantity - p_quantity
    WHERE warehouse_id = p_from_warehouse
      AND product_id = p_product_id
      AND stock_quantity >= p_quantity;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Insufficient stock or source inventory not found';
    END IF;

    UPDATE inventory.inventory
    SET stock_quantity = stock_quantity + p_quantity
    WHERE warehouse_id = p_to_warehouse
      AND product_id = p_product_id;

    IF NOT FOUND THEN
        INSERT INTO inventory.inventory
        (warehouse_id, product_id, stock_quantity)
        VALUES
        (p_to_warehouse, p_product_id, p_quantity);
    END IF;

END;
$$;
CALL inventory.transfer_stock(1, 1, 2, 5);

/* Preventing negative inventory */
CREATE OR REPLACE FUNCTION inventory.prevent_negative_stock()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
BEGIN
    IF NEW.stock_quantity < 0 THEN
        RAISE EXCEPTION 'Stock quantity cannot be negative';
    END IF;

    RETURN NEW;
END;
$$;
CREATE TRIGGER check_negative_stock
BEFORE INSERT OR UPDATE
ON inventory.inventory
FOR EACH ROW
EXECUTE FUNCTION inventory.prevent_negative_stock();

UPDATE inventory.inventory
SET stock_quantity = -10
WHERE warehouse_id = 1
AND product_id = 1;

/* Process reorder candidates */
CREATE OR REPLACE PROCEDURE inventory.process_reorders()
LANGUAGE plpgsql
AS $$
DECLARE
    r RECORD;

    reorder_cursor CURSOR FOR
        SELECT warehouse_id, product_id, reorder_quantity
        FROM reorder_candidates;
BEGIN

    OPEN reorder_cursor;

    LOOP
        FETCH reorder_cursor INTO r;

        EXIT WHEN NOT FOUND;

        RAISE NOTICE
            'Warehouse %, Product %, Reorder % units',
            r.warehouse_id,
            r.product_id,
            r.reorder_quantity;
    END LOOP;

    CLOSE reorder_cursor;

END;
$$;
CALL inventory.process_reorders();

/* Indexes */
CREATE INDEX idx_inventory_warehouse
ON inventory.inventory(warehouse_id);

CREATE INDEX idx_inventory_product
ON inventory.inventory(product_id);

CREATE INDEX idx_inventory_stock
ON inventory.inventory(stock_quantity);

/* Configure access permissions */
CREATE ROLE warehouse_user LOGIN PASSWORD 'Warehouse@2005';
GRANT USAGE ON SCHEMA inventory TO warehouse_user;
GRANT USAGE ON SCHEMA shipment TO warehouse_user;
GRANT SELECT, INSERT, UPDATE
ON ALL TABLES IN SCHEMA inventory
TO warehouse_user;

GRANT SELECT, INSERT, UPDATE
ON ALL TABLES IN SCHEMA shipment
TO warehouse_user;