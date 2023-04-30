using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HeatSystem
{
    internal class PIDRegulator
    {
        private double lastValue = 0;
        private double lastError = 0;
        private double sumError = 0;
        public double UpperLimit = 100;
        public double LowerLimit = 0;
        private DateTime lastTime;

        public PIDRegulator()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentVal"></param>
        /// <param name="Setpoint"></param>
        /// <param name="Kp"></param>
        /// <param name="Ti"></param>
        /// <param name="Td"></param>
        /// <param name="MaxSumError"></param>
        /// <returns></returns>
        public double Control(double CurrentVal, double Setpoint, double Kp = 1, double Ti = 100000, double Td = 0, double MaxSumError = 100)
        {

            double dt;
            double error = Setpoint - CurrentVal;
            sumError += error;

            sumError = Limit(sumError, MaxSumError, -MaxSumError);
            DateTime TNow = DateTime.Now;

            // Check for first iteration
            if (lastTime is DateTime)
            {
                dt = (TNow - lastTime).TotalMilliseconds;
                double P = Kp * error;
                double I = Kp / Ti * dt * sumError;
                double D = Kp * Td * (error-lastError) / dt;

                lastValue = P + I + D;

            }
            else
            {
                lastTime = TNow;
                double P = Kp * error;
            }
            lastError = error;
            lastTime = TNow;

            // Keep value within boundaries
            lastValue = Limit(lastValue, UpperLimit, LowerLimit);

            return lastValue;
        }

        private double Limit(double Val, double upper, double lower)
        {
            if (Val > upper)
            {
                Val = upper;
            }
            else if (Val < lower)
            {
                Val = lower;
            }
            return Val;
        }
    }
}
