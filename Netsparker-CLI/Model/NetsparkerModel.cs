using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsparker_CLI.Model
{
    public class NetsparkerModel
    {
        private string Path { get; set; }

        private string ReportLocation { get; set; }

        public void SetConfigs(string path,string reportLocation)
        {
            this.Path = path;
            this.ReportLocation = reportLocation;
        }

        public string GetPath()
        {
            return this.Path;
        }

        public string GetReportLocation()
        {
            return this.ReportLocation;
        }
    }
}
