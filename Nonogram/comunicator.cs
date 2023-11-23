using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//module
namespace Nonogram
{
    public class Comunicator
    {
        public Boolean MenuExit { get; set; }
        public Boolean Exit { get; set; }
        public Boolean Initer { get; set; }
        public Boolean Saver { get; set; }

        public Comunicator()
        {
            MenuExit = false;
            Exit = false;
            Initer = false;
            Saver = false;
        }

    }
}
