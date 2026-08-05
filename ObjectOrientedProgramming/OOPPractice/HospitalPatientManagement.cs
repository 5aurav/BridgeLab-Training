using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPractice
{
    interface IMedicalRecord
    {
        void AddRecord(string record);
        void ViewRecords();
    }

    abstract class Patient
    {
        private int patientId;
        private string name;
        private int age;
        private string diagnosis;
        private List<string> medicalHistory = new List<string>();

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Diagnosis
        {
            get { return diagnosis; }
            private set { diagnosis = value; }
        }

        protected List<string> MedicalHistory
        {
            get { return medicalHistory; }
        }

        public Patient(int patientId, string name, int age, string diagnosis)
        {
            PatientId = patientId;
            Name = name;
            Age = age;
            Diagnosis = diagnosis;
        }

        public abstract double CalculateBill();

        public void GetPatientDetails()
        {
            Console.WriteLine($"Patient ID : {PatientId}");
            Console.WriteLine($"Name       : {Name}");
            Console.WriteLine($"Age        : {Age}");
        }
    }

    class InPatient : Patient, IMedicalRecord
    {
        public InPatient(int patientId, string name, int age, string diagnosis)
            : base(patientId, name, age, diagnosis)
        {
        }

        public override double CalculateBill()
        {
            return 15000;
        }

        public void AddRecord(string record)
        {
            MedicalHistory.Add(record);
        }

        public void ViewRecords()
        {
            Console.WriteLine("Medical Records:");
            foreach (string record in MedicalHistory)
            {
                Console.WriteLine(record);
            }
        }
    }

    class OutPatient : Patient, IMedicalRecord
    {
        public OutPatient(int patientId, string name, int age, string diagnosis)
            : base(patientId, name, age, diagnosis)
        {
        }

        public override double CalculateBill()
        {
            return 1000;
        }

        public void AddRecord(string record)
        {
            MedicalHistory.Add(record);
        }

        public void ViewRecords()
        {
            Console.WriteLine("Medical Records:");
            foreach (string record in MedicalHistory)
            {
                Console.WriteLine(record);
            }
        }
    }

    class HospitalPatientManagement
    {
        public static void Run()
        {
            List<Patient> patients = new List<Patient>();

            InPatient patient1 = new InPatient(101, "Rahul", 35, "Fever");
            patient1.AddRecord("Admitted to Room 201");

            OutPatient patient2 = new OutPatient(102, "Priya", 28, "Cold");
            patient2.AddRecord("Prescribed Medicines");

            patients.Add(patient1);
            patients.Add(patient2);

            foreach (Patient patient in patients)
            {
                patient.GetPatientDetails();
                Console.WriteLine($"Bill Amount : {patient.CalculateBill()}");

                if (patient is IMedicalRecord record)
                {
                    record.ViewRecords();
                }

                Console.WriteLine();
            }
        }
    }
}
