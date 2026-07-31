using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class CarRental
    {
        string customerName;
        string carModel;
        int rentalDays;
        double costPerDay;

        public CarRental()
        {
            customerName = "Unknown";
            carModel = "Hatchback";
            rentalDays = 1;
            costPerDay = 1500;
        }

        public CarRental(string customerName, string carModel, int rentalDays, double costPerDay)
        {
            this.customerName = customerName;
            this.carModel = carModel;
            this.rentalDays = rentalDays;
            this.costPerDay = costPerDay;
        }

        public double CalculateTotalCost()
        {
            return rentalDays * costPerDay;
        }

        public void Display()
        {
            Console.WriteLine("Customer Name : " + customerName);
            Console.WriteLine("Car Model     : " + carModel);
            Console.WriteLine("Rental Days   : " + rentalDays);
            Console.WriteLine("Cost Per Day  : " + costPerDay);
            Console.WriteLine("Total Cost    : " + CalculateTotalCost());
        }

        public static void display()
        {
            CarRental c1 = new CarRental();
            CarRental c2 = new CarRental("Saurav", "Hyundai Creta", 5, 2500);

            Console.WriteLine("Default Constructor");
            c1.Display();

            Console.WriteLine();

            Console.WriteLine("Parameterized Constructor");
            c2.Display();
        }
    }
}
