using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//controler/manual
namespace Nonogram
{
    public class Menu
    {
        private readonly MenuView _view=new();
        private Boolean toMenu = false;
        private Boolean Exit = false;
        private Boolean newGame = false;
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
                            if(opt==1)
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
            Console.SetCursorPosition(10, 10);
            Gra gra = new();
            toMenu = gra.Newgameinit();
            Exit = gra.Endgame();
            newGame = gra.Newgamer();
            if(!Exit)
                MenuView.View();

        }

        private void Loadgame(string filename= "Continue.txt")
        {
            Console.SetCursorPosition(10, 10);
            Gra gra = new(filename);
            toMenu = gra.Newgameinit();
            Exit = gra.Endgame();
            newGame = gra.Newgamer();
            gra.GameSaver();
            if(!Exit)
                MenuView.View();
        }
    }

}

