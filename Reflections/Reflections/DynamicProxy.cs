using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{

    public class DynamicProxy
    {
        public static void Run()
        {
            IGreeting target = new GreetingService();

            GreetingProxy proxy = new GreetingProxy(target);

            proxy.Invoke("SayHello", new object[] { "Saurav" });
        }
    }

    public interface IGreeting
    {
        void SayHello(string name);
    }

    public class GreetingService : IGreeting
    {
        public void SayHello(string name)
        {
            Console.WriteLine("Hello, " + name + "!");
        }
    }

    public class GreetingProxy
    {
        private object target;

        public GreetingProxy(object target)
        {
            this.target = target;
        }

        public object Invoke(string methodName, object[] parameters)
        {
            Type type = target.GetType();

            MethodInfo method = type.GetMethod(methodName);

            if (method == null)
            {
                Console.WriteLine("Method not found.");
                return null;
            }

            Console.WriteLine("Calling method: " + method.Name);

            object result = method.Invoke(target, parameters);

            Console.WriteLine("Finished method: " + method.Name);

            return result;
        }
    }
}