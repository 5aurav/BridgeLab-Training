using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileNotFound.Run();
            DivisionAndInput.Run();
            CustomException.Run();
            MultipleExceptions.Run();
            UsingStreamReader.Run();
            InterestCalculation.Run();
            Finally.Run();
            ExceptionPropagation.Run();
            NestedTryCatch.Run();
            BankTransaction.Run();
        }
    }
}
