using Netsparker_CLI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsparker_CLI.Controller
{
    /// <summary>
    /// Bu sınıf Tarama ile ilgili policy ayarlarını yapmak için kullanılır.
    /// </summary>
    public class PolicyController : ScannerController
    {
        public List<PolicyModel> Policys { get; set; }

        public PolicyController()
        {
            Policys = new List<PolicyModel>();

        }

        /// <summary>
        /// Bu fonksiyon mevcut policyleri döndürür.
        /// </summary>
        /// <returns>List<PolicyModels></returns>
        public List<PolicyModel> GetPolicyModels()
        {
            try
            {
                string[] files = Directory.GetFiles(PATH + @"\Policies");
                string fileName = "";
                foreach (var file in files)
                {
                    string PolicyID = ReadXMLAttribute("/ScanPolicy", "Id", file);
                    string Description = ReadXMLElement("/ScanPolicy", "Description", file).Split('.')[0];
                    fileName = file.Split('\\').LastOrDefault().Split('.')[0];
                    Policys.Add(new PolicyModel(PolicyID, fileName, Description));
                }

                return Policys;
            }
            catch (Exception ex)
            {
                Console.WriteLine("PolicyController::ListPolicy\n Error Message:" + ex.Message);
                return null;
            }

        }


        /// <summary>
        /// Bu fonksiyon ilgili policy'i Netsparker\Policies klasörüne kopyalar.
        /// </summary>
        /// <param name="policyNumber">Policy Number</param>
        public void CreatePolicy(int policyNumber)
        {

            try
            {
                string documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string policyName = Policys[policyNumber - 1].Name;
                System.IO.File.Copy(PATH + @"\Policies\" + policyName + ".xml", documentFolder + @"\Netsparker\Policies\" + policyName + ".xml", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("PolicyController::CreatePolicy\n Error Message:" + ex.Message);
            }

        }


    }
}