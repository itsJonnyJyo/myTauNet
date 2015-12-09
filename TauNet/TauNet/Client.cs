// copyright (c) Jonathan Jensen
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace TauNetServer
{
    class Client
    {
        public void sendMessage(int hostname, int port, addressBook myContacts)
        {
            try
            {   
                Utilities myUtilities = new Utilities();
                byte[] ba = enterMessage(hostname, myContacts);
                Console.WriteLine("Connecting.....");
                TcpClient tcpclnt = new TcpClient(myContacts.returnHostname(hostname), port);
                Stream stm = tcpclnt.GetStream();
                            
                Console.WriteLine("Transmitting.....");
                //encrypt the message
                byte[] cipherText = myUtilities.encrypt(ba, 20, "password");
                //Console.WriteLine("Finished encryption");
                //write cipherText to current stream
                stm.Write(cipherText, 0, cipherText.Length);
                Console.WriteLine("Messege send succesful");

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
        //prompt user for input and format input
        //to the protocol specification
        byte[] enterMessage(int hostname, addressBook myContacts) {
            //code 13 and code 10 in byte array for NL
            byte[] newLine = Encoding.ASCII.GetBytes(Environment.NewLine);
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] message;
            string sender = "itsjonnyjyo";
            byte[] bSender = asen.GetBytes(sender);
            string recipient = (myContacts.returnUsername(hostname)).ToLower();
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
            return message;
        }
    }
}
