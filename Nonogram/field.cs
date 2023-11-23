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
        public Boolean Iscolor(Boolean color)
        {
            answered = true;
            if (this.color == color)
            { _answer = true; return true; }
            else { _answer = false; return false; }
        }
        public void Setcolor(Boolean color) 
        {
            this.color = color;
        }
        public Boolean Getcolor()
        {
            return this.color;
        }

        public Boolean Answer()
        {
            return answered;
        }

        public void Setanswered(Boolean answered)
        {
            this.answered=answered;
        }
        public void Set_answer(Boolean _answer)
        {
             this._answer=_answer;
        }
        public Boolean Get_answer()
        {
            return _answer;
        }
        
        public override string ToString()
        {
            return $"{color},{answered},{_answer}";
        }
        
    }
}
