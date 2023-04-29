using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    static class UserInterface
    {
        public static Mutex MuteConsole = new Mutex();
        public static bool run = true;
        public static void Run()
        {
            while (run)
            {
                
                Write(4, 0, "UI Running");

                

            }
        }
        public static char InputKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(false);

                return Convert.ToChar(key.KeyChar);
            }
            else
            {
                return ' ';
            }
        }
        
                

        public static void Write(int line, int col, string text)
        {
            UserInterface.MuteConsole.WaitOne();
            Console.SetCursorPosition(col, line);
            Console.Write(text);
            Console.SetCursorPosition(0, 0);
            UserInterface.MuteConsole.ReleaseMutex();
        }
    }
}
