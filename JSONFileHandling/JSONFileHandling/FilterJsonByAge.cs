using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class FilterJsonByAge
    {
        public void Run()
        {
            string json = @"[
    {
        ""name"": ""Rahul"",
        ""age"": 22
    },
    {
        ""name"": ""Aman"",
        ""age"": 31
    },
    {
        ""name"": ""Priya"",
        ""age"": 28
    },
    {
        ""name"": ""Neha"",
        ""age"": 19
    }
]";


            JArray users = JArray.Parse(json);

            var filteredUsers = users
                .Where(user => (int)user["age"] > 25)
                .ToList();

            Console.WriteLine("Users older than 25:");

            foreach (JObject user in filteredUsers)
            {
                Console.WriteLine(
                    $"Name: {user["name"]}, Age: {user["age"]}"
                );
            }
        }
    }
}
