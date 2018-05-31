using Netsparker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
               return netsparkerManager.CreateScan(target,false);
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
          
        }

        public bool ScanCreate(NetsparkerManager netsparkerManager, string target,string LogInFormURL,string username,string password)
        {
            try
            {

                //Target URL için
                XMLNodeEdit("/ScanProfile/TargetUrl", "TargetUrl", target);

                //LogOutFormURL için
                XMLNodeEdit("/ScanProfile/FormAuthenticationSettings/LogoutRedirectPattern", "LogoutRedirectPattern", LogInFormURL);

                //LogInFormURL için
                XMLAttributeEdit("/ScanProfile/FormAuthenticationSettings", "LoginFormUrl",LogInFormURL);

                //Username İçin
                XMLAttributeEdit("/ScanProfile/FormAuthenticationSettings/Personas/FormAuthenticationPersona", "Username", username);

                //Password İçin
                XMLAttributeEdit("/ScanProfile/FormAuthenticationSettings/Personas/FormAuthenticationPersona", "Password", password);

                //Password Encrypted İçin
                XMLAttributeEdit("/ScanProfile/FormAuthenticationSettings/Personas/FormAuthenticationPersona", "IsPasswordEncrypted", "false");

                System.IO.File.Copy(@"C:/Users/emreakirmak/Desktop/Netsparker-CLI/Netsparker-CLI/ModelXML/Default_Policy.xml", @"C:\Users\emreakirmak\Documents\Netsparker\Profiles\Default_Policy.xml",true);

                return netsparkerManager.CreateScan(target,true);
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }

        }

        private void XMLNodeEdit(string NodePath,string Node, string Value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:/Users/emreakirmak/Desktop/Netsparker-CLI/Netsparker-CLI/ModelXML/Default_Policy.xml");
            doc.DocumentElement.SelectSingleNode(NodePath).InnerText = Value;
            doc.Save(@"C:/Users/emreakirmak/Desktop/Netsparker-CLI/Netsparker-CLI/ModelXML/Default_Policy.xml");
          


        }

        private void XMLAttributeEdit(string NodePath, string Node, string Value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:/Users/emreakirmak/Desktop/Netsparker-CLI/Netsparker-CLI/ModelXML/Default_Policy.xml");
            doc.DocumentElement.SelectSingleNode(NodePath).Attributes[Node].Value = Value;
            doc.Save(@"C:/Users/emreakirmak/Desktop/Netsparker-CLI/Netsparker-CLI/ModelXML/Default_Policy.xml");
            
        }
    }
}
