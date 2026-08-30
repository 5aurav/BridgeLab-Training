using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class MergeJsonFiles
    {
        public void Run()
        {
            string file1 = "data1.json";
            string file2 = "data2.json";
            string outputFile = "merged.json";

            if (!File.Exists(file1) ||
                !File.Exists(file2))
            {
                Console.WriteLine(
                    "data1.json or data2.json not found."
                );

                return;
            }

            string json1 = File.ReadAllText(file1);
            string json2 = File.ReadAllText(file2);

            JObject object1 = JObject.Parse(json1);
            JObject object2 = JObject.Parse(json2);

            object1.Merge(object2);

            File.WriteAllText(
                outputFile,
                object1.ToString()
            );

            Console.WriteLine(
                $"Merged JSON saved to {outputFile}"
            );
        }
    }
}
