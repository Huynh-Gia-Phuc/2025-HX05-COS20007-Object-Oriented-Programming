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

            new Message("Hi Mom, how are you?"),
            new Message("Hi DAD, how are you?"),
            new Message("Hi Swinfood, how are you?"),
            new Message("Welcome Admin"),
            new Message("Welcome, nice to me you.")

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
            else if (name == "Phuc")
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