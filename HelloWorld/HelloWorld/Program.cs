using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Enter text. To exit the application, enter exit");
                string text = Console.ReadLine();

                if (!text.ToLower().Equals("exit"))
                {
                    Console.Write("Test in branch");
                    DefaultText(ref text);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"string was entered by the user without changes: {text}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Line after first change: {Job1(ref text)}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Line after second change: {Job2(ref text)}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Line after third change: { Job3(ref text)}");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }

            }

        }
        static string Job1(ref string text)
        {
            var result = String.Join(" ", text.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(value => string.Join("", value.Where(value => char.IsLetter(value))))
                .Select((value, index) => index % 2 == 0 ? new string(value.Reverse().ToArray()) : value));
            text = result;
            return text;
        }

        static string Job2(ref string text)
        {

            var result = String.Join(" ", text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray().Select(y => y.Substring(0, 1).ToUpper() + y.Substring(1).ToLower()).ToArray());
            text = result;
            return text;
        }

        static string Job3(ref string text)
        {
            var result = String.Join(" ", text.Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray()
               //.Select(value => value.EndsWith("n") || value.EndsWith("N") ? value.Replace(value.Last(), 'O') : value)
               .Select(value => value.EndsWith("n") || value.EndsWith("N") ? value.Substring(0, value.Length - 1) + "O" : value)
               .Select(value => value.StartsWith("p") || value.StartsWith("P") ? value.Replace(value.First(), 'S') : value));
            text = result;
            return text;
        }

        static string DefaultText(ref string text)
        {

            if (text == null || text == string.Empty)
            {
                return text = "eiuui45 fhjRpso sood4P 44psDDF1    nnnnn pppp nnpp ppnn";
            }
            else
            {
                return text;
            }
        }
    }
}
