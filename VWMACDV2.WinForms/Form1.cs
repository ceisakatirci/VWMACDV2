using Binance.Net;
using CryptoCompare;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trady.Analysis;
using ZedGraph;
namespace VWMACDV2.WinForms
{
    public partial class Form1 : Form
    {
        private readonly RollingPointPairList vwmacdList = new RollingPointPairList(610);
        private readonly RollingPointPairList signalList = new RollingPointPairList(610);
        private readonly RollingPointPairList histList = new RollingPointPairList(610);      

        Dictionary<string, Listeler> kayitlar = new Dictionary<string, Listeler>();

        //private static readonly object lockerSinyalAlinanlarHepsi = new object();
        //private static readonly object lockerListBox_Diger = new object();
        //private static readonly object lockerListBox_Ortalamalar = new object(); 
        private static readonly object lockerKayitlar = new object();

        public Form1()
        {
            InitializeComponent();
            var myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "VWMACDV2";
            myPane.XAxis.Title.Text = "4 Saatlik Arallıklar";
            myPane.YAxis.Title.Text = "Ema'lar";
            myPane.XAxis.Scale.MaxAuto = true;
            var Wmacd = myPane.AddCurve("Wmacd", vwmacdList, Color.Blue, SymbolType.Star);
            var Signal = myPane.AddCurve("Signal", signalList, Color.Red, SymbolType.Star);
            var Hist = zedGraphControl1.GraphPane.AddBar("Hist", histList, Color.Green);
            Hist.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
            Wmacd.Symbol.Fill = new Fill(Color.White);
            Signal.Symbol.Fill = new Fill(Color.White);
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
        }
        CancellationTokenSource cts = new CancellationTokenSource();
        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    var t = new System.Timers.Timer { Interval = 1000 };
        //    t.Elapsed += (sender, eventargs) =>
        //    {
        //        this.BeginInvoke(new Action(() =>
        //        {
        //            label1.Text = "Dot per seconds: " + c.ToString(); c = 0;
        //        }));
        //    };
        //    t.Start();
        //    Task.Run(() =>
        //    {
        //        var r = new Random();
        //        while (!cts.IsCancellationRequested)
        //        {
        //            Thread.Sleep(TimeSpan.FromSeconds(1));
        //            TimerEventProcessor(r.Next(-10, 10));
        //        };
        //    });
        //}
        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    cts.Cancel();
        //    cts.Token.WaitHandle.WaitOne();
        //    base.OnClosing(e);
        //}
        //int x1 = 0;
        void vwmacdListesineEkle(double x, double y)
        {
            //x1++; c++;
            vwmacdList.Add(x, y);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        void signalListesineEkle(double x, double y)
        {
            //x1++; c++;
            signalList.Add(x, y);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        void histListesineEkle(double x, double y)
        {
            //x1++; c++;
            histList.Add(x, y);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox_SinyalAlinanlar.Items.Clear();
            listBox_Diger.Items.Clear();
            listBox_Ortalamalar.Items.Clear();

            Task.Run(() => {

                using (var binanceClient = new BinanceClient())
                {
                    var data = binanceClient.GetAllPrices().Data;
                    label_BinanceClientCoinAdet.Text = "Binance Client Coin Adet: " + data.Count().ToString();
                    data.Where(x => x.Symbol.EndsWith("BTC"))
                        .Select(x => x.Symbol = x.Symbol.Replace("BTC", ""))
                        .AsParallel()
                        .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                        .ForAll(x => signalAl(x));
                }
            });

      
        }
        /*
               //@version=3
               //created by Buff DORMEIER
               //author: KIVANC @fr3762 on twitter
               study("VOLUME WEIGHTED MACD V2", shorttitle="VWMACDV2")
               fastperiod = input(12,title="fastperiod",type=integer,minval=1,maxval=500)
               slowperiod = input(26,title="slowperiod",type=integer,minval=1,maxval=500)
               signalperiod = input(9,title="signalperiod",type=integer,minval=1,maxval=500)
               fastMA = ema(volume*close, fastperiod)/ema(volume, fastperiod)
               slowMA = ema(volume*close, slowperiod)/ema(volume, slowperiod)
               vwmacd = fastMA - slowMA
               signal = ema(vwmacd, signalperiod)
               //hist= vwmacd - signal
               plot(vwmacd, color=blue, linewidth=2)
               plot(signal, color=red, linewidth=2)
               //plot(hist, color=green, linewidth=4, style=histogram)
               plot(0, color=black)      
           */
        private void signalAl(string sembol)
        {
            try
            {
                var client = new CryptoCompareClient();
                var fastperiod = 12;
                var slowperiod = 26;
                var signalperiod = 9;
                var task = client.History.HourAsync(sembol, "BTC", 609, "Binance");
                task.Wait();
                var historyHour = task.Result;
                var data = historyHour.Data;
                var candles = data.Where(x => x.Close > 0).ToList();
                if (!candles.Any())
                {
                    MessageBox.Show("Hiç Mum Yok, Coin: " + sembol);
                    return;
                }
                var kalan = candles.Count % 4;
                candles = candles.Skip(kalan).ToList();
                var liste4Saatlik = new List<CandleData>();
                var son4Indeks = candles.Count / 4;
                for (var i = 0; i < son4Indeks; i++)
                {
                    var mumlar = candles.Skip(i * 4).Take(4);
                    var candleData = new CandleData();
                    foreach (var mum in mumlar)
                    {
                        candleData.VolumeFrom += mum.VolumeFrom;
                    }
                    candleData.Close = mumlar.Last().Close;
                    //candleData.VolumeFrom = candleData.VolumeFrom / 4;
                    liste4Saatlik.Add(candleData);
                }
                var volumesXcloses = liste4Saatlik.Select(x => x.Close * x.VolumeFrom).ToList();
                var closes = liste4Saatlik.Select(x => (Nullable<decimal>)x.Close).ToList();
                var volumes = liste4Saatlik.Select(x => x.VolumeFrom).ToList();
                /*
                    fastMA = ema(volume*close, fastperiod)/ema(volume, fastperiod)
                    slowMA = ema(volume*close, slowperiod)/ema(volume, slowperiod)
                    vwmacd = fastMA - slowMA
                    signal = ema(vwmacd, signalperiod)    
                    hist= vwmacd - signal
                 */
                var fastEma = volumesXcloses.Ema(fastperiod).Zip(volumes.Ema(fastperiod), (x, y) => x / y).ToList();
                var slowEma = volumesXcloses.Ema(slowperiod).Zip(volumes.Ema(slowperiod), (x, y) => x / y).ToList();
                var vwmacd = fastEma.Zip(slowEma, (x, y) => x - y).ToList();
                var signal = vwmacd.Ema(signalperiod).ToList();
                var hist = vwmacd.Zip(signal, (x, y) => x - y).ToList();

                kayilardaVarsaSil(sembol);

                //kayitlar.Add(sembol, new Tuple<List<decimal?>, List<decimal?>, List<decimal?>, List<decimal?>>(vwmacd, signal, hist, closes));
                kayitlar.Add(sembol, new Listeler());
                kayitlar[sembol].Closes = closes;
                kayitlar[sembol].Vwmacd = vwmacd;
                kayitlar[sembol].Signal = signal;
                kayitlar[sembol].Hist = hist;


            }
            catch (Exception ex)
            {
                var temp = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    temp += Environment.NewLine + ex.Message;                  
                }
                if (listBox_Hatalar.InvokeRequired)
                {
                    listBox_Hatalar.Invoke(new MethodInvoker(delegate
                    {
                        listBox_Hatalar.Items.Add(temp);
                        listBox_Hatalar.TopIndex = Math.Max(listBox_Hatalar.Items.Count - listBox_Hatalar.ClientSize.Height / listBox_Hatalar.ItemHeight + 1, 0);
                        listBox_Hatalar.Refresh();
                    }));
                }
                else
                {
                    listBox_Hatalar.Items.Add(temp);
                    listBox_Hatalar.TopIndex = Math.Max(listBox_Hatalar.Items.Count - listBox_Hatalar.ClientSize.Height / listBox_Hatalar.ItemHeight + 1, 0);
                    listBox_Hatalar.Refresh();
                }

            }

        }
        bool araliktaMi(decimal? a, decimal? b)
        {
            return a * 0.99m <= b && b <= a * 1.01m;
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            _coinGrafikCiz((ListBox)sender);
        }
        private void _coinGrafikCiz(ListBox sender)
        {
            if (sender.SelectedItem != null)
            {
                var key = sender.SelectedItem.ToString();
                if (key.Contains("-"))
                {
                    key = key.Substring(key.IndexOf('-') + 1);
                }
                //MessageBox.Show(key);
                if (kayitlar.ContainsKey(key))
                {
                    vwmacdList.Clear();
                    signalList.Clear();
                    histList.Clear();
                    var vwmacd = kayitlar[key].Vwmacd;
                    var count = vwmacd.Count;
                    var signal = kayitlar[key].Signal;
                    var hist = kayitlar[key].Hist;
                    var closes = kayitlar[key].Closes;
                    for (int i = 0; i < count; i++)
                    {
                        vwmacdListesineEkle(i, Convert.ToDouble(vwmacd[i]));
                        signalListesineEkle(i, Convert.ToDouble(signal[i]));
                        histListesineEkle(i, Convert.ToDouble(hist[i]));
                    }
                    //if (((int).Equals((int)closes.Last()))
                    //{
                    //    label_Vwmacd.Text = ((int)closes.Ema(144).Last()).ToString();
                    //    label_Signal.Text = ((int)closes.Last()).ToString();
                    //}
                    //label_Vwmacd.Text = vwmacd.Last().Value.ToString();
                    //label_Signal.Text = signal.Last().Value.ToString();
                }
            }
        }
        private void listBox_AnlikSinyalAlinanlar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _coinGrafikCiz((ListBox)sender);
        }
        private void listBox_SinyalAlinanlarHepsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox_Aktif.Checked)
            {
                _coinGrafikCiz((ListBox)sender);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            EpostaSorumlusu.Gonder("Test Amaçlı Gönderiyorum");
        }

