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
        RollingPointPairList vwmacdList = new RollingPointPairList(610);
        RollingPointPairList signalList = new RollingPointPairList(610);
        RollingPointPairList histList = new RollingPointPairList(610);
        Dictionary<string, Tuple<List<decimal?>, List<decimal?>, List<decimal?>>> kayitlar = new Dictionary<string, Tuple<List<decimal?>, List<decimal?>, List<decimal?>>>();
        private static readonly object locker = new object();
        public Form1()
        {
            InitializeComponent();

            var myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "VWMACDV2";
            myPane.XAxis.Title.Text = "4 Saatlik Arallıklar";
            myPane.YAxis.Title.Text = "Ema'lar";
            myPane.XAxis.Scale.MaxAuto= true;

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
            //var client = new CryptoCompareClient();
            //var response = client.History.HourAsync("QKC", "BTC", 986, "Binance");
            //var temp = response.Result.Data.Where(x => x.Close > 0).ToList();
            //foreach (var item in temp)
            //{
            //    Console.WriteLine(item.Time + " => " + item.Close + "  =>  " + item.VolumeFrom + " => " + item.VolumeTo);
            //}
            using (var binanceClient = new BinanceClient())
            {
                binanceClient.GetAllPrices().Data
                   .Where(x => x.Symbol.EndsWith("BTC"))
                   .Select(x => x.Symbol = x.Symbol.Replace("BTC", ""))
                   .AsParallel()
                   .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                   .ForAll(x => signalAl(x));
            }
        }

        private static void ekle(string sembol)
        {
            lock (locker)
            {
                //if (!signalGelenler.Contains(sembol))
                //{
                //    Console.WriteLine("Yeni Eklendi: " + sembol);
                //    dataTable.Rows.Add(sembol);
                //    Console.Beep(1000, 1000);
                //}
                //signalGelenler.Add(sembol);
            }
        }
        private static void cikar(string sembol)
        {
            lock (locker)
            {
                //signalGelenler.Remove(sembol);

                //for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
                //{
                //    DataRow dr = dataTable.Rows[i];
                //    if (dr["Sembol"].ToString() == sembol)
                //    {
                //        dr.Delete();
                //        break;
                //    }
            }
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


        private async Task signalAl(string symbol)
        {
  

            var client = new CryptoCompareClient();
            var fastperiod = 12;
            var slowperiod = 26;
            var signalperiod = 9;
            var history = await client.History.HourAsync(symbol, "BTC", 609, "Binance");
            var liste = history.Data;
            var candles = liste.Where(x => x.Close > 0).ToList();
            var kalan = candles.Count % 4;
            candles = candles.Skip(kalan).ToList();
            List<CandleData> listem4lu = new List<CandleData>();
            var son = candles.Count / 4;
            for (int i = 0; i < son; i++)
            {
                var temp = candles.Skip(i * 4).Take(4);
                CandleData candleData = new CandleData();
                foreach (var item in temp)
                {

                    candleData.VolumeFrom += item.VolumeFrom;
                }
                candleData.Close = temp.Last().Close;
                //candleData.VolumeFrom = candleData.VolumeFrom / 4;
                listem4lu.Add(candleData);
            }


            var volumesXcloses = listem4lu.Select(x => x.Close * x.VolumeFrom).ToList();
            var closes = listem4lu.Select(x => x.Close).ToList();
            var volumes = listem4lu.Select(x => x.VolumeFrom).ToList();
            /*
                fastMA = ema(volume*close, fastperiod)/ema(volume, fastperiod)
                slowMA = ema(volume*close, slowperiod)/ema(volume, slowperiod)
                vwmacd = fastMA - slowMA
                signal = ema(vwmacd, signalperiod)    
                hist= vwmacd - signal
             */
            var fastEma = volumesXcloses.Ema(fastperiod).Zip(volumes.Ema(fastperiod), (x, y) => { return x / y; }).ToList();
            var slowEma = volumesXcloses.Ema(slowperiod).Zip(volumes.Ema(slowperiod), (x, y) => { return x / y; }).ToList();
            var vwmacd = fastEma.Zip(slowEma, (x, y) => { return x - y; }).ToList();
            var signal = vwmacd.Ema(signalperiod).ToList();
            var hist = vwmacd.Zip(signal, (x, y) => { return x - y; }).ToList();
            //signalLast = signal.Last();
            //vwmacdLast = vwmacd.Last();    

            if (kayitlar.ContainsKey(symbol))
                kayitlar.Remove(symbol);

            if (listBox1.Items.Contains(symbol))
                listBox1.Items.Remove(symbol);

            if (signal.Last().Value > vwmacd.Last().Value)
            {
                kayitlar.Add(symbol, new Tuple<List<decimal?>, List<decimal?>, List<decimal?>>(vwmacd, signal, hist));
                listBox1.Items.Add(symbol);
            }

            //for (int i = 0; i < 152; i++)
            //{
            //    vwmacdListesineEkle(i, Convert.ToDouble(vwmacd[i]));
            //    signalListesineEkle(i, Convert.ToDouble(signal[i]));
            //    histListesineEkle( i,Convert.ToDouble(hist[i]));
            //}    

            //if (vwmacd.Last() > signal.Last())
            //{
            //    ekle(symbol);
            //}
            //else
            //{
            //    cikar(symbol);
            //}
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var key = listBox1.SelectedItem.ToString();
                MessageBox.Show(key);
                if (kayitlar.ContainsKey(key))
                {
                    vwmacdList.Clear();
                    signalList.Clear();
                    histList.Clear();
                    var vwmacd = kayitlar[key].Item1;
                    var count = vwmacd.Count;
                    var signal = kayitlar[key].Item2;
                    var hist = kayitlar[key].Item3;
                    for (int i = 0; i < count; i++)
                    {
                        vwmacdListesineEkle(i, Convert.ToDouble(vwmacd[i]));
                        signalListesineEkle(i, Convert.ToDouble(signal[i]));
                        histListesineEkle(i, Convert.ToDouble(hist[i]));
                    }

                    label1.Text = vwmacd.Last().Value.ToString();
                    label2.Text = signal.Last().Value.ToString();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
