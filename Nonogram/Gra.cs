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
        private int height;
        private int width;

        private int startx=10;
        private int starty=10;

        private Boolean loaded=false;

        Score score=new Score();

        private Comunicator comunicator=new Comunicator();

        private static Field[,] field;


        private static GameField gameField=new();
        private Scoreview scoreview=new();

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

            Random rnd = new Random();
            if(seed==0)
            seed = rnd.Next();
            colorseter(seed);
            score.scoreprogress = 0;


        }

        public Gra(string filename)
        {
            height = 10;
            width = 10;
            loaded = true;
            field = new Field[height, width];
            gamecontinuesave(filename);
        }

        private void colorseter(int seed)
        {

            score.scoreall=height*width;
            score.scorecorrect = 0;
            score.scorebad = 0;
            Random rnd = new Random(seed);
            for(int i = 0; i < height;i++)
                for(int k = 0; k < width;k++)
                {
                    if (rnd.NextDouble()<0.6)
                    {
                        field[i, k].setcolor(true);
                        score.scoretrue++;
                    }
                    else
                        field[i, k].setcolor(false);
                }
        }
        

        public void Play()
        {    

            gameField.GamehintTable(field);
            gameField.gameTable(height, width);
            gameField.gametableView(startx,starty,loaded,field);
            loaded = false;



            

            scoreupdate();

            Manual manual=new Manual(width,height,field,score,comunicator);
            
            bool[] result;
            

            do
            {
                if (comunicator.Saver)
                {
                    gameSaver();
                    comunicator.Saver = false;
                }

                result = manual.controlsgame();
                if (result[1])
                {
                    scoreupdate();
                }

                if (!result[0])
                {
                    return;
                }

                
                
            } while (score.scoreprogress!=score.scoretrue);
            return;
        }


        private void scoreupdate()
        {

            double toscore = score.scoreprogress * 100 / score.scoretrue;
            string number = $"{((int)toscore)}";
            scoreview.scorewrite(number,score.scorebad);

        }
 

        public Boolean newgameinit()
        {

            scoreupdate();

            Play();
            if (score.score==score.scoretrue) { return true; }
            return comunicator.menuExit;
        }
        
        

        public Boolean endgame()
        {
            return comunicator.Exit;
        }

        public Boolean newgamer()
        {
            return comunicator.initer;
        }

        public void gameSaver()
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

        public void gamecontinuesave(string path="continue.txt")
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
                        bool boolvalue;
                        if (bool.TryParse(line2, out boolvalue))
                        {


                            if(j%3==0)
                            field[i, k].setcolor(boolvalue);

                            if (j % 3 == 1)
                                field[i, k].setanswered(boolvalue);

                            if (j % 3 == 2)
                                field[i, k].set_answer(boolvalue);
                            
                        }
                        
                        j++;
                        if (j % 3 == 0)
                            k++;
                    }
                    else
                    {
                        int intvalue;
                        if(int.TryParse(line2,out intvalue))
                        {
                            switch(z)
                            {
                                case 0:
                                    score.scoretrue = intvalue;
                                    break;
                                case 1:
                                    score.scoreall = intvalue;
                                    break;
                                case 2:
                                    score.scorecorrect = intvalue;
                                    break;
                                case 3:
                                    score.scoreprogress=intvalue;
                                    break;
                                case 4:
                                    score.score=intvalue;
                                    break;
                                case 5:
                                    score.scorebad = intvalue;
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
