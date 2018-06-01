using Netsparker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Netsparker_CLI.Controller
{
    public class ScanController:ScannerController
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
               return netsparkerManager.CreateScan(target,false);
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
          
        }

        /// <summary>
        /// Bu fonksiyon profile ile tarama başlatır.
        /// </summary>
        /// <param name="netsparkerManager">Netsparkmanager instance</param>
        /// <param name="target">Target Address' that will scan</param>
        /// <param name="LogInFormURL">Login page of Target</param>
        /// <param name="username">Login Username</param>
        /// <param name="password">Login Password</param>
        /// <param name="policyID">Selected Policy</param>
        /// <returns></returns>
        public bool ScanCreate(NetsparkerManager netsparkerManager, string target,string LogInFormURL,string username,string password,string policyID)
        {
            try
            {

                //Default_Profile dosyası PolicyId elementi
                EditXMLElement("/ScanProfile/PolicyId", "PolicyId", policyID, PATH + @"\Profile\Default_Profile.xml");

                //Default_Profile dosyası TargetURL elementi
                EditXMLElement("/ScanProfile/TargetUrl", "TargetUrl", target,PATH+@"\Profile\Default_Profile.xml");

                //Default_Profile dosyası LogOutFormURL elementi
                EditXMLElement("/ScanProfile/FormAuthenticationSettings/LogoutRedirectPattern", "LogoutRedirectPattern", LogInFormURL, PATH + @"\Profile\Default_Profile.xml");

                //Default_Profile dosyası FormAuthenticationSettings elementi LogInFormURL attribute 
                EditXMLAttribute("/ScanProfile/FormAuthenticationSettings", "LoginFormUrl",LogInFormURL, PATH + @"\Profile\Default_Profile.xml");

                //Default_Profile dosyası FormAuthenticationPersona elementi Username attribute
                EditXMLAttribute("/ScanProfile/FormAuthenticationSettings/Personas/FormAuthenticationPersona", "Username", username, PATH + @"\Profile\Default_Profile.xml");

                //Default_Profile dosyası FormAuthenticationPersona elementi Passord attribute
                EditXMLAttribute("/ScanProfile/FormAuthenticationSettings/Personas/FormAuthenticationPersona", "Password", password, PATH + @"\Profile\Default_Profile.xml");

                //Default_Profile dosyası FormAuthenticationPersona elementi IsPasswordEncrypted attribute
                EditXMLAttribute("/ScanProfile/FormAuthenticationSettings/Personas/FormAuthenticationPersona", "IsPasswordEncrypted", "false", PATH + @"\Profile\Default_Profile.xml");


                string documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                System.IO.File.Copy(PATH + @"\Profile\Default_Profile.xml", documentFolder + @"\Netsparker\Profiles\Default_Profile.xml",true);

                return netsparkerManager.CreateScan(target,true);
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

      
    }
}
