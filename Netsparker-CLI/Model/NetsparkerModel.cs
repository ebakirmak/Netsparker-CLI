using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsparker_CLI.Model
{
    /// <summary>
    /// Netsparker ayarlarını içeren sınıftır.
    /// </summary>
    public class NetsparkerModel
    {
        /// <summary>
        /// Netsparker.exe dosyasının konum bilgisini tutar.
        /// </summary>
        private string Path { get; set; }

        /// <summary>
        /// Oluşturulacak olan raporun konum bilgisini tutar.
        /// </summary>
        private string ReportLocation { get; set; }

        /// <summary>
        /// Path ve ReportLocation değişkenlerini set eder.
        /// </summary>
        /// <param name="path">Netsparker.exe dosyasının konum bilgisi</param>
        /// <param name="reportLocation">Oluşturulacak olan raporun konum bilgisi</param>
        public void SetConfigs(string path,string reportLocation)
        {
            this.Path = path;
            this.ReportLocation = reportLocation;
        }
        /// <summary>
        /// Netsparker.exe dosyasının konum bilgisini döndürür.
        /// </summary>
        /// <returns>Netsparker.exe Path</returns>
        public string GetPath()
        {
            return this.Path;
        }
        /// <summary>
        /// Oluşturulacak olan raporun konum bilgisini döndürür.
        /// </summary>
        /// <returns>Rapor Location</returns>
        public string GetReportLocation()
        {
            return this.ReportLocation;
        }
    }
}
