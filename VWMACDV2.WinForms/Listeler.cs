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
        public List<decimal?> Vwmacd4Saatlik { get; set; }
        public List<decimal?> Signal4Saatlik { get; set; }
        public List<decimal?> Hist4Saatlik { get; set; }
        public List<decimal> Closes4Saatlik { get; set; }
        public List<decimal> Volumes1Saatlik { get; set; }
        public List<decimal> Volumes4Saatlik { get; set; }
        public List<decimal> Closes1Saatlik { get; set; }
        public List<decimal> Wma { get; set; }
        public List<decimal?> Ema144 { get; set; }
        public List<decimal?> Sma50 { get; set; }
        public List<decimal?> Sma200 { get; set; }
        public List<decimal?> Sma21 { get; set; }
        public List<decimal?> Hist1Saatlik { get; set; }
        public List<decimal?> Signal1Saatlik { get; set; }
        public List<decimal?> Vwmacd1Saatlik { get; set; }

        public Listeler()
        {

        }
    }
}
