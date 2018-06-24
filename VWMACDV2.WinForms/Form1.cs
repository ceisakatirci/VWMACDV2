using Binance.Net;
using CryptoCompare;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Trady.Analysis;
using ZedGraph;
namespace VWMACDV2.WinForms
{
    public partial class Form1 : Form
    {
        private static int _limit = 2584;
        private readonly RollingPointPairList vwmacdList = new RollingPointPairList(_limit);
        private readonly RollingPointPairList signalList = new RollingPointPairList(_limit);
        private readonly RollingPointPairList histList = new RollingPointPairList(_limit);
        private readonly RollingPointPairList wmaList = new RollingPointPairList(_limit);
        private readonly RollingPointPairList closeListesi = new RollingPointPairList(_limit);
        private readonly RollingPointPairList closeEma144Listesi = new RollingPointPairList(_limit);
        private readonly RollingPointPairList closeSma50Listesi = new RollingPointPairList(_limit);
        private readonly RollingPointPairList closeSma200Listesi = new RollingPointPairList(_limit);
        Dictionary<string, Listeler> kayitlar = new Dictionary<string, Listeler>();
        private long sayac;
        private long sinyalAdet;
        private long digerAdet; 
        private static readonly object lockerKayitlar = new object();
        public Form1()
        {
            InitializeComponent();
            var myPane = zedGraphControl1.GraphPane;
            var myPane2 = zedGraphControl2.GraphPane;
            var myPane3 = zedGraphControl3.GraphPane;
            myPane.Title.Text = "VWMACDV2";
            myPane.XAxis.Title.Text = "4 Saatlik Arallıklar";
            myPane.YAxis.Title.Text = "Ema'lar";
            myPane2.Title.Text = "MavilimW";
            myPane2.XAxis.Title.Text = "4 Saatlik Arallıklar";
            myPane2.YAxis.Title.Text = "Fiyat";
            myPane.YAxis.Scale.MaxAuto = true;
            myPane2.YAxis.Scale.MaxAuto = true;
            //myPane3.YAxis.Scale.MaxAuto = true;
            //myPane3.YAxis.Scale.MinAuto = true;
            var Wmacd = myPane.AddCurve("Wmacd", vwmacdList, Color.Blue, SymbolType.Star);
            var Wma = myPane2.AddCurve("Wma", wmaList, Color.Blue, SymbolType.Star);
            var Closes = myPane3.AddCurve("Closes", closeListesi, Color.Pink, SymbolType.None);
            var Ema144 = myPane3.AddCurve("Ema144", closeEma144Listesi, Color.Aqua, SymbolType.None);
            var Sma200 = myPane3.AddCurve("Sma200", closeSma200Listesi, Color.Red, SymbolType.None);
            var Sma50 = myPane3.AddCurve("Sma50", closeSma50Listesi, Color.Green, SymbolType.None);
            var Signal = myPane.AddCurve("Signal", signalList, Color.Red, SymbolType.Star);
            var Hist = zedGraphControl1.GraphPane.AddBar("Hist", histList, Color.Green);
            Hist.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
            Wmacd.Symbol.Fill = new Fill(Color.White);
            Wma.Symbol.Fill = new Fill(Color.White);
            Closes.Symbol.Fill = new Fill(Color.White);
            Signal.Symbol.Fill = new Fill(Color.White);
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            myPane2.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            myPane2.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            myPane3.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            myPane3.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
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

        void listeyeEkle(RollingPointPairList rollingPoint, ZedGraphControl zedGraph, double x, double y)
        {
            //x1++; c++;
            rollingPoint.Add(x, y);
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        void closesListesineEkle(double x, double y)
        {
            //x1++; c++;
            closeListesi.Add(x, y);
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }

        void wmaListesineEkle(double x, double y)
        {
            //x1++; c++;
            wmaList.Add(x, y);
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }
        private void button_Baslat_Click(object sender, EventArgs e)
        {
            listBox_SinyalAlinanlar.Items.Clear();
            listBox_Diger.Items.Clear();
            listBox_Ortalamalar.Items.Clear();
            Task.Run(() =>
            {
                using (var binanceClient = new BinanceClient())
                {
                    var data = binanceClient.GetAllPrices().Data;
                    label_BinanceClientCoinAdet.InvokeIfRequired((MethodInvoker)delegate ()
                    {
                        label_BinanceClientCoinAdet.Text = labelBaslangicMetinAl(label_BinanceClientCoinAdet.Text) + data.Count().ToString();
                    });
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
            var adim = 0;
            try
            {
                var client = new CryptoCompareClient();
                adim = 1;
                var fastperiod = 12;
                adim = 2;
                var slowperiod = 26;
                adim = 3;
                var signalperiod = 9;
                adim = 4;
                var task = client.History.HourAsync(sembol, "BTC", _limit - 1, "Binance");
                adim = 5;
                task.Wait();
                adim = 6;
                var historyHour = task.Result;
                adim = 7;
                var data = historyHour.Data;
                adim = 8;
                var candles = data.Where(x => x.Close > 0).ToList();
                adim = 9;
                adim = 10;
                if (!candles.Any())
                {
                    adim = 11;
                    MessageBox.Show("Hiç Mum Yok, Coin: " + sembol);
                    adim = 12;
                    return;
                }
                adim = 13;
                adim = 14;
                var kalan = candles.Count % 4;
                adim = 15;
                candles = candles.Skip(kalan).ToList();
                adim = 16;
                var liste4Saatlik = new List<CandleData>();
                adim = 17;
                var son4Indeks = candles.Count / 4;
                adim = 18;
                adim = 19;
                for (var i = 0; i < son4Indeks; i++)
                {
                    adim = 20;
                    var mumlar = candles.Skip(i * 4).Take(4);
                    adim = 21;
                    var candleData = new CandleData();
                    adim = 22;
                    adim = 23;
                    foreach (var mum in mumlar)
                    {
                        adim = 24;
                        candleData.VolumeFrom += mum.VolumeFrom;
                        adim = 25;
                    }
                    adim = 26;
                    candleData.Close = mumlar.Last().Close;
                    adim = 27;
                    liste4Saatlik.Add(candleData);
                    adim = 28;
                }
                adim = 29;
                var volumesXcloses = liste4Saatlik.Select(x => x.Close * x.VolumeFrom).ToList();
                adim = 30;
                var closes = liste4Saatlik.Select(x => (Nullable<decimal>)x.Close).ToList();
                adim = 31;
                var volumes = liste4Saatlik.Select(x => x.VolumeFrom).ToList();
                adim = 32;
                var fastEma = volumesXcloses.Ema(fastperiod).Zip(volumes.Ema(fastperiod), (x, y) => x / y).ToList();
                adim = 33;
                var slowEma = volumesXcloses.Ema(slowperiod).Zip(volumes.Ema(slowperiod), (x, y) => x / y).ToList();
                adim = 34;
                var vwmacd = fastEma.Zip(slowEma, (x, y) => x - y).ToList();
                adim = 35;
                var signal = vwmacd.Ema(signalperiod).ToList();
                adim = 36;
                var hist = vwmacd.Zip(signal, (x, y) => x - y).ToList();
                adim = 37;
                var listeler = new Listeler();
                adim = 38;
                adim = 39;
                //kayitlar[sembol].Closes = closes;          
                //kayitlar[sembol].Vwmacd = vwmacd;                
                //kayitlar[sembol].Signal = signal;                
                //kayitlar[sembol].Hist = hist;
                listeler.Closes = closes;
                adim = 40;
                listeler.Vwmacd = vwmacd;
                adim = 41;
                listeler.Signal = signal;
                adim = 42;
                listeler.Hist = hist;
                adim = 43;
                ////@version=3
                //study("MavilimW", overlay=true)
                //M1= wma(close, 3)
                //M2= wma(M1, 5)
                //M3= wma(M2, 8)
                //M4= wma(M3, 13)
                //M5= wma(M4, 21)
                //MAVW= wma(M5, 34)
                //plot(MAVW, color=blue, linewidth=2)
                listeler.Wma = closes
                    .WeighteedMovingAverage(3)
                    .WeighteedMovingAverage(5)
                    .WeighteedMovingAverage(8)
                    .WeighteedMovingAverage(13)
                    .WeighteedMovingAverage(21)
                    .WeighteedMovingAverage(34);
                adim = 44;
                kayilardaYoksaEkleVarsaGuncelle(sembol, listeler);
                adim = 45;
                listBoxlariDoldur(sembol);
            }
            catch (Exception ex)
            {
                var temp = "Adım: " + adim.ToString();
                temp += ", " + ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    temp += ", " + ex.Message;
                }
                if (listBox_Hatalar.InvokeRequired)
                {
                    listBox_Hatalar.InvokeIfRequired(new MethodInvoker(delegate
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

        private void listBoxlariDoldur(string sembol)
        {
            if (!kayitlar.ContainsKey(sembol))            
                return;
            
            var kayit = kayitlar[sembol];

            label_KayitlarAdet.InvokeIfRequired((MethodInvoker)delegate ()
            {
                label_KayitlarAdet.Text = labelBaslangicMetinAl(label_KayitlarAdet.Text) + kayitlar.Count;
            });

            var closes = kayit.Closes;
            var signal = kayit.Signal;
            var vwmacd = kayit.Vwmacd;
            var hist = kayit.Hist;
            var wma = kayit.Wma;
            var closesCount = closes.Count;

            if (!closes.Any())
                return;
            var last = closes.Last();

            if (wma.Any())
            {
                if (araliktaMi(wma.Last(), last))
                {
                    listBox_Ortalamalar.InvokeIfRequired((MethodInvoker)delegate ()
                    {
                        listBox_Ortalamalar.Items.Add("Mavilim-" + sembol);
                    });
                }
            }

            if (hist.Any() && signal.Any() && vwmacd.Any())
            {              
                if (hist.Last().Value > 0)
                {
                    listBox_SinyalAlinanlar.InvokeIfRequired((MethodInvoker)delegate ()
                    {
                        listBox_SinyalAlinanlar.Items.Add(sembol);
                    });
                    label_VWMACDV2SinyalAdet.InvokeIfRequired((MethodInvoker)delegate ()
                    {
                        label_VWMACDV2SinyalAdet.Text = labelBaslangicMetinAl(label_VWMACDV2SinyalAdet.Text) + (Interlocked.Increment(ref sinyalAdet)).ToString();
                    });
                }
                else
                {
                    listBox_Diger.InvokeIfRequired((MethodInvoker)delegate ()
                    {
                        listBox_Diger.Items.Add(sembol);
                    });
                    label_DigerAdet.InvokeIfRequired((MethodInvoker)delegate ()
                    {
                        label_DigerAdet.Text = labelBaslangicMetinAl(label_DigerAdet.Text) + (Interlocked.Increment(ref digerAdet)).ToString();
                    });
                }
            }

            var ema144 = closes.Ema(144).Last();



            label_IslemeAlinanCoinAdedi.InvokeIfRequired((MethodInvoker)delegate ()
            {
                label_IslemeAlinanCoinAdedi.Text = labelBaslangicMetinAl(label_IslemeAlinanCoinAdedi.Text) + (Interlocked.Increment(ref sayac)).ToString();
            });

            if (araliktaMi(ema144, last))
            {
                listBox_Ortalamalar.InvokeIfRequired((MethodInvoker)delegate ()
                {
                    listBox_Ortalamalar.Items.Add("EMA144-" + sembol);
                });
            }
      
            var sma = closes.Sma(200).Last();
            if (araliktaMi(sma, last))
            {
                listBox_Ortalamalar.InvokeIfRequired((MethodInvoker)delegate ()
                {
                    listBox_Ortalamalar.Items.Add("SMA200-" + sembol);
                });
            }
            sma = closes.Sma(50).Last();
            if (sma.Equals(last))
            {
                listBox_Ortalamalar.InvokeIfRequired((MethodInvoker)delegate ()
                {
                    listBox_Ortalamalar.Items.Add("SMA50-" + sembol);
                });
            }         

        }

        private string labelBaslangicMetinAl(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || (str.IndexOf(':') < 0))
            {
                return string.Empty;
            }
            var temp= str.Remove(str.IndexOf(':')).Trim() + ": ";
            return temp;
        }

        bool araliktaMi(decimal? limit, decimal? deger)
        {
            return limit * 0.97m <= deger && deger <= limit * 1.03m;
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            _listedenSecilenCoiniAl(sender);
        }
        private void _listedenSecilenCoiniAl(object sender)
        {
            var temp = (ListBox)sender;
            if (temp.SelectedItem != null)
            {
                _coinGrafikCiz(temp.SelectedItem.ToString());
            }
        }
        private void _coinGrafikCiz(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (key.Contains("-"))
                key = key.Substring(key.IndexOf('-') + 1);
            if (kayitlar.ContainsKey(key))
            {       
                var closes = kayitlar[key].Closes;
                closes = closes.Where(x => x > 0).ToList();
                if (!closes.Any())
                    return;
                var vwmacd = kayitlar[key].Vwmacd;
                var count = vwmacd.Count;
                var signal = kayitlar[key].Signal;
                var hist = kayitlar[key].Hist;
                vwmacdList.Clear();
                signalList.Clear();
                histList.Clear();
                wmaList.Clear();
                closeListesi.Clear();
                closeSma200Listesi.Clear();
                closeSma50Listesi.Clear();
                closeEma144Listesi.Clear();
                var closesCount = closes.Count;
                var wma = kayitlar[key].Wma;
                for (int i = 0; i < count; i++)
                {
                    vwmacdListesineEkle(i, Convert.ToDouble(vwmacd[i]));
                    signalListesineEkle(i, Convert.ToDouble(signal[i]));
                    histListesineEkle(i, Convert.ToDouble(hist[i]));
                    closesListesineEkle(i, Convert.ToDouble(closes[i]));
                }
                count = wma.Count;
                for (int i = 0; i < count; i++)
                {
                    wmaListesineEkle(i, Convert.ToDouble(wma[i]));
                }
                if (closesCount >= 144)
                {
                    var ema144 = closes.Ema(144);
                    //closes = closes.Where(x => x.HasValue && x.Value > 0).ToList();

                    var t = ema144.Select(x => (double)(x.HasValue ? x.Value : 0.0m)).ToList();
                    for (int i = 0; i < t.Count; i++)
                    {
                        listeyeEkle(closeEma144Listesi, zedGraphControl3, i, t[i]);
                    }

                }
                if (closesCount >= 50)
                {
                    var sma50 = closes.Sma(50);

                    var y = sma50.Select(x => (double)(x.HasValue ? x.Value : 0.0m)).ToList();
                    for (int i = 0; i < y.Count; i++)
                    {
                        listeyeEkle(closeSma50Listesi, zedGraphControl3, i, y[i]);
                    }
                }
                if (closesCount >= 200)
                {
                    var sma200 = closes.Sma(200);
                    var k = sma200.Select(x => (double)(x.HasValue ? x.Value : 0.0m)).ToList();
                    for (int i = 0; i < k.Count; i++)
                    {
                        listeyeEkle(closeSma200Listesi, zedGraphControl3, i, k[i]);
                    }
                }
            }
        }
        private void listBox_AnlikSinyalAlinanlar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _listedenSecilenCoiniAl(sender);
        }
        private void listBox_SinyalAlinanlarHepsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox_Aktif.Checked)
            {
                _listedenSecilenCoiniAl(sender);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //    this.chart1.Series.Clear();
            //    var temp = kayitlar.First(x => x.Value.Closes.Any());
            //    this.chart1.Titles.Add(temp.Key);
            //    Series series = this.chart1.Series.Add("Closes");
            //    series.ChartType = SeriesChartType.Spline;
            //    var i=0;
            //    foreach (var close in temp.Value.Closes)
            //    {
            //        series.Points.AddXY((++i), close);
            //    }
            //    chart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "13", "Closes", "WMA");
        }
        private void kayilardaYoksaEkleVarsaGuncelle(string sembol, Listeler listeler)
        {
            lock (lockerKayitlar)
            {
                if (!kayitlar.ContainsKey(sembol))
                    kayitlar.Add(sembol, listeler);
                kayitlar[sembol] = listeler;
            }
        }
        private void listBox_Diger_DoubleClick(object sender, EventArgs e)
        {
            _listedenSecilenCoiniAl(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_Temizle_Click(object sender, EventArgs e)
        {
            listBox_SinyalAlinanlar.Items.Clear();
            listBox_Diger.Items.Clear();
            listBox_Ortalamalar.Items.Clear();
            kayitlar.Clear();
        }

        private void button_Kaydet_Click(object sender, EventArgs e)
        {
            var dosyaAdi = "kayitlar.binary";
            if (File.Exists(dosyaAdi))            
                File.Delete(dosyaAdi);

            if (!kayitlar.Any())            
                MessageBox.Show("Kayit Yok!");            

            File.WriteAllBytes(dosyaAdi, kayitlar.Serialize());

            MessageBox.Show("Kaydedildi");
        }

        private void button_Yukle_Click(object sender, EventArgs e)
        {
            var dosyaAdi = "kayitlar.binary";
            if (File.Exists(dosyaAdi))
            {
                kayitlar = (Dictionary<string, Listeler>)File.ReadAllBytes(dosyaAdi).DeSerialize();
                if (kayitlar != null && kayitlar.Any())
                {
                    foreach (var key in kayitlar.Keys)
                    {
                        listBoxlariDoldur(key);
                    }
                }
            }
        }
    }
}
//listBox_SinyalAlinanlar.InvokeIfRequired(new Action(() =>
//{
//    if (listBox_SinyalAlinanlar.Items.Contains(sembol))
//        listBox_SinyalAlinanlar.Items.Remove(sembol);
//}));
//listBox_Ortalamalar.InvokeIfRequired(new Action(() =>
//{
//    if (listBox_Ortalamalar.Items.Contains(sembol))
//        listBox_Ortalamalar.Items.Remove(sembol);
//}));
//listBox_Diger.InvokeIfRequired(new Action(() =>
//{
//    if (listBox_Diger.Items.Contains(sembol))
//        listBox_Diger.Items.Remove(sembol);
//}));
//listBox_SinyalAlinanlarHepsiContains(sembol);
//listBox_OrtalamalarContains(sembol);
//listBox_DigerEkleContains(sembol);
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
//private static readonly object lockerSinyalAlinanlarHepsi = new object();
//private static readonly object lockerListBox_Diger = new object();
//private static readonly object lockerListBox_Ortalamalar = new object(); 
//{
//try
//{
//    label_KayitlarAdet.InvokeIfRequired((MethodInvoker)delegate ()
//    {
//        label_KayitlarAdet.Text = "Kayıtlar Adet: " + kayitlar.Count;
//    });
//    var sinyalAdet = 0;
//    var digerAdet = 0;
//    var i = 0;
//    foreach (var kayit in kayitlar)
//    {
//        label_Sayac.InvokeIfRequired((MethodInvoker)delegate ()
//        {
//            label_Sayac.Text = (i++).ToString();
//        });
//        if (!kayit.Value.Closes.Any() || !kayit.Value.Hist.Any() || !kayit.Value.Signal.Any() || !kayit.Value.Vwmacd.Any())
//            continue;
//        var closes = kayit.Value.Closes;
//        var hist = kayit.Value.Hist;
//        var wma = kayit.Value.Wma;
//        var ema144 = closes.Ema(144).Last();
//        var last = closes.Last();
//        var sembol = kayit.Key;
//        if (araliktaMi(ema144, last))
//        {
//            listBox_Ortalamalar.InvokeIfRequired((MethodInvoker)delegate ()
//            {
//                listBox_Ortalamalar.Items.Add("EMA144-" + sembol);
//            });
//        }
//        var sma = closes.Sma(200).Last();
//        if (araliktaMi(sma, last))
//        {
//            listBox_Ortalamalar.InvokeIfRequired((MethodInvoker)delegate ()
//            {
//                listBox_Ortalamalar.Items.Add("SMA200-" + sembol);
//            });
//        }
//        sma = closes.Sma(50).Last();
//        if (sma.Equals(last))
//        {
//            listBox_Ortalamalar.InvokeIfRequired((MethodInvoker)delegate ()
//            {
//                listBox_Ortalamalar.Items.Add("SMA50-" + sembol);
//            });
//        }

//        ////@version=3
//        //study("MavilimW", overlay=true)
//        //M1= wma(close, 3)
//        //M2= wma(M1, 5)
//        //M3= wma(M2, 8)
//        //M4= wma(M3, 13)
//        //M5= wma(M4, 21)
//        //MAVW= wma(M5, 34)
//        //plot(MAVW, color=blue, linewidth=2)              


//        if (araliktaMi(wma.Last(), last))
//        {
//            listBox_Ortalamalar.InvokeIfRequired((MethodInvoker)delegate ()
//            {
//                listBox_Ortalamalar.Items.Add("Mavilim-" + sembol);
//            });
//        }



//        if (hist.Last().Value > 0)
//        {
//            listBox_SinyalAlinanlar.InvokeIfRequired((MethodInvoker)delegate ()
//            {
//                listBox_SinyalAlinanlar.Items.Add(sembol);
//            });
//            label_SinyalAdet.InvokeIfRequired((MethodInvoker)delegate ()
//            {
//                label_SinyalAdet.Text = "Sinyal Adet: " + (sinyalAdet++).ToString();
//            });
//        }
//        else
//        {
//            listBox_Diger.InvokeIfRequired((MethodInvoker)delegate ()
//            {
//                listBox_Diger.Items.Add(sembol);
//            });
//            label_DigerAdet.InvokeIfRequired((MethodInvoker)delegate ()
//            {
//                label_DigerAdet.Text = "Diğer Adet: " + (digerAdet++).ToString();
//            });
//        }
//    }

//    }
//catch (Exception ex)
//{
//    var temp = string.Empty;
//    temp += ", " + ex.Message;
//    while (ex.InnerException != null)
//    {
//        ex = ex.InnerException;
//        temp += ", " + ex.Message;
//    }
//    if (listBox_Hatalar.InvokeRequired)
//    {
//        listBox_Hatalar.InvokeIfRequired(new MethodInvoker(delegate
//        {
//            listBox_Hatalar.Items.Add(temp);
//            listBox_Hatalar.TopIndex = Math.Max(listBox_Hatalar.Items.Count - listBox_Hatalar.ClientSize.Height / listBox_Hatalar.ItemHeight + 1, 0);
//            listBox_Hatalar.Refresh();
//        }));
//    }
//    else
//    {
//        listBox_Hatalar.Items.Add(temp);
//        listBox_Hatalar.TopIndex = Math.Max(listBox_Hatalar.Items.Count - listBox_Hatalar.ClientSize.Height / listBox_Hatalar.ItemHeight + 1, 0);
//        listBox_Hatalar.Refresh();
//    }
//}
//});          

