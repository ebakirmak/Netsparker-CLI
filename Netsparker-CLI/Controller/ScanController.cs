using Netsparker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsparker_CLI.Controller
{
    public class ScanController
    {
        public ScanController()
        {
                
        }     

        /// <summary>
        /// Bu fonksiyon otomatik (autopilot) tarama başlatır.
        /// </summary>
        /// <param name="netsparkerManager">NetsparkerManager instance</param>
        /// <param name="target">Target Address' that will scan</param>
        /// <returns></returns>
        public bool ScanCreate(NetsparkerManager netsparkerManager,string target)
        {
            try
            {
               return netsparkerManager.CreateScan(target);
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
          
        }
    }
}
