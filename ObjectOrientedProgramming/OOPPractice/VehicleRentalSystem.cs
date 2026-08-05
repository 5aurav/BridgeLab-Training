using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPractice
{
    interface IInsurable
    {
        double CalculateInsurance();
        void GetInsuranceDetails();
    }

    abstract class Vehicle
    {
        private string vehicleNumber;
        private string type;
        private double rentalRate;
        private string insurancePolicyNumber;

        public string VehicleNumber
        {
            get { return vehicleNumber; }
            set { vehicleNumber = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double RentalRate
        {
            get { return rentalRate; }
            set { rentalRate = value; }
        }

        public string InsurancePolicyNumber
        {
            get { return insurancePolicyNumber; }
            private set { insurancePolicyNumber = value; }
        }

        public Vehicle(string vehicleNumber, string type, double rentalRate, string insurancePolicyNumber)
        {
            VehicleNumber = vehicleNumber;
            Type = type;
            RentalRate = rentalRate;
            InsurancePolicyNumber = insurancePolicyNumber;
        }

        public abstract double CalculateRentalCost(int days);

        public void DisplayDetails()
        {
            Console.WriteLine($"Vehicle Number : {VehicleNumber}");
            Console.WriteLine($"Vehicle Type   : {Type}");
            Console.WriteLine($"Rental Rate    : {RentalRate}/day");
        }
    }

    class Car : Vehicle, IInsurable
    {
        public Car(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
            : base(vehicleNumber, "Car", rentalRate, insurancePolicyNumber)
        {
        }

        public override double CalculateRentalCost(int days)
        {
            return RentalRate * days;
        }

        public double CalculateInsurance()
        {
            return 500;
        }

        public void GetInsuranceDetails()
        {
            Console.WriteLine($"Insurance Cost : {CalculateInsurance()}");
        }
    }

    class Bike : Vehicle, IInsurable
    {
        public Bike(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
            : base(vehicleNumber, "Bike", rentalRate, insurancePolicyNumber)
        {
        }

        public override double CalculateRentalCost(int days)
        {
            return RentalRate * days;
        }

        public double CalculateInsurance()
        {
            return 200;
        }

        public void GetInsuranceDetails()
        {
            Console.WriteLine($"Insurance Cost : {CalculateInsurance()}");
        }
    }

    class Truck : Vehicle, IInsurable
    {
        public Truck(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
            : base(vehicleNumber, "Truck", rentalRate, insurancePolicyNumber)
        {
        }

        public override double CalculateRentalCost(int days)
        {
            return RentalRate * days;
        }

        public double CalculateInsurance()
        {
            return 1000;
        }

        public void GetInsuranceDetails()
        {
            Console.WriteLine($"Insurance Cost : {CalculateInsurance()}");
        }
    }

    class VehicleRentalSystem
    {
        public static void Run()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            vehicles.Add(new Car("PB10AB1234", 2000, "CAR101"));
            vehicles.Add(new Bike("PB10CD5678", 700, "BIKE101"));
            vehicles.Add(new Truck("PB10EF9012", 5000, "TRUCK101"));

            int days = 5;

            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.DisplayDetails();

                Console.WriteLine($"Rental Cost ({days} days) : {vehicle.CalculateRentalCost(days)}");

                if (vehicle is IInsurable insurable)
                {
                    insurable.GetInsuranceDetails();
                }

                Console.WriteLine();
            }
        }
    }
}
