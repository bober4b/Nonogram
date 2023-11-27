using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//controler/manual
namespace Nonogram.controls
{
    public class Menu
    {

        private bool toMenu = false;
        private bool Exit = false;
        private bool newGame = false;
        public void Menuinit()
        {
            MenuView.View();

            int opt = 0;

            ConsoleKeyInfo keyInfo;


            do
            {
                if (newGame)
                {

                    Newgame();
                }
                else
                {
                    if (toMenu)
                    {
                        MenuView.View();
                        toMenu = false;
                    }

                    MenuView.Options(opt);

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
                            if (opt < 2)
                            {
                                opt++;
                            }
                            break;

                        case ConsoleKey.Enter:

                            if (opt == 0)
                            {
                                Newgame();

                            }
                            if (opt == 1)
                                Loadgame();
                            if (opt == 2)
                                return;

                            break;
                        case ConsoleKey.Spacebar:
                            if (opt == 0)
                            {
                                Newgame();
                            }
                            if (opt == 1)
                            {
                                Loadgame();
                            }
                            if (opt == 2)
                                return;
                            break;

                    }
                }
            } while (!Exit);

        }

        private void Newgame()
        {
            //Newgameseed.Cleenmenunewgame();

            // while (true) { }
            Gra gra = new();
            toMenu = gra.Newgameinit();
            Exit = gra.Endgame();
            newGame = gra.Newgamer();
            if (!Exit)
                MenuView.View();

        }

        private void Loadgame(string filename = "Continue.txt")
        {



            Gra gra = new(filename);
            toMenu = gra.Newgameinit();
            Exit = gra.Endgame();
            newGame = gra.Newgamer();
            gra.GameSaver();
            if (!Exit)
                MenuView.View();
        }
    }

    /*public class Newgameseed
        {
            public static void Cleenmenunewgame()
            {
                for(int i = 0; i < 7; i++) 
                {
                Console.SetCursorPosition(12, 13+i);
                Console.Write(new string(' ', Console.WindowWidth+i));

                }
            Console.SetCursorPosition(12, 14);
            Console.Write("Wpisz seed gry: ");
            Console.SetCursorPosition(12, 16);
            Console.Write("Start NewGame");
            }

        }*/


}

