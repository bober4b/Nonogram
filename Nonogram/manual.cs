using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
//controler/manual
namespace Nonogram
{
    public class Manual
    {
        private readonly int width;
        private readonly int height;

        private readonly Field[,] field;
        private readonly Scoremodule score;
        private readonly Comunicator comunicator;

        

        private int x;
        private int y;
        private int arrayx ;
        private int arrayy ;
        private readonly int leftview;
        private readonly int topview;

        public Manual(int width, int height, Field[,] field, Scoremodule score,Comunicator comunicator)
        {
            this.width = width;
            this.height = height;
            this.field = field;
            this.score = score;
            this.comunicator = comunicator;

            

            x = 10 + width + width % 2 + 2;
            y = 10 + 1 + height / 2 + height % 2;
            arrayx = 0;
            arrayy = 0;
            leftview = 10 + width + width % 2 + 4;
            topview = 10 + 1 + height / 2 + height % 2;
        }
        public Boolean[] Controlsgame()
        {




            bool[] result=new bool[2];

            result[0] = true;  // koniec gry?
            result[1] = false; // zaznaczenie pola?


            ConsoleKeyInfo keyInfo;
            Console.SetCursorPosition(x, y);

            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:

                    if (y > topview)
                    {
                        y -= 2;
                        arrayy--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (y < topview + height * 2 - 2)
                    {
                        y += 2;
                        arrayy++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (x > leftview)
                    {
                        x -= 4;
                        arrayx--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (x <= leftview + width * 4 - 8)
                    {
                        x += 4;
                        arrayx++;
                    }

                    break;
                case ConsoleKey.Spacebar:
                    if (!field[arrayy, arrayx].Answer())
                    {
                        if (field[arrayy, arrayx].Iscolor(true))
                        {


                            score.Scorecorrect++;
                            score.Score++;
                            score.Scoreprogress++;

                            Fieldseter.Set(x, y, true, ConsoleColor.DarkBlue);
                        }
                        else
                        {
                            
                            score.Scorebad++;
                            Fieldseter.Set(x, y, false, ConsoleColor.Red);

                        }

                        result[1] = true;
                    }
                    break;
                case ConsoleKey.M:
                    if (!field[arrayy, arrayx].Answer())
                    {
                        if (field[arrayy, arrayx].Iscolor(false))
                        {

                            score.Score++;

                            Fieldseter.Set(x,y,true, ConsoleColor.Green);

                        }
                        else
                        {


                            score.Scorebad++;
                            score.Scoreprogress++;
                            Fieldseter.Set(x,y, false, ConsoleColor.DarkGray);

                        }

                        result[1] = true;
                    }

                    break;
                case ConsoleKey.Escape:
                    if (DuringGameMenu())
                    {
                        result[0] = false;
                        return result;
                    }
                    else
                        break;
            }
            return result;
        }


        private Boolean DuringGameMenu()
        {
            int opt = 0;
            MenuingameView menuingameView = new();

            ConsoleKeyInfo keyInfo;
            do
            {
                menuingameView.Options(opt);

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
                        if (opt < 4)
                        {
                            opt++;
                        }
                        break;

                    case ConsoleKey.Enter:

                        if (opt == 0)
                            if (opt == 0)
                            {
                                return false;
                            }
                        if (opt == 1)
                        {
                            comunicator.Saver = true;
                            GameField.Saved();
                            break ;
                        }
                        if (opt == 2)
                        {
                            comunicator.Initer = true;
                            return false;
                        }
                        if (opt == 3)
                        {
                            comunicator.MenuExit = true;
                            return true;
                        }
                        if (opt == 4)
                        {
                            comunicator.Exit = true;
                            return true;
                        }
                        break;


                    case ConsoleKey.Spacebar:
                        if (opt == 0)
                        {
                            return false;
                        }
                        if ( opt==1 )
                        {
                            comunicator.Saver= true;
                            GameField.Saved();
                            break;
                        }
                        if (opt == 2)
                        {
                            comunicator.Initer = true;
                            return true;
                        }
                        if (opt == 3)
                        {
                            comunicator.MenuExit = true;
                            return true;
                        }
                        if (opt == 4)
                        {
                            comunicator.Exit = true;
                            return true;
                        }

                        break;

                }

            } while (1 == 1);
        }
    }
    //View
    public class MenuingameView
    {
        private readonly int position = 10;
        private readonly int width = 10;
        private readonly int height = 10;
        public void Options(int opt)
        {

            if (opt == 0)
                Console.SetCursorPosition(position + width * 6 - 4, position + height + 10);
            if (opt == 1)
                Console.SetCursorPosition(position + width * 6 - 2, position + height + 11);
            if (opt == 2)
                Console.SetCursorPosition(position + width * 6 - 4, position + height + 12);
            if (opt == 3)
                Console.SetCursorPosition(position + width * 6 - 6, position + height + 13);
            if (opt == 4)
                Console.SetCursorPosition(position + width * 6 - 2, position + height + 14);
        }


    }
}
