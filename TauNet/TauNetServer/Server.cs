using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace TauNetServer
{
    class Server
    {
        static void Main(string[] args)
        {
            try
            {
                
                
                ServerUtilities myUtilities = new ServerUtilities();
                //current machines local ip must be used here
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
                    byte[] b = new byte[1024];
                    try
                    {
                        //recieve bytestream. store length in k
                        int k = s.Receive(b);

                        //handle 0 length message
                        if (k > 0)
                        {
                            //decrypt incomming message and write it to file where 
                            //the user can read it from the client side
                            byte[] cipherText = new byte[k];
                            Buffer.BlockCopy(b, 0, cipherText, 0, k);
                            byte[] plainText = myUtilities.decrypt(cipherText, 20, "password");
                            Console.WriteLine("Recieved...");
                            using (StreamWriter sw = new StreamWriter(path, true))
                            {

                                sw.WriteLine(Encoding.UTF8.GetString(plainText));
                                Console.WriteLine(Encoding.UTF8.GetString(plainText));


                                sw.Close();
                            }
                        }
                    }
                    catch (SocketException e)
                    {
                        using (StreamWriter sw = new StreamWriter(path, true))
                        {

                            sw.WriteLine("{0} Error Code: {1}.", e.Message, e.ErrorCode);

                            sw.Close();
                        }
                        Console.WriteLine("{0} Error Code: {1}.", e.Message, e.ErrorCode);
                    }
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
                sw.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                sw.Close();
            }
            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
        }
    }
}