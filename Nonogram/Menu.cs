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
        private MenuView _view=new();
        private Boolean toMenu = false;
        private Boolean Exit = false;
        private Boolean newGame = false;
        public void Menuinit()
        {
            _view.view();

            int opt = 0;
            
            ConsoleKeyInfo keyInfo;


            do
            {
                if (newGame)
                {

                    newgame();
                }
                 else
                {
                    if (toMenu)
                    {
                        _view.view();
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
                                newgame();

                            }
                            if (opt == 1)
                                return;

                            break;
                        case ConsoleKey.Spacebar:
                            if (opt == 0)
                            {
                                newgame();
                            }
                            if (opt == 1)
                                return;
                            break;

                    }
                }
            } while (!Exit);

        }

        private void newgame()
        {
            Console.SetCursorPosition(10, 10);
            Gra gra = new Gra();
            toMenu = gra.newgameinit();
            Exit = gra.endgame();
            newGame = gra.newgamer();
        }
    }

}

