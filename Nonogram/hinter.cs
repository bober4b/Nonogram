using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram
{
    internal class Hinter
    {
        private string[] hintListTop ;
        private string[] hintListLeft ;

        public void hintseterTop(Field[,] field)
        {
            hintListTop = new string[field.GetLength(1)];

            for (int i = 0; i < field.GetLength(1); i++)
            {
                int numbertop = 0;
                
                string numberstring = "";
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    if(field[j, i].getcolor() )
                    {
                        numbertop++;
                        
                    }
                    else
                    {
                        if(numbertop!=0 )
                        {
                            numberstring+= $"{numbertop},";
                            numbertop = 0;
                        }
                    }
                    

                }
                hintListTop[i] = numberstring;
            }
        }
        public string[] hintGeterTop()
        { 
            return hintListTop;
        
        }
    }
}
