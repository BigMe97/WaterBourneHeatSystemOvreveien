using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    static class FacadeData
    {
        private static XMLConfig Xml = new XMLConfig();
        private static Database DB = new Database();




        public static IDictionary<string, double> GetMixerConfig()
        {
            return Xml.GetMixerConfig();
        }

        public static void StoreMixerValues(IDictionary<string, double> dict)
        {
            DB.StoreMixerValues(dict);
        }
    }
}
