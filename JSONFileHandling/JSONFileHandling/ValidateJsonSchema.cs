using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class ValidateJsonSchema
    {
        public void Run()
        {
            string json = @"{
    ""name"": ""Rahul"",
    ""age"": 25,
    ""email"": ""rahul@example.com""
}";

            string schemaJson = @"{
    ""type"": ""object"",
    ""required"": [
        ""name"",
        ""age"",
        ""email""
    ],
    ""properties"": {
        ""name"": {
            ""type"": ""string""
        },
        ""age"": {
            ""type"": ""integer"",
            ""minimum"": 0
        },
        ""email"": {
            ""type"": ""string""
        }
    }
}";

            JObject data = JObject.Parse(json);

            JSchema schema = JSchema.Parse(schemaJson);

            bool valid = data.IsValid(
                schema,
                out IList<string> errors
            );

            Console.WriteLine("Valid JSON: " + valid);

            foreach (string error in errors)
            {
                Console.WriteLine("Error: " + error);
            }
        }
    }
}
