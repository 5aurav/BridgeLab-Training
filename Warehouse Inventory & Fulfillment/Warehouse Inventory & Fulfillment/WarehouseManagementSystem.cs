using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory___Fulfillment
{
    public class InventoryNode
    {
        public Items data { get; set; }
        public InventoryNode next { get; set; }
        public InventoryNode previous { get; set; }

        public InventoryNode(Items item)
        {
            data = item;
        }
    }

    public class InventoryDoublyLinkedList
    {
        public InventoryNode Head { get; private set; }
        public InventoryNode Tail { get; private set; }

        public int Count { get; private set; }

        public void Add(Items item)
        {
            InventoryNode newNode = new InventoryNode(item);

            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.next = newNode;
                newNode.previous = Tail;
                Tail = newNode;
            }

            Count++;
        }

        public bool Remove(Items item)
        {
            InventoryNode current = Head;

            while (current != null)
            {
                if (current.data == item)
                {
                    if (current.previous != null)
                        current.previous.next = current.next;
                    else
                        Head = current.next;

                    if (current.next != null)
                        current.next.previous = current.previous;
                    else
                        Tail = current.previous;

                    Count--;
                    return true;
                }

                current = current.next;
            }

            return false;
        }
        public List<Items> TraverseForward()
        {
            List<Items> result = new List<Items>();
            InventoryNode current = Head;

            while (current != null)
            {
                result.Add(current.data);
                current = current.next;
            }

            return result;
        }

        public List<Items> TraverseBackward()
        {
            List<Items> result = new List<Items>();
            InventoryNode current = Tail;

            while (current != null)
            {
                result.Add(current.data);
                current = current.previous;
            }

            return result;
        }
    }

    public class RobotRouteNode
    {
        public string Location { get; set; }
        public RobotRouteNode Next { get; set; }

        public RobotRouteNode(string location)
        {
            Location = location;
        }
    }
    public class RobotRoute
    {
        public RobotRouteNode Head { get; private set; }

        public void AddLocation(string location)
        {
            RobotRouteNode newNode = new RobotRouteNode(location);

            if (Head == null)
            {
                Head = newNode;
                newNode.Next = Head;
                return;
            }

            RobotRouteNode current = Head;

            while (current.Next != Head)
            {
                current = current.Next;
            }

            current.Next = newNode;
            newNode.Next = Head;
        }

        public List<string> GetRoute(int numberOfStops)
        {
            List<string> result = new List<string>();

            if (Head == null || numberOfStops <= 0)
                return result;

            RobotRouteNode current = Head;

            for (int i = 0; i < numberOfStops; i++)
            {
                result.Add(current.Location);
                current = current.Next;
            }

            return result;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }
    }
    public class DamagedItemNode
    {
        public Items Data { get; set; }
        public string Reason { get; set; }
        public DamagedItemNode Next { get; set; }

        public DamagedItemNode(Items item, string reason)
        {
            Data = item;
            Reason = reason;
        }
    }

    public class DamagedReturnedList
    {
        public DamagedItemNode Head { get; private set; }
        public DamagedItemNode Tail { get; private set; }

        public void Add(Items item, string reason)
        {
            DamagedItemNode newNode =
                new DamagedItemNode(item, reason);

            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public List<DamagedItemNode> GetAll()
        {
            List<DamagedItemNode> result =
                new List<DamagedItemNode>();

            DamagedItemNode current = Head;

            while (current != null)
            {
                result.Add(current);
                current = current.Next;
            }

            return result;
        }
    }

    public class FulfillmentRequest
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }

        public FulfillmentRequest(string sku, int quantity)
        {
            SKU = sku;
            Quantity = quantity;
        }
    }

    public class RestockOperation
    {
        public string SKU { get; set; }
        public int QuantityAdded { get; set; }

        public RestockOperation(string sku, int quantityAdded)
        {
            SKU = sku;
            QuantityAdded = quantityAdded;
        }
    }


    public class WarehouseManagementSystem
    {
        private int nextItemId = 1;
        private int nextShelfLevel = 1;
        private InventoryDoublyLinkedList inventory =
            new InventoryDoublyLinkedList();
        private Stack<RestockOperation> restockStack =
            new Stack<RestockOperation>();
        private Queue<FulfillmentRequest> fulfillmentQueue =
            new Queue<FulfillmentRequest>();
        private RobotRoute robotRoute =
            new RobotRoute();
        private DamagedReturnedList damagedReturned =
            new DamagedReturnedList();
        private Dictionary<string, Items> lookup =
            new Dictionary<string, Items>();
        public Items AddItem(
            string name,
            string sku,
            int quantity,
            int expiryDays = 100)
        {

            Items product = new Items(
                nextItemId++,
                name,
                sku,
                nextShelfLevel++,
                quantity,
                expiryDays);

            inventory.Add(product);
            lookup.Add(sku, product);

            return product;
        }

        public string GetShelfAndStock(string sku)
        {
            Items item = FindBySKU(sku);

            if (item == null)
            {
                return "SKU not found";
            }

            return $"SKU: {item.SKU} | Shelf: {item.ShelfLevel} | Stock: {item.Quantity}";
        }
        public Items FindBySKU(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                return null;
            }

            if (lookup.TryGetValue(sku, out Items item))
            {
                return item;
            }

            return null;
        }

        public Items GetInventoryBySKU(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                return null;
            }

            lookup.TryGetValue(sku, out Items item);

            return item;
        }

        public int GetStock(string sku)
        {
            Items item = FindBySKU(sku);

            if (item == null)
            {
                return -1;
            }

            return item.Quantity;
        }

        public bool Restock(string sku, int quantity)
        {
            Items item = FindBySKU(sku);

            if (item == null)
            {
                return false;
            }

            if (quantity <= 0)
            {
                return false;
            }

            item.Quantity += quantity;

            restockStack.Push(
                new RestockOperation(sku, quantity)
            );

            return true;
        }

        public bool UndoRestock()
        {
            if (restockStack.Count == 0)
            {
                return false;
            }

            RestockOperation operation = restockStack.Pop();

            Items item = FindBySKU(operation.SKU);

            if (item == null)
            {
                return false;
            }

            if (item.Quantity < operation.QuantityAdded)
            {
                return false;
            }

            item.Quantity -= operation.QuantityAdded;

            return true;
        }

        public bool PlaceOrder(string sku, int quantity)
        {
            Items item = FindBySKU(sku);

            if (item == null)
            {
                return false;
            }

            if (quantity <= 0)
            {
                return false;
            }

            if (item.Quantity == 0)
            {
                return false;
            }

            if (quantity > item.Quantity)
            {
                return false;
            }

            fulfillmentQueue.Enqueue(
                new FulfillmentRequest(sku, quantity)
            );

            return true;
        }

        public bool ProcessNextOrder()
        {
            if (fulfillmentQueue.Count == 0)
            {
                return false;
            }

            FulfillmentRequest fulfillment =
                fulfillmentQueue.Dequeue();

            Items item = FindBySKU(fulfillment.SKU);

            if (item == null)
            {
                return false;
            }

            if (item.Quantity == 0)
            {
                return false;
            }

            if (fulfillment.Quantity > item.Quantity)
            {
                return false;
            }

            item.Quantity -= fulfillment.Quantity;

            return true;
        }

        public void AddRobotLocation(string location)
        {
            robotRoute.AddLocation(location);
        }

        public List<string> GetRobotPatrol(int numberOfStops)
        {
            return robotRoute.GetRoute(numberOfStops);
        }

        public bool AddDamagedItem(string sku, string reason)
        {
            Items item = FindBySKU(sku);

            if (item == null)
                return false;

            damagedReturned.Add(item, reason);

            return true;
        }


        public List<DamagedItemNode> GetDamagedItems()
        {
            return damagedReturned.GetAll();
        }

        //    public void SortInventory()
        //    {
        //        List<Items> ItemsList = new List<Items>(inventory);
        //        for(int i = 0; i < ItemsList.Count-1; i++)
        //        {
        //            int minIndex = i;
        //            for(int j = i+1; j < ItemsList.Count; j++)
        //            {
        //                if (ItemsList[j].expiryDays < ItemsList[minIndex].expiryDays)
        //                {
        //                    minIndex = j;
        //                    j--;
        //                }
        //            }
        //            (ItemsList[i], ItemsList[minIndex]) = (ItemsList[minIndex], ItemsList[i]);
        //        }
        //    }

        //    public Items BinarySearchSKU(string sku)
        //    {


        //        int low = 0;
        //        int high = sorted.Count - 1;

        //        while (low <= high)
        //        {
        //            int mid = low + (high - low) / 2;

        //            int comparison =
        //                string.Compare(
        //                    sorted[mid].SKU,
        //                    sku,
        //                    StringComparison.Ordinal);

        //            if (comparison == 0)
        //                return sorted[mid];

        //            if (comparison < 0)
        //                low = mid + 1;
        //            else
        //                high = mid - 1;
        //        }

        //        return null;
        //    }
    }
}
