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
        public byte[] encrypt(byte[] message, int rounds, string key){
            int length = message.Length;
            byte[] cipherText = new byte[length + 10];
            byte[] key2 = Encoding.ASCII.GetBytes(key);

            //create iv
            Random rnd = new Random();
            byte[] iv = new byte[10];
            rnd.NextBytes(iv);

            //prepend key2 to iv
            byte[] keyPrime = new byte[key2.Length + iv.Length];
            /* "BlockCopy()" Copies a specified number of bytes from a source array starting
            ** at a particlular offset to a destination array starting at 
            ** a particular offset
            */
            System.Buffer.BlockCopy(key2, 0, keyPrime, 0, key2.Length);
            System.Buffer.BlockCopy(iv, 0, keyPrime, key2.Length, iv.Length);

            byte[] keyStream = rc4(length, rounds, keyPrime);
            
            // iv goes at the beginning of the encrypted
            // message to be transmitted.
            for (int i = 0; i < 10; i++)
            {
                cipherText[i] = iv[i];
            }

            for( int j = 0; j <= length; j++)
            {
                cipherText[j + 10] = (byte)(message[j] ^ keyStream[j]);
            }

            return cipherText;
            }

        public byte[] rc4(int messageLength, int rounds, byte[] ivKey)
        {
            byte[] keyStream = new byte[messageLength];

            return keyStream;
        }

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