        //private void listBox_SinyalAlinanlarHepsiEkle(string sembol)
        //{
        //    lock (lockerSinyalAlinanlarHepsi)
        //    {
        //        listBox_SinyalAlinanlarHepsi.Items.Add(sembol);
        //    }
        //}
        //private void listBox_OrtalamalarEkle(string sembol)
        //{
        //    lock (lockerListBox_Ortalamalar)
        //    {
        //        listBox_Ortalamalar.Items.Add(sembol);
        //    }
        //}
        //private void listBox_DigerEkle(string sembol)
        //{
        //    lock (lockerListBox_Diger)
        //    {
        //        listBox_Diger.Items.Add(sembol);
        //    }
        //}
        //private void listBox_SinyalAlinanlarHepsiContains(string sembol)
        //{
        //    lock (lockerSinyalAlinanlarHepsiContains)
        //    {
        //        if (listBox_SinyalAlinanlarHepsi.Items.Contains(sembol))
        //            listBox_SinyalAlinanlarHepsi.Items.Remove(sembol);
        //    }
        //}
        //private void listBox_OrtalamalarContains(string sembol)
        //{
        //    lock (lockerListBox_OrtalamalarContains)
        //    {
        //        if (listBox_Ortalamalar.Items.Contains(sembol))
        //            listBox_Ortalamalar.Items.Remove(sembol);
        //    }
        //}
        //private void listBox_DigerEkleContains(string sembol)
        //{
        //    lock (lockerListBox_DigerContains)
        //    {
        //        if (listBox_Diger.Items.Contains(sembol))
        //            listBox_Diger.Items.Remove(sembol);
        //    }
        //}

