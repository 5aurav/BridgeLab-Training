using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class RoleAllowedDemo
    {
        public static void Run()
        {
            string currentRole = "USER";

            ExecuteMethod("AdminOperation", currentRole);

            currentRole = "ADMIN";

            ExecuteMethod("AdminOperation", currentRole);
        }

        private static void ExecuteMethod(
            string methodName,
            string currentRole)
        {
            AdminOperations operations =
                new AdminOperations();

            MethodInfo method =
                typeof(AdminOperations).GetMethod(methodName);

            RoleAllowedAttribute attribute =
                method.GetCustomAttribute<RoleAllowedAttribute>();

            if (attribute != null &&
                attribute.Role != currentRole)
            {
                Console.WriteLine("Access Denied!");
                return;
            }

            method.Invoke(operations, null);
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class RoleAllowedAttribute : Attribute
    {
        public string Role { get; }

        public RoleAllowedAttribute(string role)
        {
            Role = role;
        }
    }

    public class AdminOperations
    {
        [RoleAllowed("ADMIN")]
        public void AdminOperation()
        {
            Console.WriteLine("Admin operation executed.");
        }
    }
}
