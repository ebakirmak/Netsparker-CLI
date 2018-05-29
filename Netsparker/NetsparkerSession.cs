using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsparker
{
    public class NetsparkerSession:IDisposable
    {

        private string NetsparkerPath { get; set; }



        /// <summary>
        /// Yetkilendirme olmadan giriş yapılır.
        ///  UnAuthenticate 
        /// </summary>
        /// <param name="netsparkerPath">Path of Netsparker .exe </param>
        public NetsparkerSession(string netsparkerPath)
        {
       

            if (netsparkerPath.Length != 0)
                this.NetsparkerPath = netsparkerPath;
            else
                this.NetsparkerPath = @"C:\Program Files\Netsparker";
        }

        /// <summary>
        /// Servisin çalışıp çalışmadığını gösterir.
        /// </summary>
        /// <returns></returns>
        public bool NetsparkerCLIState()
        {
            try
            {
                if (ExecuteCommand("/b", "State"))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nREST-Server çalışmıyor. \nHost adresini, Port numarasını ve Servisin çalışıp çalışmadığını kontrol ediniz.\n" + ex.Message);
                //Console.WriteLine("ArachniSession::ArachniServiceState " + ex.Message);
                return false;
            }

        }



        /// <summary>
        /// Bu fonksiyonu, Netsparker aracını komut satırından çalıştırmak için kullanacağız. 
        /// Netsparker, 3. parti yazılımlarda kullanmak için komut satırı arayüzüne sahiptir.
        /// </summary>
        /// <param name="command"></param>
        public bool ExecuteCommand(string command,string process)
        {
            try
            {
                string appName = "Netsparker.exe";
                var path = Path.Combine(this.NetsparkerPath, appName );
                var p = new Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = path;
                p.StartInfo.WorkingDirectory = this.NetsparkerPath;
                //the command line parameter that causes the exe to start in an invisible mode
                p.StartInfo.Arguments = command;

                bool isRun;
                if (process == "Scan")
                {
                
                    isRun = p.Start();
                    if (isRun)
                    {
                        Console.WriteLine("Tarama bitene kadar lütfen bekleyiniz.");
                        p.WaitForExit();
                    }
                    else
                        Console.WriteLine("Tarama başlatılamadı.");
                  
                }

                if(process == "State")
                {
                    isRun = p.Start();
                    if (isRun)
                    {
                        p.Kill();
                        return true;
                    }
                    else
                        return false;
                }
               
               
               


                //string filename = Path.Combine("C:\\Program Files\\Netsparker", "Netsparker.exe");
                //var proc = System.Diagnostics.Process.Start(filename, command.ToString());
                //proc.WaitForExit();
                return true;
            }        
            catch (Exception objException)
            {
                // Log the exception
                if (objException.Message == "The system cannot find the file specified")
                {
                    Console.WriteLine("Belirtilen konumda Netsparker.exe dosyası bulunamadı.");
                }            
             
                return false;
            }
            
     
        }

        public void Dispose()
        {
           
        }
    }
}
