using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//controler
namespace Nonogram
{
    internal class Hinter
    {
        private string[,] hintListTop;
        private string[,] hintListLeft;

        public Hinter(Field[,] field )
        {
            hintseterTop(field);
            hintseterLeft(field);
        }
        private void hintseterTop(Field[,] field)
        {
            hintListTop = new string[field.GetLength(0) / 2 + field.Length % 2, field.GetLength(1)];

            for (int i = 0; i < field.GetLength(1); i++)
            {
                int current = 0;
                int numbertop = 0;

                //string numberstring = "";
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    if (field[j, i].getcolor())
                    {
                        numbertop++;

                    }
                    else
                    {
                        if (numbertop != 0)
                        {
                            hintListTop[current, i] = $"{numbertop}";
                            numbertop = 0;
                            current++;

                        }
                    }


                }
                if (numbertop != 0)
                {
                    hintListTop[current, i] = $"{numbertop}";
                }
                //hintListTop[i] = numberstring;
            }
        }
        public string[] hintGeterTop(int index)
        {
            string[] result = new string[hintListTop.GetLength(1)];
            for (int i = 0; i < hintListTop.GetLength(1); i++)
            {
                if (hintListTop[index, i] != null)
                    result[i] = hintListTop[index, i];
                else
                {
                    result[i] = " ";
                }
            }
            return result;

        }
        private void hintseterLeft(Field[,] field)
        {
            hintListLeft = new string[ field.GetLength(0) , field.GetLength(1)/2+field.GetLength(1)%2];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                int current = 0;
                int numberleft = 0;

                //string numberstring = "";
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j].getcolor())
                    {
                        numberleft++;

                    }
                    else
                    {
                        if (numberleft != 0)
                        {
                            hintListLeft[i, current] = $"{numberleft}";
                            numberleft = 0;
                            current++;

                        }
                    }


                }
                if (numberleft != 0)
                {
                    hintListLeft[i, current] = $"{numberleft}";
                }
                //hintListTop[i] = numberstring;
            }

        }

        public string[] hintGeterLeft(int index)
        {
            string[] result = new string[hintListLeft.GetLength(1)];
            for (int i = 0; i < hintListLeft.GetLength(1); i++)
            {
                if (hintListLeft[index, i] != null)
                    result[i] = hintListLeft[index, i];
                else
                {
                    result[i] = " ";
                }
            }
            return result;

        }
    } 
}
