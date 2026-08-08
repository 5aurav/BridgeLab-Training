using System;
using System.Collections.Generic;

namespace Generics
{
    abstract class JobRole
    {
        public string Name { get; set; }

        public JobRole(string name)
        {
            Name = name;
        }
    }

    class SoftwareEngineer : JobRole
    {
        public SoftwareEngineer()
            : base("Software Engineer") { }
    }

    class DataScientist : JobRole
    {
        public DataScientist()
            : base("Data Scientist") { }
    }

    class Resume<T> where T : JobRole
    {
        public string CandidateName { get; set; }
        public List<string> Skills { get; set; }
        public T Role { get; set; }

        public Resume(string name, T role)
        {
            CandidateName = name;
            Role = role;
            Skills = new List<string>();
        }

        public void AddSkill(string skill)
        {
            Skills.Add(skill);
        }
    }

    class ResumeScreening
    {
        public void Screen<T>(
            Resume<T> resume,
            List<string> requiredSkills)
            where T : JobRole
        {
            int matched = 0;

            foreach (string skill in requiredSkills)
            {
                if (resume.Skills.Contains(skill))
                    matched++;
            }

            Console.WriteLine(
                $"{resume.CandidateName} - {resume.Role.Name}");

            Console.WriteLine(
                $"Skills matched: {matched}/{requiredSkills.Count}");
        }
    }

    public class AIResumeScreeningSystem
    {
        public static void Run()
        {
            Resume<SoftwareEngineer> softwareResume =
                new Resume<SoftwareEngineer>(
                    "Aman",
                    new SoftwareEngineer());

            softwareResume.AddSkill("C#");
            softwareResume.AddSkill(".NET");
            softwareResume.AddSkill("SQL");

            Resume<DataScientist> dataResume =
                new Resume<DataScientist>(
                    "Riya",
                    new DataScientist());

            dataResume.AddSkill("Python");
            dataResume.AddSkill("SQL");
            dataResume.AddSkill("Machine Learning");

            ResumeScreening screening =
                new ResumeScreening();

            screening.Screen(
                softwareResume,
                new List<string>
                {
                    "C#", ".NET", "SQL", "DSA"
                });

            screening.Screen(
                dataResume,
                new List<string>
                {
                    "Python", "SQL", "Machine Learning"
                });
        }
    }
}