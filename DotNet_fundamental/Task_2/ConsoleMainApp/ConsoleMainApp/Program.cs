using System;
using HelloWorldLibrary;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter username");
            string username = Console.ReadLine();
            GreetingService greetingService = new GreetingService();
            string greeting = greetingService.GetGreeting(username);
            Console.WriteLine(greeting);
        }
    }
}
