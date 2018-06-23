using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWMACDV2.WinForms
{
    public class Listeler
    {
        public List<decimal?> Vwmacd { get; set; }
        public List<decimal?> Signal { get; set; }
        public List<decimal?> Hist { get; set; }
        public List<decimal?> Closes { get; set; }
    }
}
