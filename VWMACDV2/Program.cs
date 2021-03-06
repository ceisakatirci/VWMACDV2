﻿using Binance.Net;
using CryptoCompare;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Trady.Analysis;

namespace VWMACDV2
{
    static class MyClass
    {
        public static List<decimal> WeighteedMovingAverage(this List<decimal> data, int periyot)
        {
            var agirlikliHareketliOrtalamalar = new List<decimal>();
            var dataKopya = new List<decimal>(data);
            var p = (periyot * (periyot + 1) / 2);
            //(Price X weighting factor) + (Price previous period X weighting factor-1)...
            //((90 x (4/10)) + (89 x (3/10)) + (88 x (2/10)) + (89 x (1/10)) = 36 + 26.7 + 17.6 + 8.9 = 89.2
            if (!dataKopya.Any())
            {
                return agirlikliHareketliOrtalamalar;
            }
            dataKopya.Reverse();
            var limit = dataKopya.Count();
            var sonEleman = dataKopya[limit - 1];
            for (int i = 0; i < limit; i++)
            {
                var temp = dataKopya.Skip(i).Take(periyot).ToList();
                if (!temp.Any())
                    break;               

                var count = temp.Count();
                if (count < periyot)
                {
                    var k = periyot - count;
                    for (int j = 0; j <k; j++)
                    {
                        temp.Add(sonEleman);
                    }
                }


                List<decimal> tempList = new List<decimal>();
                for (int j = 0; j < periyot; j++)
                {
                    var g = (periyot - j);
                    var h = temp[j];
                    var t = (h * g);
                    tempList.Add(t);
                }
               
                var s = tempList.Sum();
                agirlikliHareketliOrtalamalar.Add(s / p);
            }
            return agirlikliHareketliOrtalamalar;
        }
    }
    class Program
    {
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
        private static HashSet<string> signalGelenler = new HashSet<string>();
        private static DataTable dataTable = new DataTable("SignalGelenler");
        private static readonly object locker = new object();
        static Program()
        {
            dataTable.Columns.Add("Sembol", typeof(string));
            if (File.Exists("SignalGelenler.xlm"))            
                dataTable.ReadXml("SignalGelenler.xlm");

            foreach (DataRow satir in dataTable.Rows)
            {
                signalGelenler.Add(satir[0].ToString());
            }

        }
        private static void ekle(string sembol)
        {
            lock (locker)
            {
                if (!signalGelenler.Contains(sembol))
                {
                    Console.WriteLine("Yeni Eklendi: " + sembol);
                    dataTable.Rows.Add(sembol);
                    Console.Beep(1000, 1000);
                }
                signalGelenler.Add(sembol);
            }
        }
        private static void cikar(string sembol)
        {
            lock (locker)
            {
                signalGelenler.Remove(sembol);

                for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dataTable.Rows[i];
                    if (dr["Sembol"].ToString() == sembol)
                    {
                        dr.Delete();
                        break;
                    }                      
                }            
            }
        }

        private static void _zamanDoldugundaCalistir(object source, ElapsedEventArgs e)
        {
            Console.Clear();
            using (var binanceClient = new BinanceClient())
            {
                binanceClient.GetAllPrices().Data
                   .Where(x => x.Symbol.EndsWith("BTC"))
                   .Select(x => x.Symbol = x.Symbol.Replace("BTC", ""))
                   .Take(1)
                   .AsParallel()
                   .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                   .ForAll(x => signalAl(x));
            }
        }
        static CancellationTokenSource cts = new CancellationTokenSource();

        static void Main(string[] args)
        {

            var temp = new decimal[] { 90m, 80m, 70m, 85m, 56m, 80m, 70m, 85m }.ToList().WeighteedMovingAverage(3)
                    .WeighteedMovingAverage(5)
                    .WeighteedMovingAverage(8);
                    //.WeighteedMovingAverage(13)
                    //.WeighteedMovingAverage(21)
                    //.WeighteedMovingAverage(34);
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(temp.Count);
            //_zamanDoldugundaCalistir(null, null);
            //var aralik = 60 * 60 * 1000;
            //var t = new System.Timers.Timer { Interval = aralik };
            //t.Elapsed += _zamanDoldugundaCalistir;
            //t.Start();
            //var i = 0;
            //var cik = true;
            //while (cik)
            //{
            //    Console.WriteLine("Çalışıyor.. " + ++i);
            //    Thread.Sleep(TimeSpan.FromSeconds(1));
            //    Task.Run(() => {
            //        if (Console.ReadLine().Equals("Q"))
            //        {
            //            dataTable.WriteXml("SignalGelenler.xlm");
            //            cik = false;
            //        }
            //    });            
            //}

        }

        private static async Task signalAl(string symbol="QKC")
        {
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

            var client = new CryptoCompareClient();
            var fastperiod = 12;
            var slowperiod = 26;
            var signalperiod = 9;
            var history = await client.History.HourAsync(symbol, "BTC", 986, "Binance");
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
                    candleData.Close += item.Close;
                    candleData.VolumeFrom += item.VolumeFrom;
                }
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
             */
            var fastEma = volumesXcloses.Ema(fastperiod).Zip(volumes.Ema(fastperiod), (x, y) => { return x / y; }).ToList();
            var slowEma = volumesXcloses.Ema(slowperiod).Zip(volumes.Ema(slowperiod), (x, y) => { return x / y; }).ToList();
            var vwmacd = fastEma.Zip(slowEma, (x, y) => { return x - y; }).ToList();
            var signal = vwmacd.Ema(signalperiod);
            //signalLast = signal.Last();
            //vwmacdLast = vwmacd.Last();           
            if (vwmacd.Last() > signal.Last())
            {
                ekle(symbol);
            }
            else
            {
                cikar(symbol);
            }
        }
    }
}
