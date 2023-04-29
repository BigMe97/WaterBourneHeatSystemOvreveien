using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    internal class XMLConfig
    {
        private int i = 0;

        public XMLConfig() 
        {

        }


        //public XMLConfig(FacadeData facade) 
        //{ 
        //    this.Data = facade;
        //}

        public string GetMixerConfig()
        {
            i++;
            return "Mixer configuration data " + i;
        }
    }
}
