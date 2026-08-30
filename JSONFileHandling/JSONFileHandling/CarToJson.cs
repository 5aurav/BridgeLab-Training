using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class CarToJson
    {
        public class Car
        {
            public string Brand { get; set; } = "";
            public string Model { get; set; } = "";
            public int Year { get; set; }
            public double Price { get; set; }
        }

        public void Run()
        {
            Car car = new Car
            {
                Brand = "BMW",
                Model = "5 Series",
                Year = 2026,
                Price = 8500000
            };

            string json = JsonConvert.SerializeObject(
                car,
                Formatting.Indented
            );

            Console.WriteLine("Car JSON:");
            Console.WriteLine(json);
        }
    }
}
