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

        /// <summary>
        /// Bu fonksiyon oluşturulacak olan raporun konumunu bildirir.
        /// </summary>
        /// <returns></returns>
        public static string GetReportLocation()
        {
            return netsparkerModel.GetReportLocation();
        }

        /// <summary>
        /// Bu fonksiyon otomatik (autopilot) veya profile tarama başlatır.
        /// </summary>
        public static void ScanCreate(NetsparkerManager netsparkerManager)
        {
            ScanController scanController = new ScanController();

            string targetUrl,targetLoginUrl,username,password,policyID;

            try
            {
                Console.Write("Site Login bilgilerini girmek istiyor musunuz? (E/H):");
                string loginState = Console.ReadLine();

                if (loginState.ToUpper() == "E")
                {
                    Console.Write("Lütfen Policy Seçiniz.\n");
                    policyID = ChoosePolicy();

                    Console.Write("Hedef Adresi Giriniz: ");
                    targetUrl = Console.ReadLine();

                    Console.Write("Hedef Adresin Login Sayfasını Giriniz: ");
                    targetLoginUrl = Console.ReadLine();

                    Console.Write("Hedef Adres Login username Giriniz: ");
                    username = Console.ReadLine();

                    Console.Write("Hedef Adres Login password Giriniz: ");
                    password = Console.ReadLine();

                    

                    if (scanController.ScanCreate(netsparkerManager, targetUrl, targetLoginUrl, username, password,policyID))
                        Console.WriteLine("Tarama başarılı bir şekilde tamamlandı. XML Dosyası " + GetReportLocation() + " konumunda oluşturuldu.");
                    else
                        Console.WriteLine("Tarama tamamlanamadı.");
                }
                else if (loginState.ToUpper() == "H")
                {
                    Console.Write("Hedef Adresi Giriniz: ");
                    targetUrl = Console.ReadLine();

                    if (scanController.ScanCreate(netsparkerManager, targetUrl))
                        Console.WriteLine("Tarama başarılı bir şekilde tamamlandı. XML Dosyası " + GetReportLocation() + " konumunda oluşturuldu.");
                    else
                        Console.WriteLine("Tarama tamamlanamadı.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

          
           
            

            
           
        }


        /// <summary>
        /// Bu fonksiyon policy seçmemize yarar.
        /// </summary>
        /// <returns></returns>
        private static string ChoosePolicy()
        {
            PolicyController policyController = new PolicyController();
            List<PolicyModel> policyModels = policyController.GetPolicyModels();
            int counter = 0;
            foreach (var policy in policyModels)
            {
                counter += 1;
                Console.WriteLine(counter + ") " + policy.Name + ": " + policy.Description + "\n");
            }

            do
            {
                Console.Write("Seçim: ");
                int policyNumber = Convert.ToInt32(Console.ReadLine());
                if (policyNumber > 0 && policyNumber <= policyModels.Count)
                {
                    policyController.CreatePolicy(policyNumber);
                    return policyModels[policyNumber - 1].ID;
                }         
                else
                    Console.WriteLine("Policy Tekrar Seçiniz.");
            } while (true);

          
        }


    }
}
