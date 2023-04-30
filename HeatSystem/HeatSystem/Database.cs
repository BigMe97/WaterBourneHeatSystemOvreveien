using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HeatSystem
{
    internal class Database
    {
        private double OutflowTemp;
        private double MixerPosition;
        public Database()
        {

        }

        public void StoreMixerValues(IDictionary<string, double> dict)
        {
            foreach (var item in dict)
            {
                switch (item.Key)
                {
                    case "CurrentTemp":
                        this.OutflowTemp = item.Value;
                        break;
                    case "Position":
                        this.MixerPosition = item.Value;
                        break;
                }
            }
            if (OutflowTemp > 0 && MixerPosition > 0)
            {

                using (StreamWriter sw = new StreamWriter("MixerValues.csv", true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("dd/MM/yy:HH:mm:ss")};{OutflowTemp.ToString("00.00")};{MixerPosition.ToString("000.00")}");
                    // dd/MM/yy:HH:mm:ss
                }
                OutflowTemp = -1;
                MixerPosition = -1;
            }
        }
    }
}
