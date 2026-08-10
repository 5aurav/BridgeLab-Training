using Collections.ListProblems;
using Collections.SetProblems;
using Collections.QueueProblems;
using Collections.MapProblems;
using Collections.SystemDesignProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List Problems!");

            ReverseList.Run();
            FrequencyOfElements.Run();
            RotateList.Run();
            RemoveDuplicates.Run();
            NthElementFromEnd.Run();

            Console.WriteLine("Set Problems!");

            SetEquality.Run();
            UnionIntersection.Run();
            SymmetricDifference.Run();
            SortedSetList.Run();
            FindSubset.Run();

            Console.WriteLine("Queue Problems!");

            ReverseQueue.Run();
            BinaryNumbers.Run();
            HospitalTriage.Run();

            Console.WriteLine("Map Problems!");

            WordFrequency.Run();
            InvertMap.Run();

            Console.WriteLine("System Design!");

            InsurancePolicySystem.Run();
            VotingSystem.Run();
            ShoppingCart.Run();
            BankingSystem.Run();
        }
    }
}

