using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmlyLocomotive
{
    class Class1
    {
        private int steps=0;

        public int Steps
        {
            private get
            {
                return steps;
            }
            set { steps = value; }
        }

        public int Step()
        {
            Steps++;
            return Steps;
        }
    }
}
