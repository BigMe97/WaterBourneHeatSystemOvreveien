using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    internal class MixingValve
    {
        private double ValvePosition = 0;
        public double UpperLimit = 100;
        public double LowerLimit = 0;
        

        public MixingValve() { }

        public void SetPos(double position)
        {
            this.ValvePosition = position;
        }

        public string GetPos()
        {
            return this.ValvePosition.ToString();
        }
    }
}
