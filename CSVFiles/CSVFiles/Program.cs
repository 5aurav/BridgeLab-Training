using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadCsv.Run();

            WriteCsv.Run();

            CountRows.Run();

            FilterRecords.Run();

            SearchRecord.Run();

            UpdateSalary.Run();

            SortBySalary.Run();

            ValidateCsv.Run();

            CsvToObjects.Run();

            MergeCsv.Run();

            LargeCsv.Run();

            DetectDuplicates.Run();

            DatabaseToCsv.Run();

            JsonCsvConversion.Run();

        }
    }
}
