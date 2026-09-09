using System;
using System.Collections.Generic;
using System.Text;

namespace Review6.Exceptions
{
    public class NegativeEngagementException : SocialMediaException
    {
        public NegativeEngagementException(string message) : base(message)
        {

        }
    }
}
