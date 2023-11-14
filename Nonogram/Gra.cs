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
        }
        public Gra(int height, int width)
        {
            this.height = height;
            this.width = width;
        }
        public void gameView()
        {
            string widthstring="╔";
            for(int i = 0;i < width*2-1;i++)
            {
                
                if(i%2==0)
                    widthstring += "═══";
                else
                    widthstring += "╦";
   
            }
                
            widthstring += "╗";
            widthstring += "\n";
            for(int i=0;i < height;i++)
            {
                
                for (int j = 0; j < width*2; j++)
                {
                    if(j%2==0)
                    widthstring += "║";
                    else
                    widthstring += "   ";
                }
                widthstring += "║";

                widthstring += "\n";
                
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

            //Console.WriteLine(field[0,0].ToString());
        }
    }
}
