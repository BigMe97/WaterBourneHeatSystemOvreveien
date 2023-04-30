using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HeatSystem
{
    internal class ErrorHandler
    {
        private List<string> errorList = new List<string>();


        public ErrorHandler() 
        {
        }

        public void RiseError(string Message)
        {
            errorList.Add(Message);
        }

        public List<string> GetErrors()
        {
            return errorList;
        }
    }
}
