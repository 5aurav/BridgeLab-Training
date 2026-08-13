using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_and_Queue
{
    class CircularTour
    {
        class Pump
        {
            public int petrol;
            public int distance;

            public Pump(int petrol, int distance)
            {
                this.petrol = petrol;
                this.distance = distance;
            }
        }

        public static void Run()
        {
            Queue<Pump> pumps = new Queue<Pump>();

            pumps.Enqueue(new Pump(6, 4));
            pumps.Enqueue(new Pump(3, 6));
            pumps.Enqueue(new Pump(7, 3));
            pumps.Enqueue(new Pump(4, 5));

            int answer = FindStart(pumps);

            Console.WriteLine(
                "Starting pump index: " + answer);
        }

        static int FindStart(Queue<Pump> pumps)
        {
            Pump[] arr = pumps.ToArray();

            int start = 0;
            int petrol = 0;
            int total = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int gain =
                    arr[i].petrol -
                    arr[i].distance;

                petrol += gain;
                total += gain;

                if (petrol < 0)
                {
                    start = i + 1;
                    petrol = 0;
                }
            }

            if (total >= 0)
                return start;

            return -1;
        }
    }
}