        private void kayilardaVarsaSil(string sembol)
        {
            lock (lockerKayitlar)
            {
                if (kayitlar.ContainsKey(sembol))
                    kayitlar.Remove(sembol);
            }
        } 

    }
}



//listBox_SinyalAlinanlar.Invoke(new Action(() =>
//{
//    if (listBox_SinyalAlinanlar.Items.Contains(sembol))
//        listBox_SinyalAlinanlar.Items.Remove(sembol);
//}));

//listBox_Ortalamalar.Invoke(new Action(() =>
//{
//    if (listBox_Ortalamalar.Items.Contains(sembol))
//        listBox_Ortalamalar.Items.Remove(sembol);
//}));

//listBox_Diger.Invoke(new Action(() =>
//{
//    if (listBox_Diger.Items.Contains(sembol))
//        listBox_Diger.Items.Remove(sembol);
//}));

//listBox_SinyalAlinanlarHepsiContains(sembol);
//listBox_OrtalamalarContains(sembol);
//listBox_DigerEkleContains(sembol);



//if (hist.Last().Value > 0)
//{
//    listBox_SinyalAlinanlar.Invoke(new Action(() =>
//    {
//        listBox_SinyalAlinanlar.Items.Add(sembol);
//    }));                  

//    //if (checkBox_Aktif.Checked)
//    //{
//    //    if (!listBox_SinyalAlinanlarHepsi.Items.Contains(sembol))
//    //    {
//    //        listBox_AnlikSinyalAlinanlar.Items.Add(sembol);
//    //        MessageBox.Show("Anlık Yeni Coin Eklendi! Coin: " + sembol);
//    //    }
//    //}
//}
//else
//{
//    //listBox_Diger.Items.Add(sembol);
//    listBox_Diger.Invoke(new Action(() =>
//    {
//        listBox_Diger.Items.Add(sembol);
//    }));
//}

