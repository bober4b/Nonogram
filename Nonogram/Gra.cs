using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//controler
namespace Nonogram
{
    

    public class Gra
    {
        private readonly int height;
        private readonly int width;

        private readonly int startx=10;
        private readonly int starty=10;

        private Boolean loaded=false;
        private readonly Scoremodule score=new();

        private readonly Comunicator comunicator=new();

        private readonly Field[,] field;


        private readonly GameField gameField=new();
        private readonly Scoreview scoreview=new();

        public Gra(int seed=0)
        {
            height = 10; 
            width = 10;
            field=new Field[height,width];
            for(int i = 0; i < height; i++)
                for(int j = 0; j < width; j++)
                {
                    field[i, j] = new Field();
                }

            Random rnd = new();
            if(seed==0)
            seed = rnd.Next();
            Colorseter(seed);
            score.Scoreprogress = 0;


        }

        public Gra(string filename)
        {
            height = 10;
            width = 10;
            loaded = true;
            field = new Field[height, width];
            Gamecontinuesave(filename);
        }

        private void Colorseter(int seed)
        {

            score.Scoreall=height*width;
            score.Scorecorrect = 0;
            score.Scorebad = 0;
            Random rnd = new(seed);
            for(int i = 0; i < height;i++)
                for(int k = 0; k < width;k++)
                {
                    if (rnd.NextDouble()<0.6)
                    {
                        field[i, k].Setcolor(true);
                        score.Scoretrue++;
                    }
                    else
                        field[i, k].Setcolor(false);
                }
        }
        

        public void Play()
        {    

            gameField.GamehintTable(field);
            gameField.GameTable(height, width);
            gameField.GametableView(startx,starty,loaded,field);
            loaded = false;


            
            

            Scoreupdate();

            Manual manual=new(width,height,field,score,comunicator);
            
            bool[] result;
            

            do
            {
                result = manual.Controlsgame();


                if (comunicator.Saver)
                {
                    GameSaver();
                    comunicator.Saver = false;
                    
                }

               
                if (result[1])
                {
                    Scoreupdate();
                }

                if (!result[0])
                {
                    return;
                }

                
                
            } while (score.Scoreprogress!=score.Scoretrue);


            GameField.Gamefinish(score.Scorebad, score.Score);
            Console.ReadKey(true);
            return;
        }


        private void Scoreupdate()
        {

            double toscore = score.Scoreprogress * 100 / score.Scoretrue;
            string number = $"{((int)toscore)}";
            scoreview.Scorewrite(number,score.Scorebad);

        }
 

        public Boolean Newgameinit()
        {

            Scoreupdate();

            Play();
            if (score.Score==score.Scoretrue) { return true; }
            return comunicator.MenuExit;
        }
        
        

        public Boolean Endgame()
        {
            return comunicator.Exit;
        }

        public Boolean Newgamer()
        {
            return comunicator.Initer;
        }

        public void GameSaver()
        {
            string filepath = "continue.txt";

            string result = "";
            for(int i = 0; i < 10; i++) 
            {
                for(int j = 0; j < 10; j++)
                {
                    result += $"{field[i, j]}";
                    if(j<9)
                    {
                        result += ",";
                    }
                }
                result += "\n";
            }
            result +=score.ToString();

            File.WriteAllText(filepath,result);


        }

        public void Gamecontinuesave(string path="continue.txt")
        {
            string result = File.ReadAllText(path);

            int z=0 ;
            int i = 0;
            foreach(string line  in result.Split("\n"))
            {
                int j = 0;
                int k = 0;
                foreach (string line2 in line.Split(","))
                {if (j % 3 == 0&& i!=10)
                        field[i, k] = new Field();
                    if (i <= 9)
                    {
                        if (bool.TryParse(line2, out bool boolvalue))
                        {


                            if (j % 3 == 0)
                                field[i, k].Setcolor(boolvalue);

                            if (j % 3 == 1)
                                field[i, k].Setanswered(boolvalue);

                            if (j % 3 == 2)
                                field[i, k].Set_answer(boolvalue);

                        }

                        j++;
                        if (j % 3 == 0)
                            k++;
                    }
                    else
                    {
                        if (int.TryParse(line2, out int intvalue))
                        {
                            switch (z)
                            {
                                case 0:
                                    score.Scoretrue = intvalue;
                                    break;
                                case 1:
                                    score.Scoreall = intvalue;
                                    break;
                                case 2:
                                    score.Scorecorrect = intvalue;
                                    break;
                                case 3:
                                    score.Scoreprogress = intvalue;
                                    break;
                                case 4:
                                    score.Score = intvalue;
                                    break;
                                case 5:
                                    score.Scorebad = intvalue;
                                    break;

                            }

                        }
                        z++;
                    }
                }
                i++;
            }
        }
        
    }
}
