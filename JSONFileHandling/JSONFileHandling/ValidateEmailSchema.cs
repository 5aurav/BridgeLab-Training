using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class ValidateEmailSchema
    {
        public void Run()
        {
            string json = @"{
    ""name"": ""Rahul"",
    ""email"": ""rahul@example.com""
}";

            string schemaJson = @"{
    ""type"": ""object"",
    ""required"": [
        ""name"",
        ""email""
    ],
    ""properties"": {
        ""name"": {
            ""type"": ""string""
        },
        ""email"": {
            ""type"": ""string"",
            ""format"": ""email""
        }
    }
}";

            JObject data = JObject.Parse(json);

            JSchema schema = JSchema.Parse(schemaJson);

            bool valid = data.IsValid(
                schema,
                out IList<string> errors
            );

            Console.WriteLine("Email is valid: " + valid);

            foreach (string error in errors)
            {
                Console.WriteLine("Error: " + error);
            }
        }
    }
}
