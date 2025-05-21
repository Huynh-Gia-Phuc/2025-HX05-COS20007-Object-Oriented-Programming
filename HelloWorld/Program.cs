using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello, World! Greetings from Message Object. My Student ID is SWS01358");

            myMessage.Print();

            List<Message> messages = new List<Message>()
            {

            new Message("Hello, World! Greetings from Messages Object. Hi Mom"),
            new Message("Hello, World! Greetings from Messages Object. Hi Dad"),
            new Message("Hello, World! Greetings from Messages Object. Hi Swinfood"),
            new Message("Hello, World! Greetings from Messages Object. Hi my crs that i like but do not have gut to talk to"),
            new Message("Hello, World! Greetings from Messages Object. Hi random people who try to use this application")

            };
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            if (name == "Mom")
            {
                messages[0].Print();
            }
            else if (name == "Dad")
            {
                messages[1].Print();
            }
            else if (name == "Swinfood")
            {
                messages[2].Print();
            }
            else if (name == "N")
            {
                messages[3].Print();
            }
            else
            {
                messages[4].Print();
            }

        }
    }
}