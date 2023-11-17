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
        private Hinter hinter;

        public void gameTable(int height, int width)
        {
            // Inicjalizacja widthstring jako tablicy
            widthstring = new string[(height + 1) / 2 + height + 1+100];
            //string[] hint = hinter.hintGeterTop();


            // Aktualna pozycja w tablicy widthstring
            int currentPosition = 0;
            for (int i = 0;i<height/2;i++)
            {string[] help=hinter.hintGeterTop(i);
                for (int j = 0; j < width+width%2; j++)
                    widthstring[currentPosition] += " ";

                
                for (int j = 0; j < width * 2+1 ; j++)
                {
                    if (j % 2 == 0)
                        widthstring[currentPosition] += "│";
                    else
                    {
                        if (help[j/2].Length==1)
                            widthstring[currentPosition] += $" {help[j / 2]} ";
                        else
                            widthstring[currentPosition] += $" {help[j / 2]}";
                    }
                        
                }
                widthstring[currentPosition] += "\n";
                currentPosition++;
                    
            }
            




            widthstring[currentPosition] += gameViewHintLeft(width, height, true, currentPosition-height/2-height%2);
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
            widthstring[currentPosition] += gameViewHintLeft(width, height, false, 0);

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

                widthstring[currentPosition] += gameViewHintLeft(width, height, true, -1);

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
                    widthstring[currentPosition] += gameViewHintLeft(width, height, false, i+1);
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
            hinter=new Hinter(field);

            

        }

        private string gameViewHintLeft(int width, int height, Boolean index,int current)
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
                        left += "xD ";
                }
                
                return left;
            }


            
                help = hinter.hintGeterLeft(current);
            
            for (int i=0; i < height/2+height%2; i++)
            { 
                if(index)
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
        
    }
}
