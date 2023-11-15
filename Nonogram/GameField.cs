using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram
{
    
    public  class GameField
    {
        private string widthstring;
        public void gameViewTable(int height, int width)
        {
            //Console.SetCursorPosition(8, 10);
            for (int i = 0; i < (height + 1) / 2; i++)
            {
                for (int j = 0; j < (width + 1) / 2; j++)
                    widthstring += " ";
                widthstring += "\n";
            }
            widthstring += gameViewHintLeft(width,height,true);
             widthstring += "╔";
            for (int i = 0; i < width * 2 - 1; i++)
            {

                if (i % 2 == 0)
                    widthstring += "═══";
                else
                    widthstring += "╦";

            }

            widthstring += "╗";
            widthstring += "\n";
            widthstring += gameViewHintLeft(width, height, false);
            for (int i = 0; i < height; i++)
            {
                


                for (int j = 0; j < width * 2; j++)
                {
                    if (j % 2 == 0)
                        widthstring += "║";
                    else
                        widthstring += "   ";
                }
                widthstring += "║";


                widthstring += "\n";
                
                    widthstring += gameViewHintLeft(width, height, true);
                


                if (i < height - 1)
                {
                    
                    widthstring += "╠";
                    for (int j = 0; j < width * 2 - 1; j++)
                    {
                        if (j % 2 == 0)
                            widthstring += "═══";
                        else
                            widthstring += "╬";
                    }
                    widthstring += "╣";
                    widthstring += "\n";
                    
                        widthstring += gameViewHintLeft(width, height, false);
                }
                else
                {
                    widthstring += "╚";
                    for (int j = 0; j < width * 2 - 1; j++)
                    {
                        if (j % 2 == 0)
                            widthstring += "═══";
                        else
                            widthstring += "╩";
                    }

                    widthstring += "╝";
                }

            }



            Console.WriteLine(widthstring);
            

            
        }

        public void gameViewField(Field[,] field,int width,int height)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(5, 6);
            for(int i=1; i<field.GetLength(0)*2; i+=2)
                for(int j=6; j<field.GetLength(1)*4+6;j+=4)
                {
                    Console.SetCursorPosition(j, i+8);
                    Console.WriteLine(field[i/2,(j-6)/4].ToString());
                }
            Console.ForegroundColor= ConsoleColor.White;
        }

        private string gameViewHintLeft(int width, int height, Boolean index)
        {
            string left = "";
                

            for(int i=0; i < (width+1)/2; i++)
            {
                if(index)
                    left += "─";
                else
                    left += " ";
            }
            return left;
        }
        private string gameViewHintTop(int width,int height,Boolean index)
        {
            string top = "";
            for (int i = 0; i < (height + 1) / 2; i++)
            {
                for (int j = 0; j < (width + 1) / 2; j++)
                    top += " ";
                top += "\n";
            }

            for (int i = 0; i < (height + 1) / 2; i++)
            {
                if (index)
                    top += "│";
                else
                    top += " ";
            }
            return top;
        }
    }
}
