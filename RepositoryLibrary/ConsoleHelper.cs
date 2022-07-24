using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class ConsoleHelper
    {
        public static void WriteWithColor(ConsoleColor color, string word)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(word);
            Console.ResetColor();
        }
    }
}
