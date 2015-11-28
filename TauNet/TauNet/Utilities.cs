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
        public void readMessages()
        {
            string path = @"C:\Users\Jonathan\Source\Repos\Jensen_Jonathan_cs3002\TauNet\messages.txt";

            try
            {
                //"using" ensures that the system handles unused resources
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.EndOfStream != true)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //read in contacts from .csv
        void getContacts()
        {
            string path = "";

            try {
                //"using" ensures that the system handles unused resources
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.EndOfStream != true)
                    {

                    }
                }
            }catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
