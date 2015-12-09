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
                        //read one contact from .csv and parse into "words"
                        words = (sr.ReadLine()).Split(delimiters);
                      
                        //create new contact with the username and hostname currently 
                        //stored in words
                        contacts.Add(new contact(words[0], words[1]));

                        //clear "words" for next iteration of the loop
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
                Console.WriteLine("; HOSTNAME: " + contactArray[i].getHostname());
            } 
        }

        public string returnHostname(int index)
        {
           return contacts[index].getHostname();
        }

        public string returnUsername(int index)
        {
            return contacts[index].getUsername();
        }
    }
}
