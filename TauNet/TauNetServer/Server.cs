using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace TauNet
{
    class Server
    {
        static void Main(string[] args)
        {
            try
            {
                Utilities myUtilities = new Utilities();

                IPAddress ipAd = IPAddress.Parse("192.168.1.147");
                // use local m/c IP address, and 
                // use the same in the client

                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 8001);

                /* Start Listeneting at the specified port */
                myList.Start();

                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is  :" +
                                  myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                Socket s = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
                //there was an error here. size of new byte[] was only 100
                byte[] b = new byte[1024];
                int k = s.Receive(b);
                byte[] cipherText = new byte[k];
                Buffer.BlockCopy(b, 0, cipherText, 0, k);
                byte[] plainText = myUtilities.decrypt(cipherText, 20, "password");
                string path = @"C:\Users\Jonathan\Source\Repos\Jensen_Jonathan_cs3002\TauNet\messages.txt";
                Console.WriteLine("Recieved...");
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    for (int i = 0; i < k; i++)
                    {
                        sw.Write(Convert.ToChar(plainText[i]));
                        Console.Write(Convert.ToChar(plainText[i]));
                    }
                    sw.Close();
                }

                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
                /* clean up */
                s.Close();
                myList.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }


    }
}