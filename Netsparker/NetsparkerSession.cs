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
       

        /// <summary>
        /// Yetkilendirme olmadan giriş yapılır.
        ///  UnAuthenticate 
        /// </summary>
        /// <param name="netsparkerPath">Path of Netsparker .exe </param>
        public NetsparkerSession()
        {
            
        }




        /// <summary>
        /// Bu fonksiyonu, Netsparker aracını komut satırından çalıştırmak için kullanacağız. 
        /// Netsparker, 3. parti yazılımlarda kullanmak için komut satırı arayüzüne sahiptir.
        /// </summary>
        /// <param name="command"></param>
        public bool ExecuteCommand(string appPath, string command,string process)
        {
            try
            {
                string appName = "Netssparker.exe";
                var path = Path.Combine(appPath, appName );
                var p = new Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = path;
                p.StartInfo.WorkingDirectory = appPath;
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
               
               
               


                //string filename = Path.Combine("C:\\Program Files\\Netsparker", "Netsparker.exe");
                //var proc = System.Diagnostics.Process.Start(filename, command.ToString());
                //proc.WaitForExit();
                return true;
            }
            catch (Exception objException)
            {
                // Log the exception
                return false;
            }
     
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
