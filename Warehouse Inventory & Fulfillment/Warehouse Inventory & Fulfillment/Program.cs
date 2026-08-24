using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory___Fulfillment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WarehouseManagementSystem WareHouse = new WarehouseManagementSystem();

            WareHouse.AddItem("Mobile Phone", "140", 40, 100);
            WareHouse.AddItem("TV", "210", 10, 150);
            WareHouse.AddItem("Cycle", "350", 50, 200);
            WareHouse.AddItem("House", "1250", 250, 140);
            WareHouse.AddItem("Shoes", "45", 5, 10);

            if (WareHouse.FindBySKU("140") != null)
            {
                Items item = WareHouse.FindBySKU("45");
                Console.WriteLine(item.ToString());
            }
            
        }
    }
}
