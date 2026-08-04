using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Vehicle
    {
        public int MaxSpeed { get; set; }
        public string FuelType { get; set; }

        public Vehicle(int maxSpeed, string fuelType)
        {
            MaxSpeed = maxSpeed;
            FuelType = fuelType;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Maximum Speed : {MaxSpeed} km/h");
            Console.WriteLine($"Fuel Type : {FuelType}");
        }
    }

    class Car : Vehicle
    {
        public int SeatCapacity { get; set; }

        public Car(int maxSpeed, string fuelType, int seatCapacity)
            : base(maxSpeed, fuelType)
        {
            SeatCapacity = seatCapacity;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Car");
            base.DisplayInfo();
            Console.WriteLine($"Seat Capacity : {SeatCapacity}");
        }
    }

    class Truck : Vehicle
    {
        public int PayloadCapacity { get; set; }

        public Truck(int maxSpeed, string fuelType, int payloadCapacity)
            : base(maxSpeed, fuelType)
        {
            PayloadCapacity = payloadCapacity;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Truck");
            base.DisplayInfo();
            Console.WriteLine($"Payload Capacity : {PayloadCapacity} kg");
        }
    }

    class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }

        public Motorcycle(int maxSpeed, string fuelType, bool hasSidecar)
            : base(maxSpeed, fuelType)
        {
            HasSidecar = hasSidecar;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Motorcycle");
            base.DisplayInfo();
            Console.WriteLine($"Has Sidecar : {HasSidecar}");
        }
    }

    internal class VehicleDisplay
    {
        public static void ShowVehicles()
        {
            Vehicle[] vehicles =
            {
                new Car(180, "Petrol", 5),
                new Truck(120, "Diesel", 5000),
                new Motorcycle(160, "Petrol", false)
            };

            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}
