using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class MaxLengthAttribute
    {
        public static void Run()
        {
            try
            {
                User user = new User("Saurav");

                Console.WriteLine("Username: " + user.GetUsername());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            try
            {
                User user = new User("ThisUsernameIsTooLong");

                Console.WriteLine("Username: " + user.GetUsername());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class MaxLength : Attribute
    {
        public int Value { get; }

        public MaxLength(int value)
        {
            Value = value;
        }
    }

    public class User
    {
        [MaxLength(10)]
        private string Username;

        public User(string username)
        {
            FieldInfo field =
                typeof(User).GetField(
                    "Username",
                    BindingFlags.NonPublic |
                    BindingFlags.Instance);

            MaxLength attribute =
                field.GetCustomAttribute<MaxLength>();

            if (username.Length > attribute.Value)
            {
                throw new ArgumentException(
                    "Username cannot exceed " +
                    attribute.Value +
                    " characters.");
            }

            Username = username;
        }

        public string GetUsername()
        {
            return Username;
        }
    }

}
