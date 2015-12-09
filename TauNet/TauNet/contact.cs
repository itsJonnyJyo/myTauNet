using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TauNet
{
    class contact
    {
            string username;
            string hostname;

            public contact(string s1, string s2)
            {
                username = s1;
                hostname = s2;
            }

            public string getUsername()
            {
                return username;
            }
            public string getHostname()
            {
                return hostname;
            }

    }
}
