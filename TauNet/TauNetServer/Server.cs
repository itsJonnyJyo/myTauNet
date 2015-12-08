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

                    IPAddress ipAd = IPAddress.Parse("192.168.1.149");

                    /* Initializes the Listener */
                    TcpListener myList = new TcpListener(ipAd, 6283);
                while (true)
                {
                    /* Start Listeneting at the specified port */
                    myList.Start();

                    Console.WriteLine("The server is running at port 6283...");
                    Console.WriteLine("The local End point is  :" +
                                      myList.LocalEndpoint);
                    Console.WriteLine("Waiting for a connection.....");

                    Socket s = myList.AcceptSocket();

                    serverLog(s);
                    string path = @"C:\Users\Jonathan\Source\Repos\Jensen_Jonathan_cs3002\TauNet\messages.txt";
                    //there was an error here. size of new byte[] was only 100
                    byte[] b = new byte[1024];
                    try
                    {
                        int k = s.Receive(b);

                        if (k > 0)
                        {
                            byte[] cipherText = new byte[k];
                            Buffer.BlockCopy(b, 0, cipherText, 0, k);
                            byte[] plainText = myUtilities.decrypt(cipherText, 20, "password");
                            //string path = @"C:\Users\Jonathan\Source\Repos\Jensen_Jonathan_cs3002\TauNet\messages.txt";
                            Console.WriteLine("Recieved...");
                            using (StreamWriter sw = new StreamWriter(path, true))
                            {

                                sw.Write(Encoding.UTF8.GetString(plainText));
                                Console.Write(Encoding.UTF8.GetString(plainText));


                                sw.Close();
                            }
                        }
                    }
                    catch (SocketException e)
                    {
                        using (StreamWriter sw = new StreamWriter(path, true))
                        {

                            sw.Write("{0} Error Code: {1}.", e.Message, e.ErrorCode);

                            sw.Close();
                        }
                        Console.WriteLine("{0} Error Code: {1}.", e.Message, e.ErrorCode);
                    }

                    //ASCIIEncoding asen = new ASCIIEncoding();
                    //s.Send(asen.GetBytes("The string was recieved by the server."));
                    //Console.WriteLine("\nSent Acknowledgement");
                    /* clean up */
                    s.Close();
                }
                myList.Stop();
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }

           
        }
        //maintains record of connections.
        static void serverLog(Socket s)
        {
            string path = @"C:\Users\Jonathan\Source\Repos\Jensen_Jonathan_cs3002\TauNet\serverlog.txt";
            Console.WriteLine("Recieved...");
            using (StreamWriter sw = new StreamWriter(path, true))
            {

                sw.Write("Connection accepted from " + s.RemoteEndPoint);

                sw.Close();
            }

            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
        }
    }
}