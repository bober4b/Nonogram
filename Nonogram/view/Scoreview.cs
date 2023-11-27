using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//view
namespace Nonogram.view
{
    public class Scoreview
    {
        private readonly string[] numbers = { " _ \n/ \\\n\\_/",
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
        public void Scorewrite(string score, int scorebad)
        {


            string[] result = new string[4];
            foreach (char number in score)
            {
                if (int.TryParse(number.ToString(), out int x))
                {

                    int y = 0;

                    foreach (string help in numbers[x].Split("\n"))
                    {
                        if (score.Length == 1)
                        {
                            result[y] += "   ";
                        }

                        result[y] += help + " ";
                        y++;
                    }
                }

            }
            int z = 0;
            foreach (string help in numbers[10].Split("\n"))
            {
                result[z] += help;
                z++;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 4; i++)
            {

                Console.SetCursorPosition(10 + 10 * 3 + 25, 10 + 10 / 2 + 2 + i);
                Console.Write(result[i]);
            }


            Console.ForegroundColor = ConsoleColor.Red;

            string[] badresult = Mistakes(scorebad);

            for (int i = 0; i < 4; i++)
            {

                Console.SetCursorPosition(10 + 10 * 3 + 25, 10 + 10 / 2 + 8 + i);
                Console.Write(badresult[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;


        }

        private string[] Mistakes(int scorebad)
        {
            string[] result = new string[4];


            string number2 = $"{scorebad}";

            foreach (char number in number2)
            {
                if (int.TryParse(number.ToString(), out int x))
                {

                    int y = 0;

                    foreach (string help in numbers[x].Split("\n"))
                    {
                        if (number2.Length == 1)
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
    }
}
