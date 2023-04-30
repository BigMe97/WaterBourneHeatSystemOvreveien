using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    static class FacadeController
    {

        private static PumpController PumpControl = new PumpController();
        private static MixingValveController MixValveControl = new MixingValveController();
        private static WaterLoopController LoopControl = new WaterLoopController();
        private static ErrorHandler Error = new ErrorHandler();

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


        public static IDictionary<string, double> GetMixerConfig()
        {
            return FacadeData.GetMixerConfig();
        }

        public static bool IsPumpRunning()
        {
            return PumpControl.IsRunning();
        }

        public static void StoreMixerValues(IDictionary<string, double> dict)
        {
            FacadeData.StoreMixerValues(dict);
        }

        public static string GetMixerPosition()
        {
            return MixValveControl.GetPosition();
        }
        public static string GetOutflowTemperature()
        {
            return MixValveControl.GetOutflowTemp();
        }

        public static void RiseError(string ErrorMessage)
        {
            Error.RiseError(ErrorMessage);
        }
    }
}
