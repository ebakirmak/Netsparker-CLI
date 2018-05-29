﻿using Netsparker;
using Netsparker_CLI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Netsparker-CLI, Komut satırını kullanarak Netsparker'da zafiyet tarama işlemlerini gerçekleştirir.
/// İlk olarak Netsparker'ı ortam değişkenlerine ekleyiniz. Aşağıdaki linke göz atabilirsiniz.
/// https://www.netsparker.com/blog/docs-and-faqs/triggering-netsparker-remotely-windows-management-instrumentation/#AddingtheNetsparkerFilePathtotheEnvironmentVariables///  
/// </summary>
namespace Netsparker_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ScanView.SetNetsparkerConfigs();
                string path = ScanView.GetNetsparkerPath();
                string reportLocation = ScanView.GetReportLocation();

                using (NetsparkerSession session = new NetsparkerSession())
                {
                    
                    using (NetsparkerManager manager = new NetsparkerManager(session, path, reportLocation))
                    {
                    

                            string inputSelection = "";
                            do
                            {
                                Console.Write("\nYapmak istediğiniz işlemi seçiniz." +
                                              "\nA: Tarama Oluşturmak İçin" +
                                              "\nB: Tarama ID döndürmek için " +
                                              "\nC: Tarama Durumunu Görüntülemek İçin" +
                                              "\nD: Tarama Silmek İçin" +
                                              "\nE: Zafiyetleri Görmek İçin" +
                                              "\nF: Zafiyetleri XML Olarak Masaüstüne Kaydet" +
                                              "\nQ: Çıkış İçin" +
                                              "\nSeçiminiz: ");
                                inputSelection = Console.ReadLine().ToUpper();
                                switch (inputSelection)
                                {
                                case "A":
                                    ScanView.ScanCreate(manager);
                                    break;
                                //case "B":
                                //    ScanView.GetScan(manager);
                                //    break;
                                //case "C":
                                //    ScanView.GetScanStatus(manager);
                                //    break;
                                //case "D":
                                //    ScanView.DeleteScan(manager);
                                //    break;
                                //case "E":
                                //    ScanView.ShowScanVulnerabilities(manager);
                                //    break;
                                //case "F":
                                //    ScanView.SaveScanVulnerabilitiesAsXML(manager);
                                //    break;
                                //case "Q":
                                //    break;
                                default:
                                        Console.WriteLine("\n***Hatalı Seçim. Lütfen Seçiminizi kontrol ediniz.***\n");
                                        break;
                                }
                            } while (inputSelection != "Q");
                        }
                        
                        Console.Read();
                    }           
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
