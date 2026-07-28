using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class OTPGenerator
    {
        public static void display()
        {
            int[] otpArray = new int[10];

            Console.WriteLine("Generated OTPs");

            for (int i = 0; i < otpArray.Length; i++)
            {
                otpArray[i] = GenerateOTP();
                Console.WriteLine("OTP " + (i + 1) + " : " + otpArray[i]);
            }

            if (AreUnique(otpArray))
            {
                Console.WriteLine("\nAll OTPs are Unique.");
            }
            else
            {
                Console.WriteLine("\nDuplicate OTPs Found.");
            }
        }

        public static int GenerateOTP()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(100000, 1000000);
        }

        public static bool AreUnique(int[] otpArray)
        {
            for (int i = 0; i < otpArray.Length - 1; i++)
            {
                for (int j = i + 1; j < otpArray.Length; j++)
                {
                    if (otpArray[i] == otpArray[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
