using Netsparker;
using Netsparker_CLI.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Netsparker-CLI, Komut satırı arayüzünü kullanarak Netsparker'da zafiyet tarama işlemlerini gerçekleştirir.
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

                using (NetsparkerSession session = new NetsparkerSession(path))
                {
                    if (session.NetsparkerCLIState()) { 
                    
                    using (NetsparkerManager manager = new NetsparkerManager(session, reportLocation))
                    {
                    

                            string inputSelection = "";
                            do
                            {
                                Console.Write("\nYapmak istediğiniz işlemi seçiniz." +
                                              "\nA: Tarama Oluşturmak İçin" +
                                              "\nQ: Çıkış İçin" +
                                              "\nSeçiminiz: ");
                                inputSelection = Console.ReadLine().ToUpper();
                                switch (inputSelection)
                                {
                                case "A":
                                    ScanView.ScanCreate(manager);
                                    break;
                                case "Q":
                                    break;
                                default:
                                        Console.WriteLine("\n***Hatalı Seçim. Lütfen Seçiminizi kontrol ediniz.***\n");
                                        break;
                                }
                            } while (inputSelection.ToUpper() != "Q");
                        }
                        Console.WriteLine("Başarılı bir şekilde çıkış işlemi gerçekleştirildi.");
                        Console.Read();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
              
            }
            Console.Read();
        }



    }
}

