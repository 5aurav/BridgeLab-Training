using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new BasicJsonHandling().Run();
            new CarToJson().Run();
            new ReadSpecificFields().Run();
            new MergeJsonObjects().Run();
            new ValidateJsonSchema().Run();
            new ListToJsonArray().Run();
            new FilterJsonByAge().Run();

            new ReadJsonKeysValues().Run();
            new ConvertListToJsonArray().Run();
            new FilterUsersOlderThan25().Run();
            new ValidateEmailSchema().Run();
            new MergeJsonFiles().Run();
            new JsonToXml().Run();
            new CsvToJson().Run();
            new JsonReportFromDatabaseRecords().Run();

            new IplCensorshipAnalyzer().Run();
        }
    }
}
