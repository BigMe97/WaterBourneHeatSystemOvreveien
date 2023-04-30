using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    internal class PumpController
    {
        private MyTimer timer;
        private bool runPump = false;
        private DateTime stopTime = DateTime.MaxValue;
        private DateTime startTime = DateTime.MinValue;

        private int samplingTime = 2000;

        public PumpController() 
        {

        }

        public void Run()
        {
            timer = new MyTimer(samplingTime);
            int i = 0;

            while (UserInterface.run)
            {
                i++;
                UserInterface.Write(3, 0, $"Pump Controller Running... {i}");
                runPump = true;
                this.timer.Wait();
            }
        }
        
        public bool IsRunning()
        {
            return runPump;
        }
    }
}
