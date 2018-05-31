using Netsparker;
using Netsparker_CLI.Controller;
using Netsparker_CLI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsparker_CLI.View
{
    public static class ScanView
    {
        private static NetsparkerModel netsparkerModel = new NetsparkerModel();

        /// <summary>
        /// Netsparker exe yolu ve Tarama raporunun oluşturulacağı konum set edilir.
        /// </summary>
        public static void SetNetsparkerConfigs()
        {
            Console.Write(@" Netsparker.exe için C:\Program Files\Netsparker konumunu değiştmek istiyorsanız yeni bir konum giriniz değiştirmek istemiyorsanız boş bırakın.: ");
            string path = Console.ReadLine();
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            string reportLocate = "";
            do
            {
                Console.Write("Raporların oluşturulacağı konumu değiştirmek İstiyor musunuz? (E/H): ");
                reportLocate = Console.ReadLine();
            } while (reportLocate.ToUpper() != "E" && reportLocate.ToUpper() != "H");

            string reportLocation = "";
            if (reportLocate == "E")
            {
                Console.Write("Raporların oluşturulacağı konumu giriniz (D:\test_folder: ");
                reportLocation = Console.ReadLine();
                if (reportLocation.EndsWith(@"\") == false)
                    reportLocation.Insert(reportLocation.Length, @"\\");
            }
            else
            {
                reportLocation = @"C:\reports\";
                Console.WriteLine("Raporlar " + reportLocation + " konumunda oluşturulacakır.");
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            netsparkerModel.SetConfigs(path,reportLocation);
        }

        /// <summary>
        /// Netsparker exe yolu get edilir.
        /// </summary>
        /// <returns>Nexpose Exe Path</returns>
        public static string GetNetsparkerPath()
        {
           return  netsparkerModel.GetPath();
        }

        public static string GetReportLocation()
        {
            return netsparkerModel.GetReportLocation();
        }

        /// <summary>
        /// Bu fonksiyon otomatik (autopilot) tarama başlatacak.
        /// </summary>
        public static void ScanCreate(NetsparkerManager netsparkerManager)
        {
            Console.Write("Hedef Adresi Giriniz: ");
            string target = Console.ReadLine();

            ScanController scanController = new ScanController();
            if(scanController.ScanCreate(netsparkerManager, target,null,null,null))
                Console.WriteLine("Tarama başarılı bir şekilde tamamlandı. XML Dosyası " + GetReportLocation() + " konumunda oluşturuldu.");
        }
    }
}
