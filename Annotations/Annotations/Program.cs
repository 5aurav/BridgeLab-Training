using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MethodOverriding.Run();
            ObsoleteAttributeExample.Run();
            SuppressWarnings.Run();
            TaskInfoAttributeExample.Run();
            RepeatableAttribute.Run();
            ImportantMethodAttributeScanner.Run();
            TodoAttribute.Run();
            LogExecutionTimeRunner.Run();
            MaxLengthAttribute.Run();
            RoleAllowedDemo.Run();
            JsonFieldProcessor.Run();
            CacheResultDemo.Run();
        }
    }
}
