using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram
{
    
    public  class GameField
    {
        private string[] widthstring;
        private Hinter hinter=new Hinter();

        public void gameTable(int height, int width)
        {
            // Inicjalizacja widthstring jako tablicy
            widthstring = new string[(height + 1) / 2 + height + 1+100];
            string[] hint = hinter.hintGeterTop();


            // Aktualna pozycja w tablicy widthstring
            int currentPosition = 0;
            for (int i = 0;i<height/2+height%2;i++)
            {
                for (int j = 0; j < width+width%2; j++)
                    widthstring[currentPosition] += " ";

                
                for (int j = 0; j < width * 2+1 ; j++)
                {
                    if (j % 2 == 0)
                        widthstring[currentPosition] += "│";
                    else
                        widthstring[currentPosition] += "   ";
                }
                widthstring[currentPosition] += "\n";
                currentPosition++;
                    
            }
            widthstring[currentPosition-1].Insert(10, "xsdfsfadfasdadadada");




            widthstring[currentPosition] += gameViewHintLeft(width, height, true);
            widthstring[currentPosition] += "╔";

            for (int i = 0; i < width * 2 - 1; i++)
            {
                if (i % 2 == 0)
                    widthstring[currentPosition] += "═══";
                else
                    widthstring[currentPosition] += "╦";
            }

            widthstring[currentPosition] += "╗";
            widthstring[currentPosition] += "\n";
            currentPosition++;
            widthstring[currentPosition] += gameViewHintLeft(width, height, false);

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

                widthstring[currentPosition] += gameViewHintLeft(width, height, true);

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
                    widthstring[currentPosition] += gameViewHintLeft(width, height, false);
                }
                else
                {
                    widthstring[currentPosition] += "╚";
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

            // Wyświetlanie całej tablicy
            /*foreach (string line in widthstring)
            {
                Console.Write(line);
            }*/
        
        }
        public void gameViewTable(int startx,int starty)
        {
            int i = 0;
            foreach(string line in widthstring)
            {
                Console.SetCursorPosition(startx,starty+i);
                i++;
                Console.WriteLine(line);
            }
        }

        public void GamehintTable(Field[,] field)
        {
            hinter.hintseterTop(field);

            

        }

        private string gameViewHintLeft(int width, int height, Boolean index)
        {
            string left = "";
                

            for(int i=0; i < width+width%2; i++)
            {
                if(index)
                    left += "─";
                else
                    left += " ";
            }
            return left;
        }
        
    }
}
