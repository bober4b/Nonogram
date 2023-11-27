using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


//module
namespace Nonogram.models
{
    public class Field
    {
        private bool color;
        private bool answered;
        private bool _answer;
        public Field()
        {
            color = false;
            answered = false;
        }
        public Field(bool color)
        {
            this.color = color;
            answered = false;
        }
        public bool Iscolor(bool color)
        {
            answered = true;
            if (this.color == color)
            { _answer = true; return true; }
            else { _answer = false; return false; }
        }
        public void Setcolor(bool color)
        {
            this.color = color;
        }
        public bool Getcolor()
        {
            return color;
        }

        public bool Answer()
        {
            return answered;
        }

        public void Setanswered(bool answered)
        {
            this.answered = answered;
        }
        public void Set_answer(bool _answer)
        {
            this._answer = _answer;
        }
        public bool Get_answer()
        {
            return _answer;
        }

        public override string ToString()
        {
            return $"{color},{answered},{_answer}";
        }

    }
}
