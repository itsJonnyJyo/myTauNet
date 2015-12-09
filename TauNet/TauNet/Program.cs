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
            addressBook myContacts = new addressBook();
            menu(myContacts);
            
        }

        private static void menu(addressBook myContacts)
        {
            int choice = 0;
            int send = 1;
            int view = 2;
            int contacts = 3;
            int quit = 4;

            Console.WriteLine("Welcome to TauNet");
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(" + send + ") Send a Message.");
                Console.WriteLine("(" + view + ") View Messages.");
                Console.WriteLine("(" + contacts + ") List Contacts.");
                Console.WriteLine("(" + quit + ") Quit.");
                Console.WriteLine("Please enter corresponding number: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice != quit)
                //skip the call to processChoice method if user selects quit.
                {
                    processChoice(choice, myContacts);
                }
                
            } while (choice != quit);
        }

        private static void processChoice(int userChoice, addressBook myContacts)
        {
            switch (userChoice)
            {
                case 1:
                    //invoke client.sendMessage
                    Client myClient = new Client();
                    Console.WriteLine("Who would you like to send a message to? ");
                    myContacts.listAll();
                    Console.WriteLine("Please enter the number corresponding to the" +
                        " desired recipient: ");
                    int recipient = Convert.ToInt32(Console.ReadLine());
                    myClient.sendMessage(recipient, 6283, myContacts);
                    break;
                case 2:
                    //display messages from .txt/database
                    Utilities myUtilities = new Utilities();

                    myUtilities.readMessages();
                    break;
                case 3:
                    //list contacts
                    myContacts.listAll();
                    break;
                default:
                    Console.WriteLine("Error: Invalid Input");
                    break;
            }
        }
    }
}
