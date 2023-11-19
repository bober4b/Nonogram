using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Nonogram
{
    public class Field
    {
        private Boolean color;
        private Boolean answered;
        private Boolean _answer;
        public Field()
        {
            color = false;
            answered = false;
        }
        public Field(Boolean color)
        {
            this.color = color;
            answered = false; 
        }
        public Boolean iscolor(Boolean color)
        {
            answered = true;
            if (this.color == color)
            { _answer = true; return true; }
            else { _answer = false; return false; }
        }
        public void setcolor(Boolean color) 
        {
            this.color = color;
        }
        public Boolean getcolor()
        {
            return this.color;
        }

        public Boolean answer()
        {
            return answered;
        }
        
        public override string ToString()
        {
            if (!answered)
                return "███";
            else
            {
                if (_answer == true)
                    return "███";
                else return "█X█";
            }
        }
        
    }
}
