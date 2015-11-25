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
            
        }

        void menu()
        {
            Console.WriteLine("Welcome to TauNet");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(1) Send a Message.");
            Console.WriteLine("(2) View Messages.");
            Console.WriteLine("(3) Quit.");
            Console.WriteLine("Please enter corresponding number: ");
            String choice = Console.ReadLine();
            processChoice(String choice);
        }

        void processChoice(String userChoice)
        {
            switch (userChoice)
            {
                case 1:changes

            }
        }
    }
}
