using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace VWMACDV2.WinForms
{
    public partial class frmVWMACDV2 : Form
    {
        private readonly RollingPointPairList signalList;
        private readonly RollingPointPairList histList;
        private readonly RollingPointPairList vwmacdList;
        public frmVWMACDV2(Listeler listeler, int capacity = 610)
        {
            signalList = new RollingPointPairList(capacity);
            histList = new RollingPointPairList(capacity);
            vwmacdList = new RollingPointPairList(capacity);
            InitializeComponent();
        }

        private void frmVWMACDV2_Load(object sender, EventArgs e)
        {
           //var pane = zedGraphControl1.GraphPane;
           // pane.Title.Text = "VWMACDV2";
           // pane.XAxis.Title.Text = "4 Saatlik Arallıklar";
           // pane.YAxis.Title.Text = "Hacimli Ema'lar";
           // var Wmacd = myPane.AddCurve("Wmacd", vwmacdList, Color.Blue, SymbolType.Star);
           // var Signal = myPane.AddCurve("Signal", signalList, Color.Red, SymbolType.Star);
           // var Hist = zedGraphControl1.GraphPane.AddBar("Hist", histList, Color.Green);
           // Hist.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
           // Wmacd.Symbol.Fill = new Fill(Color.White);
           // //pane.XAxis.Scale.MaxAuto = true;
        }
    }
}
