using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Order
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }

        public Order(int orderId, string orderDate)
        {
            OrderId = orderId;
            OrderDate = orderDate;
        }

        public virtual void GetOrderStatus()
        {
            Console.WriteLine($"Order ID : {OrderId}");
            Console.WriteLine($"Order Date : {OrderDate}");
            Console.WriteLine("Status : Order Placed");
        }
    }

    class ShippedOrder : Order
    {
        public string TrackingNumber { get; set; }

        public ShippedOrder(int orderId, string orderDate, string trackingNumber)
            : base(orderId, orderDate)
        {
            TrackingNumber = trackingNumber;
        }

        public override void GetOrderStatus()
        {
            Console.WriteLine($"Order ID : {OrderId}");
            Console.WriteLine($"Order Date : {OrderDate}");
            Console.WriteLine($"Tracking Number : {TrackingNumber}");
            Console.WriteLine("Status : Shipped");
        }
    }

    class DeliveredOrder : ShippedOrder
    {
        public string DeliveryDate { get; set; }

        public DeliveredOrder(int orderId, string orderDate, string trackingNumber, string deliveryDate)
            : base(orderId, orderDate, trackingNumber)
        {
            DeliveryDate = deliveryDate;
        }

        public override void GetOrderStatus()
        {
            Console.WriteLine($"Order ID : {OrderId}");
            Console.WriteLine($"Order Date : {OrderDate}");
            Console.WriteLine($"Tracking Number : {TrackingNumber}");
            Console.WriteLine($"Delivery Date : {DeliveryDate}");
            Console.WriteLine("Status : Delivered");
        }
    }
    internal class OrderDisplay
    {
        public static void ShowOrders()
        {
            Order order1 = new Order(101, "01-08-2026");

            Order order2 = new ShippedOrder(
                102,
                "02-08-2026",
                "TRK12345"
            );

            Order order3 = new DeliveredOrder(
                103,
                "30-07-2026",
                "TRK67890",
                "03-08-2026"
            );

            order1.GetOrderStatus();
            Console.WriteLine();

            order2.GetOrderStatus();
            Console.WriteLine();

            order3.GetOrderStatus();
        }
    }
}
