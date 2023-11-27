using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//view
namespace Nonogram.view
{
    public class Fieldseter
    {
        public static void Set(int x, int y, bool answer, ConsoleColor color)
        {
            if (answer)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x - 1, y);
                Console.Write("███");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y);
            }
            else
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x - 1, y);
                Console.Write("█X█");
                //WriteConsoleOutputCharacter
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y);
            }
        }
    }
}
