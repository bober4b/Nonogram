using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nonogram.controls;
using Nonogram.models;


//view
namespace Nonogram.view
{

    public class GameField
    {
        private string[]? widthstring;
        private Hinter hinter;




        public void GameTable(int height, int width)
        {
            // Inicjalizacja widthstring jako tablicy
            widthstring = new string[27];
            //string[] hint = hinter.hintGeterTop();


            // Aktualna pozycja w tablicy widthstring
            int currentPosition = 0;
            for (int i = 0; i < height / 2; i++)
            {
                string[] help = hinter.HintGeterTop(i);
                for (int j = 0; j < width + width % 2; j++)
                    widthstring[currentPosition] += " ";


                for (int j = 0; j < width * 2 + 1; j++)
                {
                    if (j % 2 == 0)
                        widthstring[currentPosition] += "│";
                    else
                    {
                        if (help[j / 2].Length == 1)
                            widthstring[currentPosition] += $" {help[j / 2]} ";
                        else
                            widthstring[currentPosition] += $" {help[j / 2]}";
                    }

                }
                widthstring[currentPosition] += "\n";
                currentPosition++;

            }





            widthstring[currentPosition] += GameViewHintLeft(height, true, currentPosition - height / 2 - height % 2);
            widthstring[currentPosition] += "╔";

            for (int i = 0; i < width * 2 - 1; i++)
            {
                if (i % 2 == 0)
                    widthstring[currentPosition] += "═══";
                else
                    widthstring[currentPosition] += "╦";
            }

            widthstring[currentPosition] += "╦";
            widthstring[currentPosition] += "\n";
            currentPosition++;
            widthstring[currentPosition] += GameViewHintLeft(height, false, 0);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width * 2; j++)
                {

                    if (j % 2 == 0)
                        widthstring[currentPosition] += "║";
                    else
                        widthstring[currentPosition] += "███";
                }
                widthstring[currentPosition] += "║\n";
                currentPosition++;

                widthstring[currentPosition] += GameViewHintLeft(height, true, -1);

