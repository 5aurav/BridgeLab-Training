using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Streams
{
    internal class PipeCommunication
    {
        public static void Run()
        {
            using (AnonymousPipeServerStream pipe = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
            {
                string handle = pipe.GetClientHandleAsString();

                Thread writer = new Thread(() =>
                {
                    using (StreamWriter sw = new StreamWriter(pipe))
                    {
                        sw.AutoFlush = true;
                        sw.WriteLine("Hello from writer thread");
                        sw.WriteLine("Data sent through pipe");
                    }
                });
                Thread reader = new Thread(() =>
                {
                    using (AnonymousPipeClientStream client = new AnonymousPipeClientStream(PipeDirection.In, handle))
                    {
                        using (StreamReader sr = new StreamReader(client))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                                Console.WriteLine(line);
                        }
                    }
                });

                reader.Start();
                writer.Start();

                writer.Join();
                reader.Join();
            }
        }
    }
}
