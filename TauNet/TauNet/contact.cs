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
            string domain;

            public contact(string s1, string s2)
            {
                username = s1;
                domain = s2;
            }

            public string getUsername()
            {
                return username;
            }
            public string getDomain()
            {
                return domain;
            }

    }
}
