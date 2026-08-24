using Warehouse_Inventory___Fulfillment;

namespace InventoryTesting
{
    public class Tests

    {
        WarehouseManagementSystem Warehouse;

        [SetUp]
        public void Setup()
        {
            Warehouse = new WarehouseManagementSystem();   
        }

        [Test]
        public void CheckWhetherSKUisPresent()
        {
            Warehouse.AddItem("Mobile Phone", "1250", 50, 200);
            Assert.That(Warehouse.FindBySKU("1250"), Is.Not.EqualTo(null));
        }

        [Test]
        public void CheckWhetherSKUisAbsent()
        {
            Warehouse.AddItem("Mobile Phone", "1250", 50, 200);
            Assert.That(Warehouse.FindBySKU("1251"), Is.EqualTo(null));
        }
    }
}
