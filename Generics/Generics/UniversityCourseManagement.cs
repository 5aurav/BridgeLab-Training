using System;
using System.Collections.Generic;

namespace Generics
{
    abstract class CourseType
    {
        public string Name { get; set; }

        public CourseType(string name)
        {
            Name = name;
        }

        public abstract void Display();
    }

    class ExamCourse : CourseType
    {
        public ExamCourse(string name) : base(name) { }

        public override void Display()
        {
            Console.WriteLine($"Exam Course: {Name}");
        }
    }

    class AssignmentCourse : CourseType
    {
        public AssignmentCourse(string name) : base(name) { }

        public override void Display()
        {
            Console.WriteLine($"Assignment Course: {Name}");
        }
    }

    class Course<T> where T : CourseType
    {
        private List<T> courses = new List<T>();

        public void Add(T course)
        {
            courses.Add(course);
        }

        public void Display()
        {
            foreach (T course in courses)
                course.Display();
        }
    }

    public class UniversityCourseManagement
    {
        public static void Run()
        {
            Course<ExamCourse> exams =
                new Course<ExamCourse>();

            Course<AssignmentCourse> assignments =
                new Course<AssignmentCourse>();

            exams.Add(
                new ExamCourse("Data Structures"));

            exams.Add(
                new ExamCourse("Operating Systems"));

            assignments.Add(
                new AssignmentCourse("Database Management"));

            Console.WriteLine("Exam Courses:");
            exams.Display();

            Console.WriteLine("\nAssignment Courses:");
            assignments.Display();
        }
    }
}