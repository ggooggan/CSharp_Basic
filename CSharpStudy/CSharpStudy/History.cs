using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class History : System.Attribute
    {
        private string programmer;

        public double Version { get; set; }
        public string Changes { get; set; }

        public History(string programmer)
        {
            this.programmer = programmer;
            Version = 1.0;
            Changes = "First release";
        }

        public string Programmer => programmer;
    }
}
