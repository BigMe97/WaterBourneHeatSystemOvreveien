using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    internal class MyTimer
    {
        public int samplingTime = 1000;
        private DateTime lastStart = DateTime.Now;

        /// <summary>
        /// Allows a looped method to start an iteration at more exact time intervals
        /// by not using the thread sleep method.
        /// </summary>
        /// <param name="samplingTime"></param>
        public MyTimer( int samplingTime)
        {
            this.samplingTime = samplingTime;
        }

        public void Wait()
        {
            DateTime TContinue = lastStart.AddMilliseconds(this.samplingTime);
            while (DateTime.Now < TContinue)
            {
                // Just wait.....
            }
            this.lastStart = DateTime.Now;
            
        }
    }
}
