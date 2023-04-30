using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace HeatSystem
{
    internal class TempSensor
    {
        private double value;
        private string name;
        private double param = 0.5;


        public TempSensor()
        { 

        }

        public TempSensor(string name)
        {
            this.name = name;
        }

        public double GetTemperature()
        {
            Random r = new Random();
            try
            {
                // Simulating temperature change
                double valvePosition = Convert.ToDouble(FacadeController.GetMixerPosition());
                double temp = valvePosition / 3 + 25;
                this.value += param * (temp - this.value);

            }
            catch (Exception e)
            {

                this.value = r.Next(2000, 5000)/100.0;
                
            }
            return value;
        }


        

    }
}
