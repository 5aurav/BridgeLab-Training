using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class ReadJsonKeysValues
    {
        public void Run()
        {
            string json = @"{
    ""name"": ""Rahul"",
    ""age"": 25,
    ""city"": ""Ludhiana"",
    ""email"": ""rahul@example.com""
}";

            JObject obj = JObject.Parse(json);

            foreach (var property in obj.Properties())
            {
                Console.WriteLine(
                    $"Key: {property.Name} | Value: {property.Value}"
                );
            }
        }
    }
}
