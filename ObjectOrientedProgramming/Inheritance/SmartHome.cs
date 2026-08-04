using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Device
    {
        public int DeviceId { get; set; }
        public string Status { get; set; }

        public Device(int deviceId, string status)
        {
            DeviceId = deviceId;
            Status = status;
        }

        public virtual void DisplayStatus()
        {
            Console.WriteLine($"Device ID : {DeviceId}");
            Console.WriteLine($"Status : {Status}");
        }
    }

    class Thermostat : Device
    {
        public int TemperatureSetting { get; set; }

        public Thermostat(int deviceId, string status, int temperatureSetting)
            : base(deviceId, status)
        {
            TemperatureSetting = temperatureSetting;
        }

        public override void DisplayStatus()
        {
            Console.WriteLine("Thermostat");
            base.DisplayStatus();
            Console.WriteLine($"Temperature : {TemperatureSetting}°C");
        }
    }
    internal class DeviceDisplay
    {
        public static void ShowDevice()
        {
            Device thermostat = new Thermostat(
                101,
                "Active",
                24
            );

            thermostat.DisplayStatus();
        }
    }

}
