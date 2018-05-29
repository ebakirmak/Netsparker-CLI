using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsparker
{
   public class NetsparkerManager:IDisposable
    {
        private NetsparkerSession Session { get; set; }

        private string NetsparkerPath { get; set; }

        public string ReportLocation { get; set; }

        /// <summary>
        /// Bu apıcı metot (constructor) aşağıdaki parametreleri alarak llgili nesneyi oluşturur.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="netsparkerPath">Application Path</param>
        /// <param name="reportLocation">The report Location that was created</param>
        public NetsparkerManager(NetsparkerSession session, string netsparkerPath, string reportLocation)
        {
            if (session != null)
            {
                this.Session = session;
                this.ReportLocation = reportLocation;
                this.NetsparkerPath = netsparkerPath;
            }
        }

        ///// <summary>
        ///// Bu fonksiyon devam eden Taramayı döndürür.
        ///// This function return continued Scan.
        ///// </summary>
        ///// <returns></returns>
        //public string GetScans()
        //{
        //    return Session.ExecuteCommand("/scans/");

        //}


        /// <summary>
        /// Bu fonksiyon otomatik yeni bir tarama oluşturur.
        ///  This function creates a new Autopilot Scan.
        /// </summary>
        /// <param name="command">String in valid command type</param>
        /// <returns></returns>
        public bool CreateScan(string url)
        {
            try
            {
                if (this.Session != null)
                {
                  
                    return Session.ExecuteCommand(this.NetsparkerPath,"/a" + (" /url " + url) + (" /r " + "\"" + this.ReportLocation +@"scan_report.xml" + "\" ") + "/rt " + "\"Vulnerabilities List (XML)\"","Scan");
                }
                else
                    return false;
               
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        ///// <summary>
        ///// Bu fonksiyon taramayı siler.
        ///// This function deletes the Scans
        ///// </summary>
        ///// <param name="id">Scan ID</param>
        ///// <returns></returns>
        //public string DeleteScan(string id)
        //{
        //    return Session.ExecuteCommand("/scans/");
        //}


        ///// <summary>
        ///// Bu fonksiyon  tarama durumunu getirir. 
        ///// This function gets the Scan Status.
        ///// </summary>
        ///// <param name="id">Scan ID</param>
        ///// <returns></returns>
        //public string GetScanStatus(string id)
        //{
        //    return Session.ExecuteCommand("/scans/");
        //}


        ///// <summary>
        ///// Bu fonksiyon taramayı durdurur.
        ///// This function stops the Scan.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public string StopScan(string id)
        //{
        //    return Session.ExecuteCommand("/scans/");
        //}

        ///// <summary>
        ///// Bu fonksiyon taramayı duraklatır.
        ///// This function pauses the Scan.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public string PauseScan(string id)
        //{
        //    return Session.ExecuteCommand("/scans/");
        //}

        ///// <summary>
        ///// Bu fonksiyon taramada bulunan zafiyetleri döndürür.
        ///// This function returns fouund Vulnerabilities in Scan
        ///// </summary>
        ///// <param name="id">Scan ID</param>
        ///// <returns></returns>
        //public string GetScanVulnerabilities(string id)
        //{
        //    return Session.ExecuteCommand("/scans/");
        //}

        ///// <summary>
        ///// Bu fonksiyon  bulunan zafiyetin detaylarını döndürür.
        ///// This function returns found vulnerability details.
        ///// </summary>
        ///// <param name="scanId">Scan ID</param>
        ///// <param name="vulnId">Vulnerability ID</param>
        ///// <returns></returns>
        //public string GetScanVulnerabilityDetails(string scanId, string vulnId)
        //{
        //    return Session.ExecuteCommand("/scans/");
        //}
    }
}
