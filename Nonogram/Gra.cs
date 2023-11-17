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
            Random rnd = new Random(seed);
            for(int i = 0; i < height;i++)
                for(int k = 0; k < width;k++)
                {
                    if (rnd.NextDouble()<0.6)
                        field[i, k].setcolor(true);
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

        public void Play()
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
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x, y);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(x - 1, y);
                                Console.WriteLine("█X█");
                                //WriteConsoleOutputCharacter
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x, y);
                            }
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
                                Console.SetCursorPosition(x, y);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(x - 1, y);
                                Console.WriteLine("█X█");
                                //WriteConsoleOutputCharacter
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x, y);
                            }
                        }

                        break;
                    
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
        
    }
}
