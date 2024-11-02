using System;
using Task2;

namespace Task1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            String command = String.Empty;
            while (command != "exit")
            {
                Console.WriteLine("1. Print first character of each line program");
                Console.WriteLine("2. Parse method to convert a string value to integer. It is NOT allowed to use int.Parse(), int.TryParse() or any other built-in conversion methods.");
                Console.WriteLine("3. Exit");

                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        PrintFirstCharacterOfEachLine();
                        break;
                    case 2:
                        ParseNumber();
                        break;
                    case 3:
                        command = "exit";
                        break;

                    default:
                        Console.WriteLine("Unknown command. Please try again.");
                        break;

                }
            }

        }

        private static void PrintFirstCharacterOfEachLine()
        {
            while (true)
            {
                Console.WriteLine("Enter a line of text (or type 'exit' to quit):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("Input cannot be empty.");
                    }

                    Console.WriteLine($"The first letter is : {input.Substring(0, 1)}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void ParseNumber()
        {
            NumberParser parser = new NumberParser();
            try
            {
                Console.WriteLine("Enter a number");
                string input = Console.ReadLine();
                int result = parser.Parse(input);
                Console.WriteLine($"Parse number {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}