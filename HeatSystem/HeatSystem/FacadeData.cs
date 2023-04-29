using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    static class FacadeData
    {
        //private UserInterface UI;
        //private FacadeController Controller;
        private static XMLConfig Xml = new XMLConfig();
        public static Database DB = new Database();


        //public static void SetFacades(UserInterface ui, FacadeController controller)
        //{
        //    this.UI= ui;
        //    this.Controller= controller;
        //}


        public static string GetMixerConfig()
        {
            return Xml.GetMixerConfig();
        }

    }
}
