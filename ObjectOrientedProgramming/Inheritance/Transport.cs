using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    interface IFuelable
    {
        void Refuel();
    }

    internal class Automobile
    {
        public int TopSpeed { get; set; }
        public string VehicleName { get; set; }

        public Automobile(int topSpeed, string vehicleName)
        {
            TopSpeed = topSpeed;
            VehicleName = vehicleName;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Vehicle Name : {VehicleName}");
            Console.WriteLine($"Top Speed : {TopSpeed} km/h");
        }
    }

    class EVCar : Automobile
    {
        public EVCar(int topSpeed, string vehicleName)
            : base(topSpeed, vehicleName)
        {
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("Electric Car");
            base.DisplayDetails();
        }

        public void Charge()
        {
            Console.WriteLine("Charging the battery.");
        }
    }

    class DieselCar : Automobile, IFuelable
    {
        public DieselCar(int topSpeed, string vehicleName)
            : base(topSpeed, vehicleName)
        {
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("Diesel Car");
            base.DisplayDetails();
        }

        public void Refuel()
        {
            Console.WriteLine("Refueling the vehicle.");
        }
    }

    internal class AutomobileDisplay
    {
        public static void ShowAutomobiles()
        {
            EVCar ev = new EVCar(180, "BYD Seal");
            DieselCar diesel = new DieselCar(220, "Hyundai Verna");

            ev.DisplayDetails();
            ev.Charge();

            Console.WriteLine();

            IFuelable fuelVehicle = diesel;

            diesel.DisplayDetails();
            fuelVehicle.Refuel();
        }
    }
}
