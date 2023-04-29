using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    internal class MixingValveController
    {
        
        public MixingValveController() 
        { 
            
        }

        public void Run()
        {

            while (UserInterface.run)
            {
                string config = FacadeController.GetMixerConfig();

                FacadeController.Write(2,0, config);
            }
        }
    }
}
