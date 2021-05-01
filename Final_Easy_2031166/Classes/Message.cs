using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Easy_2031166.Classes
{
    public static class Message
    {

        public static void PrintDanger(this string message)
        {
            Print(message, ConsoleColor.Red);
        }
        public static void PrintWarning(this string message)
        {
            Print(message, ConsoleColor.DarkYellow);
        }
        public static void PrintInfo(this string message)
        {
            Print(message, ConsoleColor.Yellow);
        }
        public static void PrintMainMenu(this string message)
        {
            Print(message, ConsoleColor.Green);
        }
        public static void PrintMenu(this string message)
        {
            Print(message, ConsoleColor.Blue);
        }
        public static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
