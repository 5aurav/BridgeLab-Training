using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory___Fulfillment
{
    public class Items
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string SKU { get; set; }
        public int ShelfLevel { get; set; }
        public int Quantity { get; set; }
        public int ExpiryDays { get; set; }

        public Items(int id, string name, string sku, int shelfLevel,
                     int quantity, int expiryDays)
        {
            ItemId = id;
            ItemName = name;
            SKU = sku;
            ShelfLevel = shelfLevel;
            Quantity = quantity;
            ExpiryDays = expiryDays;
        }

        public override string ToString()
        {
            return $"ID: {ItemId} | Name: {ItemName} | SKU: {SKU} | " +
                   $"Shelf: {ShelfLevel} | Quantity: {Quantity} | " +
                   $"Expiry: {ExpiryDays} days";
        }
    }
}