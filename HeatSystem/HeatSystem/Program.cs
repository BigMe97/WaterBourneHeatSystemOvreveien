using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.IO.Ports;

namespace HeatSystem
{

    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            int i = 0;
            MyTimer MainTimer = new MyTimer(1000);
            Thread UserThread = new Thread(new ThreadStart(UserInterface.Run));
            Thread ControlThread = new Thread(new ThreadStart(FacadeController.Run));
            UserThread.Start();
            ControlThread.Start();
            while (UserInterface.run)
            {
                i++;
                UserInterface.Write(0,0, "Main Running... " + i);
                MainTimer.Wait();
            }
            UserThread.Join();
            ControlThread.Join();
        }
    }
}

