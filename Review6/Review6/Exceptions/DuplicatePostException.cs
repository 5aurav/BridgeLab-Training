using System;
using System.Collections.Generic;
using System.Text;

namespace Review6.Exceptions
{
    public class DuplicatePostException :SocialMediaException
    {
        public DuplicatePostException(string message) : base(message)
        {

        }
    }
}
