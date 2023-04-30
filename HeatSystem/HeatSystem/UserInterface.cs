using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HeatSystem
{
    static class UserInterface
    {
        public static Mutex MuteConsole = new Mutex();
        public static bool run = true;
        private static MyTimer UITimer;

        private static int samplingTime = 500;
        private static string[] UIlines = new string[15];

        public static void Run()
        {
            UITimer = new MyTimer(samplingTime);
            int i = 0;
            while (UserInterface.run)
            {
                i++;
                Write(1, 0, $"UI Running... {i}");

                // Get values from controller facade

                Write(6, 0, $"Mixing Valve position: {FacadeController.GetMixerPosition()}%");
                Write(7, 0, $"Outflow temperature:   {FacadeController.GetOutflowTemperature()}°C");


                // Write to console
                foreach (var line in UIlines)
                {
                    Console.WriteLine(line);
                }
                Console.SetCursorPosition(0, 0);

                // Stop if X is pressed
                if (UserInterface.InputKey() == 'x')
                {
                    UserInterface.run = false;
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                }
                UITimer.Wait();
            }
        }

        public static char InputKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                return Convert.ToChar(key.KeyChar);
            }
            else
            {
                return ' ';
            }
        }
        
                

        public static void Write(int line, int col, string text)
        {
            //UserInterface.MuteConsole.WaitOne();
            string PreSpaces = new string(' ', col);
            string PostSpaces = new string(' ', 50-col-text.Length);
            UIlines[line] = PreSpaces + text + PostSpaces;

            //UserInterface.MuteConsole.ReleaseMutex();
        }
    }
}
