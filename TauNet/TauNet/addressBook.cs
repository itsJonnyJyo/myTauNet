using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TauNet
{
    class addressBook
    {
       
        List<contact> contacts = new List<contact>();

        //read in contacts from .csv
        public addressBook()
        {
            string path = @"C:\Users\Jonathan\Source\Repos\Jensen_Jonathan_cs3002\TauNet\contacts.csv";
            string[] words;
            try
            {
                //"using" ensures that the system handles unused resources
                using (StreamReader sr = new StreamReader(path))
                {
                    char[] delimiters = { ',' };
                    while (sr.EndOfStream != true)
                    {  
                        words = (sr.ReadLine()).Split(delimiters);
                      
                        contacts.Add(new contact(words[0], words[1]));

                        Array.Clear(words, 0, words.Length);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void listAll()
        {
            contact[] contactArray = contacts.ToArray();
            
            for (int i = 0; i < contactArray.Length; i++)
            {
                Console.Write("(" + i + ") USERNAME: " + contactArray[i].getUsername());
                Console.WriteLine("; HOSTNAME: " + contactArray[i].getDomain());
            } 
        }
    }
}
