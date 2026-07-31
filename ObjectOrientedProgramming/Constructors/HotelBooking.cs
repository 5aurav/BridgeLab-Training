using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class HotelBooking
    {
        string guestName;
        string roomType;
        int nights;

        public HotelBooking()
        {
            guestName = "Guest";
            roomType = "Standard";
            nights = 1;
        }

        public HotelBooking(string guestName, string roomType, int nights)
        {
            this.guestName = guestName;
            this.roomType = roomType;
            this.nights = nights;
        }

        public HotelBooking(HotelBooking h)
        {
            guestName = h.guestName;
            roomType = h.roomType;
            nights = h.nights;
        }

        public void Display()
        {
            Console.WriteLine("Guest Name : " + guestName);
            Console.WriteLine("Room Type  : " + roomType);
            Console.WriteLine("Nights     : " + nights);
        }

        public static void display()
        {
            HotelBooking h1 = new HotelBooking();
            HotelBooking h2 = new HotelBooking("Saurav", "Deluxe", 3);
            HotelBooking h3 = new HotelBooking(h2);

            Console.WriteLine("Default Constructor");
            h1.Display();

            Console.WriteLine();

            Console.WriteLine("Parameterized Constructor");
            h2.Display();

            Console.WriteLine();

            Console.WriteLine("Copy Constructor");
            h3.Display();
        }
    }
}
