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
        public Boolean menuExit { get; set; }
        public Boolean Exit { get; set; }
        public Boolean initer { get; set; }

        public Comunicator()
        {
            menuExit = false;
            Exit = false;
            initer = false;
        }

    }
}
