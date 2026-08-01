using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPKeywords
{
    internal class VehicleRegistrationSystem
    {
        public string OwnerName;
        public string VehicleType;
        public readonly string RegistrationNumber;

        static double RegistrationFee = 5000;

        public VehicleRegistrationSystem(string OwnerName, string VehicleType, string RegistrationNumber)
        {
            this.OwnerName = OwnerName;
            this.VehicleType = VehicleType;
            this.RegistrationNumber = RegistrationNumber;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Owner Name          : " + OwnerName);
            Console.WriteLine("Vehicle Type        : " + VehicleType);
            Console.WriteLine("Registration Number : " + RegistrationNumber);
            Console.WriteLine("Registration Fee    : " + RegistrationFee);
        }

        public static void UpdateRegistrationFee(double fee)
        {
            RegistrationFee = fee;
        }

        public static void display()
        {
            VehicleRegistrationSystem vehicle1 =
                new VehicleRegistrationSystem("Saurav", "Car", "PB10AB1234");

            VehicleRegistrationSystem vehicle2 =
                new VehicleRegistrationSystem("Rahul", "Bike", "PB08XY5678");

            Console.WriteLine("Before Updating Registration Fee");

            Console.WriteLine();

            if (vehicle1 is VehicleRegistrationSystem)
            {
                vehicle1.DisplayDetails();
            }

            Console.WriteLine();

            if (vehicle2 is VehicleRegistrationSystem)
            {
                vehicle2.DisplayDetails();
            }

            Console.WriteLine();

            UpdateRegistrationFee(6500);

            Console.WriteLine("After Updating Registration Fee");

            Console.WriteLine();

            vehicle1.DisplayDetails();

            Console.WriteLine();

            vehicle2.DisplayDetails();
        }
    }
}
