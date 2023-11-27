using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//View
namespace Nonogram.view
{
    public class MenuView
    {
        public static void View()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo = "  _   _   ____   _   _   ____    _____  _____             __  __ \r\n | \\ | | / __ \\ | \\ | | / __ \\  / ____||  __ \\     /\\    |  \\/  |\r\n |  \\| || |  | ||  \\| || |  | || |  __ | |__) |   /  \\   | \\  / |\r\n | . ` || |  | || . ` || |  | || | |_ ||  _  /   / /\\ \\  | |\\/| |\r\n | |\\  || |__| || |\\  || |__| || |__| || | \\ \\  / ____ \\ | |  | |\r\n |_| \\_| \\____/ |_| \\_| \\____/  \\_____||_|  \\_\\/_/    \\_\\|_|  |_|\r\n";
            int index = 0;
            foreach (string line in logo.Split("\n"))
            {
                Console.SetCursorPosition(11, index);
                Console.Write(line);
                index++;
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Console.SetCursorPosition(40, 10);
            index = 0;
            string ng = "             __         \n|\\| _       /__ _ __  _ \n| |(/_\\^/   \\_|(_||||(/_";
            foreach (string line in ng.Split("\n"))
            {
                Console.SetCursorPosition(12, 10 + index);
                Console.Write(line);
                index++;
            }
            string ex = " __                     \n|_    o _|_            \n|__>< |  |_            ";
            index = 0;

            string lg = "                __          \n|   _  _  _|   /__ _ __  _ \n|__(_)(_|(_|   \\_|(_||||(/_";

            foreach (string line in lg.Split("\n"))
            {



                Console.SetCursorPosition(12, 13 + index);
                Console.Write(line);
                index++;
            }



            index = 0;



            foreach (string line in ex.Split("\n"))
            {



                Console.SetCursorPosition(12, 16 + index);
                Console.Write(line);
                index++;
            }
        }
        public static void Options(int opt)
        {
            if (opt == 0)
                Console.SetCursorPosition(11, 12);
            if (opt == 1)
                Console.SetCursorPosition(11, 15);
            if (opt == 2)
                Console.SetCursorPosition(11, 18);
        }
    }
}
