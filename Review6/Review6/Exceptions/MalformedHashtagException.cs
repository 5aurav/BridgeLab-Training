using System;
using System.Collections.Generic;
using System.Text;

namespace Review6.Exceptions
{
    public class MalformedHashtagException : SocialMediaException
    {
        public MalformedHashtagException(string message) : base(message)
        {

        }
    }
}
