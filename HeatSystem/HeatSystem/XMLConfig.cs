using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    internal class XMLConfig
    {
        private int i = 0;
        private IDictionary<string, double> MixerConfig = new Dictionary<string, double>();

        public XMLConfig() 
        {
            MixerConfig.Add("Setpoint", 30);
            MixerConfig.Add("Kp", 0.1);
            MixerConfig.Add("Ti", 1000);
            MixerConfig.Add("Td", 1);
            MixerConfig.Add("MaxSumError", 50);
        }


        
        public IDictionary<string, double> GetMixerConfig()
        {
            return MixerConfig;
        }
    }
}
