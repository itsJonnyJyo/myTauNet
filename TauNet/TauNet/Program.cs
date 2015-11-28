﻿using System;
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
            menu();
            
        }

        private static void menu()
        {
            int choice = 0;
            int send = 1;
            int view = 2;
            int quit = 3;

            Console.WriteLine("Welcome to TauNet");
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(" + send + ") Send a Message.");
                Console.WriteLine("(" + view + ") View Messages.");
                Console.WriteLine("(" + quit + ") Quit.");
                Console.WriteLine("Please enter corresponding number: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice != quit)
                //skip the call to processChoice method if user selects quit.
                {
                    processChoice(choice);
                }
                
            } while (choice != 3);
        }

        private static void processChoice(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    //invoke client.sendMessage
                    break;
                case 2:
                    //display messages from .txt/database
                    break;
                default:
                    Console.WriteLine("Error: Invalid Input");
                    break;
            }
        }
    }
}
