using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class ObsoleteAttributeExample
    {
        public static void Run()
        {
            LegacyAPI api = new LegacyAPI();

#pragma warning disable CS0618
            api.OldFeature();
#pragma warning restore CS0618

            api.NewFeature();
        }
    }

    public class LegacyAPI
    {
        [Obsolete("OldFeature is deprecated. Use NewFeature instead.")]
        public void OldFeature()
        {
            Console.WriteLine("Old feature executed.");
        }

        public void NewFeature()
        {
            Console.WriteLine("New feature executed.");
        }
    }
}
