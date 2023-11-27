using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//module
namespace Nonogram.models
{
    public class Comunicator
    {
        public bool MenuExit { get; set; }
        public bool Exit { get; set; }
        public bool Initer { get; set; }
        public bool Saver { get; set; }

        public Comunicator()
        {
            MenuExit = false;
            Exit = false;
            Initer = false;
            Saver = false;
        }

    }
}
