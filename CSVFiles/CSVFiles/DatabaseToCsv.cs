using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class DatabaseToCsv
    {
        public static void Run()
        {
            string connectionString =
                "Server=localhost;" +
                "Database=CompanyDB;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";

            string query =
                "SELECT EmployeeID, Name, Department, Salary " +
                "FROM Employees";

            string outputFile =
                Path.Combine(
                    "Output",
                    "employees_from_database.csv");

            List<string[]> employees =
                new List<string[]>();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(
                        connectionString))
                {

                    connection.Open();


                    using (SqlCommand command =
                        new SqlCommand(
                            query,
                            connection))


                    using (SqlDataReader reader =
                        command.ExecuteReader())


                        while (reader.Read())
                        {
                            string[] employee =
                            {
                    reader["EmployeeID"].ToString(),

                    reader["Name"].ToString(),

                    reader["Department"].ToString(),

                    reader["Salary"].ToString()
                };

                            employees.Add(employee);
                        }

                    string[] headers =
                    {
                "Employee ID",
                "Name",
                "Department",
                "Salary"
            };

                    CsvHelper.WriteCsv(
                        outputFile,
                        headers,
                        employees);

                    Console.WriteLine(
                        $"Database data exported to: {outputFile}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Database error: {ex.Message}");
            }
        }
    }
}
