using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class MergeJsonObjects
    {
        public void Run()
        {
            JObject object1 = JObject.Parse(@"{
    ""name"": ""Rahul"",
    ""age"": 25
}");

            JObject object2 = JObject.Parse(@"{
    ""email"": ""rahul@example.com"",
    ""city"": ""Ludhiana""
}");

            object1.Merge(object2);

            Console.WriteLine("Merged JSON:");
            Console.WriteLine(object1.ToString());
        }
    }
}
