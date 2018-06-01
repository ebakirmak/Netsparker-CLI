using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsparker_CLI.Model
{
    /// <summary>
    /// Policy blgileri tutan sınıf.
    /// </summary>
    public class PolicyModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public PolicyModel(string id, string name, string description)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
