using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Netsparker_CLI.Controller
{
    public class ScannerController
    {
        //XML Dosyalarının yolunu belirtir.
        public string PATH = System.IO.Path.GetDirectoryName(Environment.CurrentDirectory) + @"\..\..\" + @"Netsparker-CLI\ModelXML";

        /// <summary>
        /// Bu fonksiyon bir XML dokümanının Elementini günceller.
        /// </summary>
        /// <param name="ElementPath">Element Path (in xml file )</param>
        /// <param name="Element">Element Name</param>
        /// <param name="Value">New Value</param>
        /// <param name="filePath">File Location</param>
        public void EditXMLElement(string ElementPath, string Element, string Value, string filePath)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            doc.DocumentElement.SelectSingleNode(ElementPath).InnerText = Value;
            doc.Save(filePath);
        }

        /// <summary>
        /// Bu fonksiyon bir XML dokümanındaki Elementin attributenu günceller.
        /// </summary>
        /// <param name="AttributePath">Attribute Path (in xml file )</param>
        /// <param name="Attribute">Attribute Name</param>
        /// <param name="Value">Attribute Value</param>
        /// <param name="filePath">File Location</param>
        public void EditXMLAttribute(string AttributePath, string Attribute, string Value, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            doc.DocumentElement.SelectSingleNode(AttributePath).Attributes[Attribute].Value = Value;
            doc.Save(filePath);

        }

        /// <summary>
        /// Bu fonksşyon bir XML dokümanındaki ilgili Elementin değerini okur.
        /// </summary>
        /// <param name="ElementPath">Element Path (in xml file)</param>
        /// <param name="Element">Element Name</param>
        /// <param name="filePath">File Location</param>
        /// <returns></returns>
        public string ReadXMLElement(string ElementPath, string Element,  string filePath)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            return doc.DocumentElement.SelectSingleNode(ElementPath).InnerText;
           
        }
        /// <summary>
        /// Bu fonksşyon bir XML dokümanındaki ilgili Elementin attribute değerini okur.
        /// </summary>
        /// <param name="AttributePath">Attribute Path (in xml file)</param>
        /// <param name="Attribute">Attribute Name</param>
        /// <param name="filePath">File Location</param>
        /// <returns></returns>
        public string ReadXMLAttribute(string AttributePath,string Attribute,string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            return doc.DocumentElement.SelectSingleNode(AttributePath).Attributes[Attribute].InnerText;
        }

        
    }
}
