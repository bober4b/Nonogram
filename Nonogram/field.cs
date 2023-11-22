using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


//module
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

        public void setanswered(Boolean answered)
        {
            this.answered=answered;
        }
        public void set_answer(Boolean _answer)
        {
             this._answer=_answer;
        }
        public Boolean get_answer()
        {
            return _answer;
        }
        
        public override string ToString()
        {
            return $"{color},{answered},{_answer}";
        }
        
    }
}
