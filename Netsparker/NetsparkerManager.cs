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

        public string ReportLocation { get; set; }

        /// <summary>
        /// Bu apıcı metot (constructor) aşağıdaki parametreleri alarak llgili nesneyi oluşturur.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="netsparkerPath">Application Path</param>
        /// <param name="reportLocation">The report Location that was created</param>
        public NetsparkerManager(NetsparkerSession session, string reportLocation)
        {
            if (session != null)
            {
                this.Session = session;
                this.ReportLocation = reportLocation;


            }
        }

      


        /// <summary>
        /// Bu fonksiyon otomatik yeni bir tarama oluşturur.
        ///  This function creates a new Autopilot Scan.
        /// </summary>
        /// <param name="command">String in valid command type</param>
        /// <returns></returns>
        public bool CreateScan(string url,bool profile)
        {

            try
            {  
                    /*
                     * komut satırı parametreleri
                     *      auto: Taramayı calistirmak icin kullanilir.
                     *      silent: Hata mesajlarini bastirmak icin kullanilir.
                     *      url: Taranacak olan web adresi veya servis adresidir.
                     *      report: Olusturulacak olan raporun oluşturulacağı konum ve adı
                     *      reporttemplate: Olusturulacak olan raporun tipi. (Pdf, html, xml gibi secenekler mevcuttur.
                     */

                if (this.Session != null && profile == false)
                {             
                  
                    return Session.ExecuteCommand("/auto /silent / " + (" /url " + url) + (" /report " + "\"" +this.ReportLocation + @"scan_report_"+ Guid.NewGuid() +".xml" + "\" ") + "/reporttemplate " + "\"Vulnerabilities List (XML)\"","Scan");
                }
                else if(this.Session != null && profile == true)
                {
                    return Session.ExecuteCommand("/auto  /silent /profile "+ "\"" +"Default_Profile" + "\" " + (" /url " + url) + (" /report " + "\"" + this.ReportLocation + @"scan_report_" + Guid.NewGuid() + ".xml" + "\" ") + "/reporttemplate " + "\"Vulnerabilities List (XML)\"", "Scan");
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
     
        }


        
    }
}
