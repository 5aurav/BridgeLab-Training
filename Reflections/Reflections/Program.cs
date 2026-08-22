using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetClassInformation.Run();
            AccessPrivateField.Run();
            InvokePrivateMethod.Run();
            DynamicObjectCreation.Run();
            DynamicMethodInvocation.Run();
            RetrieveAttributes.Run();
            StaticField.Run();
            CustomObjectMapper.Run();
            JsonRepresentation.Run();
            DynamicProxy.Run();
            DependencyInjection.Run();
            MethodExecutionTiming.Run();
        }
    }
}
