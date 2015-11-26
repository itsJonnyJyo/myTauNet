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
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ** Server runs at startup.
            ** Client is invoked in a new thread when
            ** user requests to send a message and requests
            ** a connection with the domain or ip that the 
            ** user specifies. 

            */
            Process serverProcess = new Process();
            serverProcess.startInfo
            
        }

        void menu()
        {
            Console.WriteLine("Welcome to TauNet");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(1) Send a Message.");
            Console.WriteLine("(2) View Messages.");
            Console.WriteLine("(3) Quit.");
            Console.WriteLine("Please enter corresponding number: ");
            int choice = Console.Read();
            processChoice(choice);
        }

        void processChoice(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    //invoke client.sendMessage
                    break;
                

            }
        }
    }
}