                if (i < height - 1)
                {
                    widthstring[currentPosition] += "╠";
                    for (int j = 0; j < width * 2 - 1; j++)
                    {
                        if (j % 2 == 0)
                            widthstring[currentPosition] += "═══";
                        else
                            widthstring[currentPosition] += "╬";
                    }
                    widthstring[currentPosition] += "╣\n";
                    currentPosition++;
                    widthstring[currentPosition] += GameViewHintLeft(height, false, i + 1);
                }
                else
                {
                    widthstring[currentPosition] += "╠";
                    for (int j = 0; j < width * 2 - 1; j++)
                    {
                        if (j % 2 == 0)
                            widthstring[currentPosition] += "═══";
                        else
                            widthstring[currentPosition] += "╩";
                    }
                    widthstring[currentPosition] += "╝";
                }
            }



        }
        public void GametableView(int startx, int starty, bool loaded, Field[,] field)
        {
            Console.Clear();
            int z = 0;

            foreach (string line in widthstring)
            {
                Console.SetCursorPosition(startx, starty + z);

                z++;
                Console.Write(line);
            }
            if (loaded)
            {
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        if (field[i, j].Answer())
                        {
                            if (field[i, j].Get_answer())
                            {
                                if (field[i, j].Getcolor())
                                {
                                    Fieldseter.Set(startx + j * 4 + 12, starty + i * 2 + 6, true, ConsoleColor.DarkBlue);
                                }
                                else
                                {
                                    Fieldseter.Set(startx + j * 4 + 12, starty + i * 2 + 6, true, ConsoleColor.Green);
                                }
                            }
                            else
                            {

                                if (field[i, j].Getcolor())
                                {
                                    Fieldseter.Set(startx + j * 4 + 12, starty + i * 2 + 6, false, ConsoleColor.DarkGray);
                                }
                                else
                                {
                                    Fieldseter.Set(startx + j * 4 + 12, starty + i * 2 + 6, false, ConsoleColor.Red);
                                }

                            }
                        }
                        else
                        {
                            Fieldseter.Set(startx + j * 4 + 12, starty + i * 2 + 6, true, ConsoleColor.White);
                        }
                    }
            }


            string star = " ##   ## \n  ## ##  \n#########\n  ## ##  \n ##   ## ";
            Console.SetCursorPosition(10, 10);
            int h = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string line in star.Split("\n"))
            {
                Console.SetCursorPosition(startx, starty + h);
                Console.Write(line);
                h++;
            }

            string logo = "  _   _   ____   _   _   ____    _____  _____             __  __ \r\n | \\ | | / __ \\ | \\ | | / __ \\  / ____||  __ \\     /\\    |  \\/  |\r\n |  \\| || |  | ||  \\| || |  | || |  __ | |__) |   /  \\   | \\  / |\r\n | . ` || |  | || . ` || |  | || | |_ ||  _  /   / /\\ \\  | |\\/| |\r\n | |\\  || |__| || |\\  || |__| || |__| || | \\ \\  / ____ \\ | |  | |\r\n |_| \\_| \\____/ |_| \\_| \\____/  \\_____||_|  \\_\\/_/    \\_\\|_|  |_|\r\n";
            int index = 0;
            foreach (string line in logo.Split("\n"))
            {
                Console.SetCursorPosition(11, index);
                Console.Write(line);
                index++;
            }


            Console.ForegroundColor = ConsoleColor.Cyan;

            int position = 10;

            Console.SetCursorPosition(startx + position * 3 + 21, starty + position / 2 + 6);
            Console.Write("-------------------");

            Console.SetCursorPosition(startx + position * 3 + 21, starty + position / 2 + 12);
            Console.Write("-------------------");





            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(startx + position, starty + position + 16 + i);
                Console.Write("║");
            }
            Console.SetCursorPosition(startx + position, starty + position + 21);
            Console.Write("╚");

            for (int i = 0; i < startx + position * 3 - 1 + 20; i++)
            {
                Console.SetCursorPosition(startx + position + i + 1, starty + position + 21);
                Console.Write("═");
            }
            Console.SetCursorPosition(startx + position * 3 + 40, starty + position + 21);
            Console.Write("╝");

            for (int i = 0; i < startx + position + 5; i++)
            {
                Console.SetCursorPosition(startx + position * 3 + 40, starty + position + i - 4);
                Console.Write("║");
            }
            Console.SetCursorPosition(startx + position * 3 + 40, starty + position - 5);
            Console.Write("╗");

            for (int i = 0; i < startx + position - 1; i++)
            {
                Console.SetCursorPosition(startx + position * 5 + 1 + i, starty + position / 2);
                Console.Write("═");
            }

            Console.SetCursorPosition(startx + position + 1, starty + position + 16);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Poprawne pola \t Niepoprawne pola");
            Console.SetCursorPosition(startx + position + 1 + 3, starty + position + 16 + 1);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("███");
            Console.SetCursorPosition(startx + position + 1 + 7, starty + position + 16 + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("███");

            Console.SetCursorPosition(startx + position + 1 + 24, starty + position + 16 + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("█X█");
            Console.SetCursorPosition(startx + position + 1 + 28, starty + position + 16 + 1);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("█X█");


            Console.SetCursorPosition(startx + position * 3 + 26, starty + position / 2 + 1);
            Console.Write("Progress");

            Console.SetCursorPosition(startx + position * 3 + 26, starty + position / 2 + 7);
            Console.Write("Mistakes");

            Console.SetCursorPosition(startx + position + 8, starty + position + 18);

            Console.Write(" \t\tsterowanie");

            Console.SetCursorPosition(startx + position + 6, starty + position + 19);
            Console.Write("↑\t Niebieskie pole- SPC\tMenu- ESC");
            Console.SetCursorPosition(startx + position + 4, starty + position + 20);
            Console.Write("<-↓->\t Zielone pole- M");



            Console.SetCursorPosition(startx + position * 6 - 4, starty + position + 10);
            Console.Write("Continue");
            Console.SetCursorPosition(startx + position * 6 - 2, starty + position + 11);
            Console.Write("Save");
            Console.SetCursorPosition(startx + position * 6 - 4, starty + position + 12);
            Console.Write("New Game");
            Console.SetCursorPosition(startx + position * 6 - 6, starty + position + 13);
            Console.Write("Exit to Menu");
            Console.SetCursorPosition(startx + position * 6 - 2, starty + position + 14);
            Console.Write("Exit");
        }

        public void GamehintTable(Field[,] field)
        {
            hinter = new Hinter(field);



        }

        private string GameViewHintLeft(int height, bool index, int current)
        {
            string left = "";
            string[] help;
            if (current == -1)
            {
                for (int i = 0; i < height / 2 + height % 2; i++)
                {
                    if (index)
                        left += "──";
                    else
                        left += "   ";
                }

                return left;
            }



            help = hinter.HintGeterLeft(current);

            for (int i = 0; i < height / 2 + height % 2; i++)
            {
                if (index)
                    left += "──";
                else
                {


                    if (help[i] != null)
                        if (help[i].Length == 1)
                            left += $"{help[i]} ";
                        else left += $"{help[i]}";
                    else left += "";

                }

            }
            return left;
        }

        public static void Gamefinish(int scorebad, int score)
        {
            for (int i = 0; i < 19; i++)
            {
                Console.SetCursorPosition(21, 16 + i);
                Console.Write(new string(' ', 39));
            }
            string end = "LEVEL COMPLETED";
            Console.SetCursorPosition(33, 23);
            foreach (char character in end.ToCharArray())
            {
                Console.Write(character);
                Thread.Sleep(50);
            }


            string miss = $"Mistakes: {scorebad}";
            Console.SetCursorPosition(35, 24);
            foreach (char character in miss.ToCharArray())
            {
                Console.Write(character);
                Thread.Sleep(50);
            }

            string scr = $"Score: {score}";
            Console.SetCursorPosition(36, 25);
            foreach (char character in scr.ToCharArray())
            {
                Console.Write(character);
                Thread.Sleep(50);
            }
            Thread.Sleep(2000);
            Console.SetCursorPosition(25, 26);
            Console.Write(" Press any key to continue...");
        }

        public static void Saved()
        {
            Console.SetCursorPosition(62, 14);
            string sv = "Game has been saved!";

            foreach (char character in sv.ToCharArray())
            {
                Console.Write(character);
                Thread.Sleep(50);
            }
            Thread.Sleep(500);
            Console.SetCursorPosition(62, 14);
            Console.Write(new string(' ', 24));

        }

    }
}
