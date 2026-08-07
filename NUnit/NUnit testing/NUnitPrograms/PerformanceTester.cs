using System.Threading;

namespace NUnitPrograms
{
    public class PerformanceTester
    {
        public string LongRunningTask()
        {
            Thread.Sleep(1000);
            return "Completed";
        }
    }
}