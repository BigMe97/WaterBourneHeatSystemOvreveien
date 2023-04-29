using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace HeatSystem
{

    class Program
    {
        

        static void Main(string[] args)
        {
            bool run = true;
            int i = 0;

            Thread UserThread = new Thread(new ThreadStart(UserInterface.Run));
            Thread ControlThread = new Thread(new ThreadStart(FacadeController.Run));
            UserThread.Start();
            ControlThread.Start();
            while (UserInterface.run)
            {
                DateTime begin = DateTime.Now;
                UserInterface.Write(0,0, "Running... " + i);

                    if (UserInterface.InputKey() == 'x')
                    {
                        UserInterface.run = false;
                        Console.WriteLine("Exiting...");
                    }
                
                i++;
            }
            UserThread.Join();
            ControlThread.Join();
        }
    }
}