//var ema = closes.Ema(144).Last();
//var last = closes.Last();

//if (araliktaMi(ema, last))
//{
//    //listBox_Ortalamalar.Items.Add("EMA144-" + sembol);                    

//    listBox_Ortalamalar.Invoke(new Action(() =>
//    {
//        listBox_Ortalamalar.Items.Add("EMA144-" + sembol);                    
//    }));
//}

//var sma = closes.Sma(200).Last();

//if (araliktaMi(sma, last))
//{
//    //listBox_Ortalamalar.Items.Add("SMA200-" + sembol);
//    //listBox_OrtalamalarEkle("SMA200-" + sembol);
//    listBox_Ortalamalar.Invoke(new Action(() =>
//    {
//        listBox_Ortalamalar.Items.Add("SMA200-" + sembol);
//    }));
//}

//sma = closes.Sma(50).Last();

//if (sma.Equals(last))
//{
//    //listBox_Ortalamalar.Items.Add("SMA50-" + sembol);
//    //listBox_OrtalamalarEkle("SMA50-" + sembol);
//    listBox_Ortalamalar.Invoke(new Action(() =>
//    {
//        listBox_Ortalamalar.Items.Add("SMA50-" + sembol);
//    }));
//}

//var client = new CryptoCompareClient();
//var response = client.History.HourAsync("QKC", "BTC", 986, "Binance");
//var temp = response.Result.Data.Where(x => x.Close > 0).ToList();
//foreach (var item in temp)
//{
//    Console.WriteLine(item.Time + " => " + item.Close + "  =>  " + item.VolumeFrom + " => " + item.VolumeTo);
//}

//private void listBox_SinyalAlinanlarHepsiContains(string sembol)
//{
//    lock (lockerSinyalAlinanlarHepsiContains)
//    {
//        if (listBox_SinyalAlinanlarHepsi.Items.Contains(sembol))
//            listBox_SinyalAlinanlarHepsi.Items.Remove(sembol);
//    }
//}
//private void listBox_OrtalamalarContains(string sembol)
//{
//    lock (lockerListBox_OrtalamalarContains)
//    {
//        if (listBox_Ortalamalar.Items.Contains(sembol))
//            listBox_Ortalamalar.Items.Remove(sembol);
//    }
//}
//private void listBox_DigerEkleContains(string sembol)
//{
//    lock (lockerListBox_DigerContains)
//    {
//        if (listBox_Diger.Items.Contains(sembol))
//            listBox_Diger.Items.Remove(sembol);
//    }
//}