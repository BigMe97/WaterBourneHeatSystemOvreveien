using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    static class FacadeController
    {

        public static PumpController PumpControl = new PumpController();
        private static MixingValveController MixValveControl = new MixingValveController();
        public static WaterLoopController LoopControl = new WaterLoopController();

        public static void Run()
        {
            Thread MixerThread = new Thread(new ThreadStart(MixValveControl.Run));
            Thread PumpThread = new Thread(new ThreadStart(PumpControl.Run));
            Thread LoopThread = new Thread(new ThreadStart(LoopControl.Run));

            MixerThread.Start();
            PumpThread.Start();
            LoopThread.Start();
            while (UserInterface.run)
            {

            }
            MixerThread.Join();
            PumpThread.Join();
            LoopThread.Join();
        }


        public static void Write(int line, int col, string text)
        {
            UserInterface.Write(line, col, text);
        }


        public static string GetMixerConfig()
        {
            return FacadeData.GetMixerConfig();
        }


    }
}
