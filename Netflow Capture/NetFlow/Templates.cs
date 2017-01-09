using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.NetFlow
{
    public class Templates
    {
        public List<Template> Templats { get; set; }
        public Int32 Count { get { return this.Templats.Count; } }
        public Templates()
        {
            this.Templats = new List<Template>();
        }
    }
}
