using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    class WaterLoopController
    {

        private MyTimer timer;

        private int samplingTime = 1000;

        public WaterLoopController()
        {

        }


        public void Run()
        {
            timer = new MyTimer(samplingTime);
            int i = 0;
            while (UserInterface.run)
            {
                i++;
                UserInterface.Write(4, 0, $"Loop Controller Running... {i}");
                timer.Wait();
            }
        }
    }
}
