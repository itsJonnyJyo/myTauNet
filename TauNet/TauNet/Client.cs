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
    class Client
    {
        public void sendMessage(string ip_domain, int port)
        {
            try
            {
                Console.WriteLine("Connecting.....");
                TcpClient tcpclnt = new TcpClient(ip_domain, port);
                

                //tcpclnt.Connect(ip_domain, port);
                // use the ipaddress as in the server program

                Console.WriteLine("Connected");
                

                //String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                //byte[] ba = asen.GetBytes(str);
                byte[] ba = enterMessage();
                //encrypt
                Utilities myUtilities = new Utilities();
                
                Console.WriteLine("Transmitting.....");
                byte[] cipherText = myUtilities.encrypt(ba, 20, "password");
                Console.WriteLine("Finished encryption");
                stm.Write(cipherText, 0, cipherText.Length);
                Console.WriteLine("write to stream success");

                //byte[] bb = new byte[100];
                //int k = stm.Read(bb, 0, 100);

                //for (int i = 0; i < k; i++)
                //    Console.Write(Convert.ToChar(bb[i]));

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
        //prompt user for input and format input
        //to the protocol specification
        byte[] enterMessage() {
            //code 13 and code 10 in byte array for NL
            byte[] newLine = Encoding.ASCII.GetBytes(Environment.NewLine);
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] message;
            string sender = "itsjonnyjyo";
            byte[] bSender = asen.GetBytes(sender);
            Console.WriteLine("Enter Recipient:");
            //List contacts
            string recipient = (Console.ReadLine()).ToLower();
            byte[] bRecipient = asen.GetBytes(recipient);
            string header = ("version: 0.2");
            byte[] bHeader = asen.GetBytes(header);
            Console.Write("Enter the string to be transmitted : ");
            string body = (Console.ReadLine().ToLower());
            byte[] bBody = asen.GetBytes(body);
            List<byte> messageList = new List<byte>();
            //Concat the elements of the message into ONE byte array
            messageList.AddRange(bHeader);
            messageList.AddRange(newLine);
            messageList.AddRange(asen.GetBytes("from: "));
            messageList.AddRange(bSender);
            messageList.AddRange(newLine);
            messageList.AddRange(asen.GetBytes("to: "));
            messageList.AddRange(bRecipient);
            messageList.AddRange(newLine);
            messageList.AddRange(newLine);
            messageList.AddRange(bBody);
            messageList.AddRange(newLine);
            message = messageList.ToArray();
            //message = new byte[bSender.Length + newLine.Length + bRecipient.Length
            //    + newLine.Length + bHeader.Length + newLine.Length + bBody.Length];
            return message;
        }

       /* void selectContact()
        {

        }
        */
    }
}
