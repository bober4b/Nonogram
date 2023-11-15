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

            gameField = new GameField();
            gameField.gameViewTable(height,width);
            gameField.gameViewField(field);
            Random rnd = new Random();
            int seed=rnd.Next();
            colorseter(seed);
            
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
            gameField = new GameField();
            gameField.gameViewTable(height, width);
            gameField.gameViewField(field);
            Random rnd = new Random();
            int seed=rnd.Next();
            colorseter(seed);
        }

        public void play()
        {
            int x = width/2+2;
            int y = height/2+2;

            ConsoleKeyInfo keyInfo;
            do
            {
                Console.SetCursorPosition(x, y);

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        
                            if (y > 1)
                                y-=2;
                            break;
                        
                    case ConsoleKey.DownArrow:
                        if (y < height*2 -2)
                            y+=2;
                        break;

                   case ConsoleKey.LeftArrow:
                        if (x > 4)
                            x-=4;
                        break; 
                    
                   case ConsoleKey.RightArrow:
                        if (x <= width*4 - 4)
                            x+=4;
                        break;
                    case ConsoleKey.Spacebar:
                        if (!field[y/2,x/4].answer())
                        {
                            if (field[y / 2, x / 4].iscolor(true))
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
                        if (!field[y / 2, x / 4].answer())
                        {
                            if (field[y/2,x/4].iscolor(false))
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
