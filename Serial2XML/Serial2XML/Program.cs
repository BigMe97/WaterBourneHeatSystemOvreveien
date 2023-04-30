using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Xml;
using System.Runtime.CompilerServices;

namespace Serial2XML
{
    internal class Program
    {
        private static string data = "";
        static SerialPort serial = new SerialPort("COM3", 9600);

        static void Main(string[] args)
        {
            Console.WriteLine("Running");
            try
            {

                while (true)
                {
                    if (serial.IsOpen == false)
                    {
                        serial.Open();
                    }
                    if (serial.BytesToRead > 0)
                    {

                        data = serial.ReadExisting();
                        Console.WriteLine($"{data} -> {DateTime.Now.ToString("HH:mm:ss")}");
                        data = "";
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not connect to anything at COM port");
                
            }
            

            
        }
    }
}
