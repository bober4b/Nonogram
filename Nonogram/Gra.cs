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
        private int scoreprogress;
        private int score;
        private int scorebad;

        private Boolean menuExit=false;

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

            scoreprogress = 0;

            string star = " ##   ## \n  ## ##  \n#########\n  ## ##  \n ##   ## ";
            int h = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string line in star.Split("\n"))
            {
                Console.SetCursorPosition(startx, starty + h);
                Console.Write(line);
                h++;
            }

            Console.ForegroundColor = ConsoleColor.White;
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
                                Console.Write("███");
                                scorecorrect++;
                                score++;
                                scoreprogress++;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x, y);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(x - 1, y);
                                Console.Write("█X█");
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
                                Console.Write("███");
                                Console.ForegroundColor = ConsoleColor.White;
                                score++;
                                Console.SetCursorPosition(x, y);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(x - 1, y);
                                Console.Write("█X█");
                                //WriteConsoleOutputCharacter
                                scorebad++;
                                scoreprogress++;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x, y);
                            }
                            
                            scorewriter();
                        }

                        break;
                    case ConsoleKey.Escape:
                        if(DuringGameMenu())
                        {
                            return;
                        }
                        else
                        break;
                    
                }
                
            } while (1==1);
        }


        private void scorewriter()
        {

             double s = scoreprogress*100/scoretrue ;
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
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0;i < 4;i++)
            {
                
                Console.SetCursorPosition(startx + width * 3 + 25, starty + height / 2 + 2+i);
                Console.Write(result[i]);
            }
            

            Console.ForegroundColor = ConsoleColor.Red;

            string[] badresult = mistakes();

            for (int i = 0; i < 4; i++)
            {
                
                Console.SetCursorPosition(startx + width * 3 + 25, starty + height / 2 + 8 + i);
                Console.Write(badresult[i]);
            }

            //Console.SetCursorPosition(startx + width * 3 + 26, starty + height / 2 + 8);
            //Console.Write("Mistakes");

        }

        private string[] mistakes()
        {
            string[] result = new string[4];


            string number2 = $"{((int)scorebad)}";
            
            foreach (Char number in number2)
            {
                if (int.TryParse(number.ToString(), out int x))
                {

                    int y = 0;

                    foreach (string help in numbers[x].Split("\n"))
                    {
                        if(number2.Length ==1)
                        {
                            result[y] = "   ";
                        }

                        if (number2.Length == 2)
                            {
                                result[y] += " ";
                            }

                        result[y] += help + " ";
                        y++;
                    }
                    
                }

            }

            return result;
        }


        public void ConsoleInGameMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo=("  _   _   ____   _   _   ____    _____  _____             __  __ \r\n | \\ | | / __ \\ | \\ | | / __ \\  / ____||  __ \\     /\\    |  \\/  |\r\n |  \\| || |  | ||  \\| || |  | || |  __ | |__) |   /  \\   | \\  / |\r\n | . ` || |  | || . ` || |  | || | |_ ||  _  /   / /\\ \\  | |\\/| |\r\n | |\\  || |__| || |\\  || |__| || |__| || | \\ \\  / ____ \\ | |  | |\r\n |_| \\_| \\____/ |_| \\_| \\____/  \\_____||_|  \\_\\/_/    \\_\\|_|  |_|\r\n");
            int index = 0;
            foreach (string line in logo.Split("\n"))
            {
                Console.SetCursorPosition(width+1, index);
                Console.Write(line);
                index++;
            }

            Console.SetCursorPosition(startx + width * 3 + 21, starty + height / 2 + 6);
            Console.Write("-------------------");

            Console.SetCursorPosition(startx + width * 3 + 21, starty + height / 2 + 12);
            Console.Write("-------------------");

            

            

            for (int i = 0;i<5;i++)
            {
                Console.SetCursorPosition(startx + width, starty + height + 16+i);
                Console.Write("║");
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
                Console.Write("║");
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
            Console.Write("Poprawne pola \t Niepoprawne pola");
            Console.SetCursorPosition(startx + width + 1+3, starty + height + 16+1);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("███");
            Console.SetCursorPosition(startx + width + 1 + 7, starty + height + 16 + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("███");

            Console.SetCursorPosition(startx + width + 1 + 24, starty + height + 16 + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("█X█");
            Console.SetCursorPosition(startx + width + 1 + 28, starty + height + 16 + 1);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("█X█");


            Console.SetCursorPosition(startx + width * 3 + 26, starty +height/2+1 );
            Console.Write("Progress");

            Console.SetCursorPosition(startx + width * 3 + 26, starty + height / 2 + 7);
            Console.Write("Mistakes");

            Console.SetCursorPosition(startx + width + 8, starty + height + 18);

            Console.Write(" \t\tsterowanie");

            Console.SetCursorPosition(startx + width + 6, starty + height + 19);
            Console.Write("↑\t Niebieskie pole- SPC\tMenu- ESC");
            Console.SetCursorPosition(startx + width + 4, starty + height + 20);
            Console.Write("<-↓->\t Zielone pole- M");



            Console.SetCursorPosition(startx + width*6 - 4, starty + height + 10);
            Console.Write("Continue");
            Console.SetCursorPosition(startx + width * 6 - 4, starty + height + 11);
            Console.Write("New Game");
            Console.SetCursorPosition(startx + width * 6 -6, starty + height + 12);
            Console.Write("Exit to Menu");
            Console.SetCursorPosition(startx + width * 6 - 2, starty + height + 13);
            Console.Write("Exit");


            Console.SetCursorPosition(0, 0);
            scorewriter();

            Play();
        }

        public Boolean DuringGameMenu()
        {
            int opt = 0;
            
            ConsoleKeyInfo keyInfo;
            do
            {
                if(opt<2)
                Console.SetCursorPosition(startx + width * 6 - 4, starty + height + 10+opt);
                if(opt==2)
                    Console.SetCursorPosition(startx + width * 6 - 6, starty + height + 12);
                if(opt==3)
                    Console.SetCursorPosition(startx + width * 6 - 2, starty + height + 13);

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

                        if(opt==0)
                        {
                            return false;
                        }
                        if(opt==1)
                        {
                            newgameinit();
                        }
                        if (opt == 2)
                        {
                            menuExit=true;
                            return true;
                        }
                            
                        if (opt==3)
                            return true;
                        break;
                    case ConsoleKey.Spacebar:
                        if (opt == 0)
                        {
                            return false;
                        }
                        if (opt == 1)
                        {
                            newgameinit();
                        }
                        if (opt == 2)
                        {
                            menuExit = true;
                            return true;
                        }
                        if (opt == 3)
                            return true;
                        break;

                }

            } while (1==1);
        }


        private void newgameinit()
        {

        }
        
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo = ("  _   _   ____   _   _   ____    _____  _____             __  __ \r\n | \\ | | / __ \\ | \\ | | / __ \\  / ____||  __ \\     /\\    |  \\/  |\r\n |  \\| || |  | ||  \\| || |  | || |  __ | |__) |   /  \\   | \\  / |\r\n | . ` || |  | || . ` || |  | || | |_ ||  _  /   / /\\ \\  | |\\/| |\r\n | |\\  || |__| || |\\  || |__| || |__| || | \\ \\  / ____ \\ | |  | |\r\n |_| \\_| \\____/ |_| \\_| \\____/  \\_____||_|  \\_\\/_/    \\_\\|_|  |_|\r\n");
            int index = 0;
            foreach (string line in logo.Split("\n"))
            {
                Console.SetCursorPosition(width + 1, index);
                Console.Write(line);
                index++;
            }
            Console.ForegroundColor= ConsoleColor.White;

            //Console.SetCursorPosition(40, 10);
            index = 0;
            string ng=("             __         \n|\\| _       /__ _ __  _ \n| |(/_\\^/   \\_|(_||||(/_");
            foreach(string line in ng.Split("\n"))
            {
                Console.SetCursorPosition(13, 10+index);
                Console.Write(line);
                index++;
            }
            string ex = " __                     \n|_     o _|_            \n|__><  |  |_            ";
            index = 0;
            //Console.Write("Exit");

            int opt = 0;

            foreach (string line in ex.Split("\n"))
            {
                Console.SetCursorPosition(13, 13 + index);
                Console.Write(line);
                index++;
            }

            ConsoleKeyInfo keyInfo;
            do
            {
                if (opt == 0)
                    Console.SetCursorPosition(13, 12);
                if(opt == 1)
                    Console.SetCursorPosition(13, 15);

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
                            newgameinit();
                        }
                        if (opt == 1)
                            return ;
                        
                        break;
                    case ConsoleKey.Spacebar:
                        if (opt == 0)
                        {
                            newgameinit();
                        }
                        if (opt == 1)
                            return;
                        break;

                }

            } while (1 == 1);

        }
    }
}
