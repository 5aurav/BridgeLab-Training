using System;
using System.Collections.Generic;
using System.Text;

namespace Review6.Exceptions
{
    public class SocialMediaException : Exception
    {
        public SocialMediaException(string message) : base(message)
        {

        }
    }
}
