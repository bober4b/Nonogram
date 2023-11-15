﻿using System;
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
                return true;
            else return false;
        }
        public void setcolor(Boolean color) 
        {
            this.color = color;
        }

        public Boolean answer()
        {
            return answered;
        }
        
        public override string ToString()
        {
            return "███";
        }
        
    }
}