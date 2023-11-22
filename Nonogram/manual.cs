﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Nonogram
{
    public class Manual
    {
        private int width;
        private int height;

        private Field[,] field;
        private Score score;
        private Comunicator comunicator;

        private Fieldseter fieldset;

        private int x;
        private int y;
        private int arrayx ;
        private int arrayy ;
        private int leftview;
        private int topview;

        public Manual(int width, int height, Field[,] field, Score score,Comunicator comunicator)
        {
            this.width = width;
            this.height = height;
            this.field = field;
            this.score = score;
            this.comunicator = comunicator;

            fieldset = new();

            x = 10 + width + width % 2 + 2;
            y = 10 + 1 + height / 2 + height % 2;
            arrayx = 0;
            arrayy = 0;
            leftview = 10 + width + width % 2 + 4;
            topview = 10 + 1 + height / 2 + height % 2;
        }
        public Boolean[] controlsgame()
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
                    if (!field[arrayy, arrayx].answer())
                    {
                        if (field[arrayy, arrayx].iscolor(true))
                        {


                            score.scorecorrect++;
                            score.score++;
                            score.scoreprogress++;

                            fieldset.set(x, y, true, ConsoleColor.DarkBlue);
                        }
                        else
                        {
                            
                            score.scorebad++;
                            fieldset.set(x, y, false, ConsoleColor.Red);

                        }

                        result[1] = true;
                    }
                    break;
                case ConsoleKey.M:
                    if (!field[arrayy, arrayx].answer())
                    {
                        if (field[arrayy, arrayx].iscolor(false))
                        {

                            score.score++;

                            fieldset.set(x,y,true, ConsoleColor.Green);

                        }
                        else
                        {


                            score.scorebad++;
                            score.scoreprogress++;
                            fieldset.set(x,y, false, ConsoleColor.DarkGray);

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
            int position = 10;

            ConsoleKeyInfo keyInfo;
            do
            {
                if (opt < 2)
                    Console.SetCursorPosition( position + width * 6 - 4, position + height + 10 + opt);
                if (opt == 2)
                    Console.SetCursorPosition(position + width * 6 - 6, position + height + 12);
                if (opt == 3)
                    Console.SetCursorPosition(position + width * 6 - 2, position + height + 13);

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
                        if (opt < 3)
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
                            comunicator.initer = true;
                            return true;
                        }
                        if (opt == 2)
                        {
                            comunicator.menuExit = true;
                            return true;
                        }
                        if (opt == 3)
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
                        if (opt == 1)
                        {
                            comunicator.initer = true;
                            return true;
                        }
                        if (opt == 2)
                        {
                            comunicator.menuExit = true;
                            return true;
                        }
                        if (opt == 3)
                        {
                            comunicator.Exit = true;
                            return true;
                        }

                        break;

                }

            } while (1 == 1);
        }
    }
}
