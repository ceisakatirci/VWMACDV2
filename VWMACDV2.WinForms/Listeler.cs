using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWMACDV2.WinForms
{
    [Serializable]
    public class Listeler
    {
        public List<decimal?> Vwmacd { get; set; }
        public List<decimal?> Signal { get; set; }
        public List<decimal?> Hist { get; set; }
        public List<decimal> Closes4Saatlik { get; set; }
        public IEnumerable<decimal> Closes1Saatlik { get; set; }
        public List<decimal?> Wma { get; set; }
        public List<decimal?> Ema144 { get; set; }
        public List<decimal?> Sma50 { get; set; }
        public List<decimal?> Sma200 { get; set; }
        public List<decimal?> Sma21 { get; set; }
    }
}
