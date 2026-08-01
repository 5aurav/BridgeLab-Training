using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPKeywords
{
    internal class HospitalManagementSystem
    {
        public string Name;
        public int Age;
        public string Ailment;
        public readonly int PatientID;

        static string HospitalName = "City Hospital";
        static int TotalPatients = 0;

        public HospitalManagementSystem(string Name, int Age, string Ailment, int PatientID)
        {
            this.Name = Name;
            this.Age = Age;
            this.Ailment = Ailment;
            this.PatientID = PatientID;

            TotalPatients++;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Hospital Name : " + HospitalName);
            Console.WriteLine("Patient ID    : " + PatientID);
            Console.WriteLine("Name          : " + Name);
            Console.WriteLine("Age           : " + Age);
            Console.WriteLine("Ailment       : " + Ailment);
        }

        public static void GetTotalPatients()
        {
            Console.WriteLine("Total Patients : " + TotalPatients);
        }

        public static void display()
        {
            HospitalManagementSystem patient1 =
                new HospitalManagementSystem("Saurav", 21, "Fever", 101);

            HospitalManagementSystem patient2 =
                new HospitalManagementSystem("Rahul", 25, "Fracture", 102);

            if (patient1 is HospitalManagementSystem)
            {
                Console.WriteLine("Patient 1 Details");
                patient1.DisplayDetails();
            }

            Console.WriteLine();

            if (patient2 is HospitalManagementSystem)
            {
                Console.WriteLine("Patient 2 Details");
                patient2.DisplayDetails();
            }

            Console.WriteLine();

            GetTotalPatients();
        }
    }
}
