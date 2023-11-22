using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//module
namespace Nonogram
{
    public class Score
    {
        public int scoretrue { get; set; }
        public int scoreall { get; set; }
        public int scorecorrect { get; set; }
        public int scoreprogress { get; set; }
        public int score { get; set; }
        public int scorebad { get; set; }

        public override string ToString()
        {
            return $"{scoretrue},{scoreall},{scorecorrect},{scoreprogress},{score},{scorebad}";
        }
    }
}
