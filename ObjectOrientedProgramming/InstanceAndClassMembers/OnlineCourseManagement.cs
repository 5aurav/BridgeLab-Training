using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstanceAndClassMembers
{
    internal class OnlineCourseManagement
    {
        string courseName;
        int duration;
        double fee;

        static string instituteName = "BridgeLabz";

        public OnlineCourseManagement(string courseName, int duration, double fee)
        {
            this.courseName = courseName;
            this.duration = duration;
            this.fee = fee;
        }

        public void DisplayCourseDetails()
        {
            Console.WriteLine("Course Name   : " + courseName);
            Console.WriteLine("Duration      : " + duration + " Months");
            Console.WriteLine("Fee           : " + fee);
            Console.WriteLine("Institute     : " + instituteName);
        }

        public static void UpdateInstituteName(string name)
        {
            instituteName = name;
        }

        public static void display()
        {
            OnlineCourseManagement c1 = new OnlineCourseManagement("Full Stack Development", 6, 50000);
            OnlineCourseManagement c2 = new OnlineCourseManagement("Data Science", 8, 65000);

            Console.WriteLine("Before Updating Institute Name");
            c1.DisplayCourseDetails();

            Console.WriteLine();

            c2.DisplayCourseDetails();

            Console.WriteLine();

            UpdateInstituteName("Chitkara University");

            Console.WriteLine("After Updating Institute Name");

            Console.WriteLine();

            c1.DisplayCourseDetails();

            Console.WriteLine();

            c2.DisplayCourseDetails();
        }
    }
}
