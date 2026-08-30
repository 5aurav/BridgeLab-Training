using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class FilterUsersOlderThan25
    {
        public void Run()
        {
            string json = @"[
    {
        ""id"": 1,
        ""name"": ""Aman"",
        ""age"": 21
    },
    {
        ""id"": 2,
        ""name"": ""Rohan"",
        ""age"": 30
    },
    {
        ""id"": 3,
        ""name"": ""Priya"",
        ""age"": 27
    },
    {
        ""id"": 4,
        ""name"": ""Neha"",
        ""age"": 24
    }
]";

            JArray users = JArray.Parse(json);

            foreach (JObject user in users)
            {
                int age = (int)user["age"];

                if (age > 25)
                {
                    Console.WriteLine(
                        $"ID: {user["id"]}, " +
                        $"Name: {user["name"]}, " +
                        $"Age: {user["age"]}"
                    );
                }
            }
        }
    }
}
