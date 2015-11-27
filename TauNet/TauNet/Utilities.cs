using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace TauNet
{
    public class Utilities
    {
        //read in contacts from .csv
        void getContacts()
        {
            string path = "";
            //"using" ensure the system handles unused resources
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {

                }
            }
            
        }
    }
}
