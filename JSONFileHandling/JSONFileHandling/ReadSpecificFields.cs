using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class ReadSpecificFields
    {
        public void Run()
        {
            string json = @"[
    {
        ""name"": ""Rahul"",
        ""email"": ""rahul@example.com"",
        ""age"": 25
    },
    {
        ""name"": ""Priya"",
        ""email"": ""priya@example.com"",
        ""age"": 28
    }
]";

            JArray users = JArray.Parse(json);

            foreach (JObject user in users)
            {
                Console.WriteLine("Name: " + user["name"]);
                Console.WriteLine("Email: " + user["email"]);
                Console.WriteLine();
            }
        }
    }
}
