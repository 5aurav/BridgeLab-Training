using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstanceAndClassMembers
{
    internal class VehicleRegistration
    {
        string ownerName;
        string vehicleType;

        static double registrationFee = 5000;

        public VehicleRegistration(string ownerName, string vehicleType)
        {
            this.ownerName = ownerName;
            this.vehicleType = vehicleType;
        }

        public void DisplayVehicleDetails()
        {
            Console.WriteLine("Owner Name       : " + ownerName);
            Console.WriteLine("Vehicle Type     : " + vehicleType);
            Console.WriteLine("Registration Fee : " + registrationFee);
        }

        public static void UpdateRegistrationFee(double fee)
        {
            registrationFee = fee;
        }

        public static void display()
        {
            VehicleRegistration v1 = new VehicleRegistration("Saurav", "Car");
            VehicleRegistration v2 = new VehicleRegistration("Rahul", "Bike");

            Console.WriteLine("Before Updating Registration Fee");

            Console.WriteLine();

            v1.DisplayVehicleDetails();

            Console.WriteLine();

            v2.DisplayVehicleDetails();

            Console.WriteLine();

            UpdateRegistrationFee(6500);

            Console.WriteLine("After Updating Registration Fee");

            Console.WriteLine();

            v1.DisplayVehicleDetails();

            Console.WriteLine();

            v2.DisplayVehicleDetails();
        }
    }
}
