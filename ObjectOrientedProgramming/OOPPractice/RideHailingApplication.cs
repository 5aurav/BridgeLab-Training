using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPractice
{
    interface IGPS
    {
        void GetCurrentLocation();
        void UpdateLocation(string location);
    }

    abstract class RideVehicle
    {
        private int vehicleId;
        private string driverName;
        private double ratePerKm;
        private string currentLocation;

        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        public string DriverName
        {
            get { return driverName; }
            set { driverName = value; }
        }

        public double RatePerKm
        {
            get { return ratePerKm; }
            set { ratePerKm = value; }
        }

        public string CurrentLocation
        {
            get { return currentLocation; }
            protected set { currentLocation = value; }
        }

        public RideVehicle(int vehicleId, string driverName, double ratePerKm)
        {
            VehicleId = vehicleId;
            DriverName = driverName;
            RatePerKm = ratePerKm;
            CurrentLocation = "Not Available";
        }

        public abstract double CalculateFare(double distance);

        public void GetVehicleDetails()
        {
            Console.WriteLine($"Vehicle ID  : {VehicleId}");
            Console.WriteLine($"Driver Name : {DriverName}");
            Console.WriteLine($"Rate / Km   : {RatePerKm}");
        }
    }

    class RideCar : RideVehicle, IGPS
    {
        public RideCar(int vehicleId, string driverName, double ratePerKm)
            : base(vehicleId, driverName, ratePerKm)
        {
        }

        public override double CalculateFare(double distance)
        {
            return distance * RatePerKm;
        }

        public void GetCurrentLocation()
        {
            Console.WriteLine($"Current Location : {CurrentLocation}");
        }

        public void UpdateLocation(string location)
        {
            CurrentLocation = location;
        }
    }

    class RideBike : RideVehicle, IGPS
    {
        public RideBike(int vehicleId, string driverName, double ratePerKm)
            : base(vehicleId, driverName, ratePerKm)
        {
        }

        public override double CalculateFare(double distance)
        {
            return distance * RatePerKm;
        }

        public void GetCurrentLocation()
        {
            Console.WriteLine($"Current Location : {CurrentLocation}");
        }

        public void UpdateLocation(string location)
        {
            CurrentLocation = location;
        }
    }

    class RideAuto : RideVehicle, IGPS
    {
        public RideAuto(int vehicleId, string driverName, double ratePerKm)
            : base(vehicleId, driverName, ratePerKm)
        {
        }

        public override double CalculateFare(double distance)
        {
            return distance * RatePerKm;
        }

        public void GetCurrentLocation()
        {
            Console.WriteLine($"Current Location : {CurrentLocation}");
        }

        public void UpdateLocation(string location)
        {
            CurrentLocation = location;
        }
    }

    class RideHailingApplication
    {
        public static void Run()
        {
            List<RideVehicle> vehicles = new List<RideVehicle>();

            RideCar car = new RideCar(101, "Rahul", 18);
            RideBike bike = new RideBike(102, "Priya", 10);
            RideAuto auto = new RideAuto(103, "Amit", 15);

            car.UpdateLocation("Sector 17");
            bike.UpdateLocation("Railway Station");
            auto.UpdateLocation("Bus Stand");

            vehicles.Add(car);
            vehicles.Add(bike);
            vehicles.Add(auto);

            double distance = 12;

            foreach (RideVehicle vehicle in vehicles)
            {
                vehicle.GetVehicleDetails();

                Console.WriteLine($"Distance : {distance} km");
                Console.WriteLine($"Fare     : {vehicle.CalculateFare(distance)}");

                if (vehicle is IGPS gps)
                {
                    gps.GetCurrentLocation();
                }

                Console.WriteLine();
            }
        }
    }
}
