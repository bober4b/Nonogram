using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram
{
    public class Menu
    {
        public void Menuinit()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo = ("  _   _   ____   _   _   ____    _____  _____             __  __ \r\n | \\ | | / __ \\ | \\ | | / __ \\  / ____||  __ \\     /\\    |  \\/  |\r\n |  \\| || |  | ||  \\| || |  | || |  __ | |__) |   /  \\   | \\  / |\r\n | . ` || |  | || . ` || |  | || | |_ ||  _  /   / /\\ \\  | |\\/| |\r\n | |\\  || |__| || |\\  || |__| || |__| || | \\ \\  / ____ \\ | |  | |\r\n |_| \\_| \\____/ |_| \\_| \\____/  \\_____||_|  \\_\\/_/    \\_\\|_|  |_|\r\n");
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
            string ng = ("             __         \n|\\| _       /__ _ __  _ \n| |(/_\\^/   \\_|(_||||(/_");
            foreach (string line in ng.Split("\n"))
            {
                Console.SetCursorPosition(12, 10 + index);
                Console.Write(line);
                index++;
            }
            string ex = " __                     \n|_     o _|_            \n|__><  |  |_            ";
            index = 0;
            //Console.Write("Exit");


            foreach (string line in ex.Split("\n"))
            {
                Console.SetCursorPosition(12, 13 + index);
                Console.Write(line);
                index++;
            }

            int opt = 0;
            Boolean toMenu = false;
            Boolean Exit = false;
            Boolean newGame=false;
            ConsoleKeyInfo keyInfo;


            do
            {
                if (newGame)
                {
                    Console.SetCursorPosition(10, 10);
                    Gra gra = new Gra();
                    toMenu = gra.newgameinit();
                    Exit = gra.endgame();
                    newGame = gra.newgamer();
                }
                 else
                {
                    if (toMenu)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        index = 0;
                        foreach (string line in logo.Split("\n"))
                        {
                            Console.SetCursorPosition(11, index);
                            Console.Write(line);
                            index++;
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.White;

                        //Console.SetCursorPosition(40, 10);
                        index = 0;
                        foreach (string line in ng.Split("\n"))
                        {
                            Console.SetCursorPosition(12, 10 + index);
                            Console.Write(line);
                            index++;
                        }
                        index = 0;
                        //Console.Write("Exit");


                        foreach (string line in ex.Split("\n"))
                        {
                            Console.SetCursorPosition(12, 13 + index);
                            Console.Write(line);
                            index++;
                        }
                        toMenu = false;
                    }

                    if (opt == 0)
                        Console.SetCursorPosition(11, 12);
                    if (opt == 1)
                        Console.SetCursorPosition(11, 15);

                    keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:

                            if (opt > 0)
                            {
                                opt--;

                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (opt < 1)
                            {
                                opt++;
                            }
                            break;

                        case ConsoleKey.Enter:

                            if (opt == 0)
                            {
                                Console.SetCursorPosition(10, 10);
                                Gra gra = new Gra();
                                toMenu = gra.newgameinit();
                                Exit = gra.endgame();
                                newGame=gra.newgamer();

                            }
                            if (opt == 1)
                                return;

                            break;
                        case ConsoleKey.Spacebar:
                            if (opt == 0)
                            {
                                Console.SetCursorPosition(10, 10);
                                Gra gra = new Gra();
                                toMenu = gra.newgameinit();
                                Exit = gra.endgame();
                                newGame = gra.newgamer();
                            }
                            if (opt == 1)
                                return;
                            break;

                    }
                }
            } while (!Exit);

        }
    }

}

