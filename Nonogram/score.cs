using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//module
namespace Nonogram
{
    public class Scoremodule
    {
        public int Scoretrue { get; set; }
        public int Scoreall { get; set; }
        public int Scorecorrect { get; set; }
        public int Scoreprogress { get; set; }
        public int Score { get; set; }
        public int Scorebad { get; set; }

        public override string ToString()
        {
            return $"{Scoretrue},{Scoreall},{Scorecorrect},{Scoreprogress},{Score},{Scorebad}";
        }
    }
}
