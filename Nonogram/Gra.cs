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
            Console.SetCursorPosition(startx,starty);

            Random rnd = new Random();
            if(seed==0)
            seed = rnd.Next();
            colorseter(seed);
            
            
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
            gameField.gametableView(startx,starty);



            score.scoreprogress = 0;

            scoreupdate();

            Manual manual=new Manual(width,height,field,score,comunicator);
            
            bool[] result;
            

            do
            {
                result = manual.controlsgame();
                if (result[1])
                {
                    scoreupdate();
                }

                if (!result[0])
                {
                    return;
                }
                
            } while (score.score!=score.scoretrue);
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
    }
}
