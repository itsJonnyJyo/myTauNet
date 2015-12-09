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
            byte[] key2 = Encoding.UTF8.GetBytes(key);

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
            Buffer.BlockCopy(key2, 0, keyPrime, 0, key2.Length);
            Buffer.BlockCopy(iv, 0, keyPrime, key2.Length, iv.Length);

            byte[] keyStream = rc4(length, rounds, keyPrime);
            
            // iv goes at the beginning of the encrypted
            // message to be transmitted.
            for (int i = 0; i < 10; i++)
            {
                cipherText[i] = iv[i];
            }

            for( int j = 0; j < length; j++)
            {
                cipherText[j + 10] = (byte)(message[j] ^ keyStream[j]);
            }

            return cipherText;
            }

        public byte[] rc4(int messageLength, int rounds, byte[] ivKey)
        {
            int length = ivKey.Length;
            byte[] keyStream = new byte[messageLength];
            byte[] schedule = new byte[256];
            int i = 0;
            int j = 0;
            int iPrime = 0;
            for ( i = 0; i < 256; i++)
            {
                schedule[i] = (byte)i;
            }

            byte temp;

            for ( int k = 0; k < rounds; k++)
            {
                for ( i = 0; i < 256; i++)
                {
                    j = (j + schedule[i] + ivKey[i % length]) % 256;
                    temp = schedule[i];
                    schedule[i] = schedule[j];
                    schedule[j] = temp;
                }
            }
            j = 0;
            for (i = 0; i < messageLength; i++)
            {
                iPrime = (i + 1) % 256;
                j = (j + schedule[iPrime]) % 256;
                temp = schedule[iPrime];
                schedule[iPrime] = schedule[j];
                schedule[j] = temp;
                keyStream[i] = schedule[(schedule[iPrime] + schedule[j]) % 256];
            }    

            return keyStream;
        }

        public byte[] decrypt(byte[] cipherText, int rounds, string key)
        {
            byte[] plainText = new byte[cipherText.Length - 10];
            byte[] iv = new byte[10];
            byte[] key2 = Encoding.UTF8.GetBytes(key);
            // cipherText was prepended with the iv upon encryption
            //copy first 10 bytes of cipherText into iv
            Buffer.BlockCopy(cipherText, 0, iv, 0, 10);
            byte[] keyPrime = new byte[key2.Length + iv.Length];
            Buffer.BlockCopy(key2, 0, keyPrime, 0, key2.Length);
            Buffer.BlockCopy(iv, 0, keyPrime, key2.Length, iv.Length);

            byte[] keyStream = rc4(cipherText.Length - 10, rounds, keyPrime);

            for (int i = 0; i < (cipherText.Length - 10); i++)
            {
                plainText[i] = (byte)(cipherText[i + 10] ^ keyStream[i]);
            }

            return plainText;
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
    }
}
