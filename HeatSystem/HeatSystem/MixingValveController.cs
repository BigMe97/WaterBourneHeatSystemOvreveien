using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    internal class MixingValveController
    {
        private int samplingTime = 5000;

        private TempSensor TemperatureSensor = new TempSensor();
        private PIDRegulator Regulator = new PIDRegulator();
        private MixingValve Valve = new MixingValve();
        private MyTimer timer;

        // Regulator Values
        private double dSetpoint = 30;
        private bool bPumpIsRunning;
        private double dPParam = 1;
        private double dIParam = 100000;
        private double dDParam = 0;
        private double dMaxSumError = 100;
        private bool bValidValues;
        private double dCurrentTemp;

        private double dMixerPosition;

        public MixingValveController() 
        { 
            
        }

        public void Run()
        {
            timer = new MyTimer(samplingTime);
            int i = 0;
            while (UserInterface.run)
            {
                i++;
                UserInterface.Write(2, 0, $"Mix Controller Running... {i}");
                // Is pump running
                bPumpIsRunning = FacadeController.IsPumpRunning();
                if (bPumpIsRunning)
                {

                    // Get config
                    foreach (var item in FacadeController.GetMixerConfig())
                    {
                        switch (item.Key)
                        {
                            case "Kp":
                                dPParam = item.Value;
                                break;
                            case "Ti":
                                dIParam = item.Value;
                                break;
                            case "Td":
                                dDParam = item.Value;
                                break;
                            case "Setpoint":
                                dSetpoint = item.Value;
                                break;
                            case "MaxSumError":
                                dMaxSumError = item.Value;
                                break;

                        }
                    }

                    // Get temp reading
                    this.dCurrentTemp = TemperatureSensor.GetTemperature();
                    // Check if values are valid
                    this.bValidValues = ValidValues();
                    if (this.bValidValues)
                    {
                        // Control with PID controller
                        this.dMixerPosition = this.Regulator.Control(
                            this.dCurrentTemp,
                            this.dSetpoint,
                            this.dPParam,
                            this.dIParam,
                            this.dDParam,
                            this.dMaxSumError);

                        // Set valve position
                        this.Valve.SetPos(this.dMixerPosition);

                    }
                    else
                    {
                        // Rise error
                        FacadeController.RiseError("Values are outside valid range");
                    }

                    // Store values to database
                    IDictionary<string, double> DBValues = new Dictionary<string, double>();
                    DBValues.Add("CurrentTemp", this.dCurrentTemp);
                    DBValues.Add("Position", this.dMixerPosition);
                    FacadeController.StoreMixerValues(DBValues);
                }
                timer.Wait();
            }
        }

        public bool ValidValues()
        {

            return (this.dCurrentTemp > 15) && (this.dCurrentTemp < 60);
        }

        public string GetPosition()
        {
            return this.dMixerPosition.ToString("0.##");
        }
        public string GetOutflowTemp()
        {
            return this.dCurrentTemp.ToString("0.#");
        }
    }
}
