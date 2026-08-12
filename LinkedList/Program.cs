using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Records");
            StudentRecords.Run();

            Console.WriteLine("\nMovie Management");
            MovieManagement.Run();

            Console.WriteLine("\nTask Scheduler");
            TaskScheduler.Run();

            Console.WriteLine("\nInventory Management");
            InventoryManagement.Run();

            Console.WriteLine("\nLibrary Management");
            LibraryManagement.Run();

            Console.WriteLine("\nRound Robin Scheduling");
            RoundRobinScheduling.Run();

            Console.WriteLine("\nSocial Media Friends");
            SocialMediaFriends.Run();

            Console.WriteLine("\nText Editor Undo Redo");
            TextEditorHistory.Run();

            Console.WriteLine("\nTicket Reservation");
            TicketReservation.Run();
        }
    }
}
