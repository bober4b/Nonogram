using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram
{
    

    public class Gra
    {
        private int height;
        private int width;

        private int startx=10;
        private int starty=10;

        private int scoretrue;
        private int scoreall;
        private int scorecorrect;
        private int score;
        private int scorebad;

        private string[] numbers = { " _ \n/ \\\n\\_/",
                                 "   \n/| \n | \n  ",
                                 "__ \n _)\n/__",
                                 "__ \n__)\n__)",
                                 "   \n|_|\n  |",
                                 " __\n|_ \n__)",
                                 " _ \n|_ \n|_)",
                                 " __\n  /\n / ",
                                 " _ \n(_)\n(_)",
                                 " _ \n(_|\n _|",
                                 " \nO/ \n/O"};


        private static Field[,] field;
        private static GameField gameField;

        public Gra()
        {
            height = 10; 
            width = 10;
            field=new Field[height,width];
            for(int i = 0; i < height; i++)
                for(int j = 0; j < width; j++)
                {
                    field[i, j] = new Field();
                }
            Console.SetCursorPosition(startx,starty);
            gameField = new GameField();

            gameField.GamehintTable(field);
            Random rnd = new Random();
            int seed = rnd.Next();
            colorseter(seed);
            gameField.gameTable(height,width);
            
            
        }

        private void colorseter(int seed)
        {
            this.scoreall = new();
            this.scoreall=height*width;
            this.scorecorrect = 0;
            this.scorebad = 0;
            Random rnd = new Random(seed);
            for(int i = 0; i < height;i++)
                for(int k = 0; k < width;k++)
                {
                    if (rnd.NextDouble()<0.6)
                    {
                        field[i, k].setcolor(true);
                        scoretrue++;
                    }
                    else
                        field[i, k].setcolor(false);
                }
        }
        public Gra(int height, int width)
        {
            this.height = height;
            this.width = width;
            
            field = new Field[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    field[i, j] = new Field();
                }
            Console.SetCursorPosition(startx, starty);
            gameField = new GameField();

            Random rnd = new Random();
            int seed = rnd.Next();
            colorseter(seed);

            //gameField.GamehintTable(field);
           // gameField.gameTable(height, width);
           // gameField.gameViewTable(startx,starty);

            
            
        }

        private void Play()
        {
            int x = startx+width+width%2+2;
            int y = starty+1+height/2+height % 2;
            int arrayx = 0;
            int arrayy = 0;
            int leftview=starty+width + width % 2+4;
            int topview=startx+1+height/2 + height % 2;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            gameField.GamehintTable(field);
            gameField.gameTable(height, width);
            gameField.gameViewTable(startx,starty);
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(x, y);


            ConsoleKeyInfo keyInfo;
            do
            {
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
                        if (x <= leftview+width*4 - 8)
                        {
                            x += 4;
                            arrayx++;
                        }
                            
                        break;
                    case ConsoleKey.Spacebar:
                        if (!field[arrayy,arrayx].answer())
                        {
                            if (field[arrayy,arrayx].iscolor(true))
                            {
                                
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.SetCursorPosition(x - 1, y);
                                Console.WriteLine("███");
                                scorecorrect++;
                                score++;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x, y);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(x - 1, y);
                                Console.WriteLine("█X█");
                                scorebad++;
                                //WriteConsoleOutputCharacter
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x, y);
                            }
                            scorewriter();
                        }
                        break;
                    case ConsoleKey.M:
                        if (!field[arrayy, arrayx].answer())
                        {
                            if (field[arrayy, arrayx].iscolor(false))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x - 1, y);
                                Console.WriteLine("███");
                                Console.ForegroundColor = ConsoleColor.White;
                                score++;
                                Console.SetCursorPosition(x, y);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(x - 1, y);
                                Console.WriteLine("█X█");
                                //WriteConsoleOutputCharacter
                                scorebad++;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x, y);
                            }
                            scorewriter();
                        }

                        break;
                    
                }
                
            } while (keyInfo.Key != ConsoleKey.Escape);
        }


        private void scorewriter()
        {

             double s = scorecorrect*100/scoretrue ;
            string number2 = $"{((int)s)}";
            string[] result = new string[4];
            foreach (Char number in number2)
            { 
                if(int.TryParse(number.ToString(), out int x) )
                {
                    
                    int y = 0;

                    

                    foreach (string help in  numbers[x].Split("\n"))
                    {
                        if (number2.Length == 1)
                        {
                            result[y] += "   ";
                        }

                        result[y] += help+" ";
                        y++;
                    }
                }

            }
            int z=0 ;   
            foreach(string help in numbers[10].Split("\n"))
            {
                result[z] +=help;
                z++;
            }
            for(int i = 0;i < 4;i++)
            {
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.SetCursorPosition(startx + width * 3 + 25, starty + height / 2 + 2+i);
                Console.WriteLine(result[i]);
            }
        }

        public void ConsoleGameMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo=("  _   _   ____   _   _   ____    _____  _____             __  __ \r\n | \\ | | / __ \\ | \\ | | / __ \\  / ____||  __ \\     /\\    |  \\/  |\r\n |  \\| || |  | ||  \\| || |  | || |  __ | |__) |   /  \\   | \\  / |\r\n | . ` || |  | || . ` || |  | || | |_ ||  _  /   / /\\ \\  | |\\/| |\r\n | |\\  || |__| || |\\  || |__| || |__| || | \\ \\  / ____ \\ | |  | |\r\n |_| \\_| \\____/ |_| \\_| \\____/  \\_____||_|  \\_\\/_/    \\_\\|_|  |_|\r\n");
            int index = 0;
            foreach (string line in logo.Split("\n"))
            {
                Console.SetCursorPosition(width+1, index);
                Console.WriteLine(line);
                index++;
            }
                
            for (int i = 0;i<5;i++)
            {
                Console.SetCursorPosition(startx + width, starty + height + 16+i);
                Console.WriteLine("║");
            }
            Console.SetCursorPosition(startx + width, starty + height + 21);
            Console.Write("╚");

            for(int i = 0; i< startx + width*3-1+20; i++)
            {
                Console.SetCursorPosition(startx + width+i+1, starty + height + 21);
                Console.Write("═");
            }
            Console.SetCursorPosition(startx + width * 3  + 40, starty + height + 21);
            Console.Write("╝");

            for (int i = 0; i<startx+height+5; i++) 
            {
                Console.SetCursorPosition(startx + width*3 + 40, starty + height +i-4);
                Console.WriteLine("║");
            }
            Console.SetCursorPosition(startx + width * 3 + 40, starty + height -5);
            Console.Write("╗");

            for (int i = 0; i < startx + width * 3 +20; i++)
            {
                Console.SetCursorPosition(startx + width +i, starty + height/2 );
                Console.Write("═");
            }

            Console.SetCursorPosition(startx + width + 1, starty + height + 16);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Poprawne pola \t Niepoprawne pola");
            Console.SetCursorPosition(startx + width + 1+3, starty + height + 16+1);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("███");
            Console.SetCursorPosition(startx + width + 1 + 7, starty + height + 16 + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("███");

            Console.SetCursorPosition(startx + width + 1 + 24, starty + height + 16 + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("█X█");
            Console.SetCursorPosition(startx + width + 1 + 28, starty + height + 16 + 1);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("█X█");


            Console.SetCursorPosition(startx + width * 3 + 28, starty +height/2+1 );
            Console.WriteLine("SCORE");
            Console.SetCursorPosition(startx + width * 3 + 30, starty + height / 2 + 3);
            //Console.WriteLine(score);
            Console.SetCursorPosition(0, 50);
            scorewriter();

            Play();
        }
        
    }
}
