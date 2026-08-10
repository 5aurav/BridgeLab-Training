using System;
using System.Collections.Generic;

namespace Collections.QueueProblems
{
    internal class Patient
    {
        public string Name { get; set; }
        public int Severity { get; set; }

        public Patient(string name, int severity)
        {
            Name = name;
            Severity = severity;
        }
    }

    internal class HospitalTriage
    {
        public static void Run()
        {
            Queue<Patient> patients = new Queue<Patient>();

            patients.Enqueue(new Patient("John", 3));
            patients.Enqueue(new Patient("Alice", 5));
            patients.Enqueue(new Patient("Bob", 2));

            while (patients.Count > 0)
            {
                Patient highestSeverity = null;

                foreach (Patient patient in patients)
                {
                    if (highestSeverity == null ||
                        patient.Severity > highestSeverity.Severity)
                    {
                        highestSeverity = patient;
                    }
                }

                int count = patients.Count;

                for (int i = 0; i < count; i++)
                {
                    Patient patient = patients.Dequeue();

                    if (patient != highestSeverity)
                    {
                        patients.Enqueue(patient);
                    }
                }

                Console.WriteLine(
                    highestSeverity.Name +
                    " - Severity " +
                    highestSeverity.Severity);
            }
        }
    }
}