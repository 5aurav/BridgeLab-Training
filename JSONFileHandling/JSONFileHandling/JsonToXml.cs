using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class JsonToXml
    {
        public void Run()
        {
            string json = @"{
    ""student"": {
        ""name"": ""Rahul"",
        ""age"": 16,
        ""city"": ""Ludhiana""
    }
}";

            JObject jsonObject = JObject.Parse(json);

            var xmlDocument =
                JsonConvert.DeserializeXNode(
                    jsonObject.ToString(),
                    "root"
                );

            Console.WriteLine(
                xmlDocument.ToString()
            );
        }
    }
}
