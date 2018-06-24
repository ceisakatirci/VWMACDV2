using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace VWMACDV2.WinForms
{
    public static class ObjectSerialize
    {
        public static byte[] Serialize(this Object obj)
        {
            if (obj == null)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(memoryStream, obj);

                var compressed = Compress(memoryStream.ToArray());
                return compressed;
            }
        }

        public static Object DeSerialize(this byte[] arrBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                var decompressed = Decompress(arrBytes);

                memoryStream.Write(decompressed, 0, decompressed.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);

                return binaryFormatter.Deserialize(memoryStream);
            }
        }

        public static byte[] Compress(byte[] input)
        {
            byte[] compressesData;

            using (var outputStream = new MemoryStream())
            {
                using (var zip = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    zip.Write(input, 0, input.Length);
                }

                compressesData = outputStream.ToArray();
            }

            return compressesData;
        }

        public static byte[] Decompress(byte[] input)
        {
            byte[] decompressedData;

            using (var outputStream = new MemoryStream())
            {
                using (var inputStream = new MemoryStream(input))
                {
                    using (var zip = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        zip.CopyTo(outputStream);
                    }
                }

                decompressedData = outputStream.ToArray();
            }

            return decompressedData;
        }
    }
    static class MyClass
    {
        public static void InvokeIfRequired(this ISynchronizeInvoke obj, MethodInvoker action)
        {
            if (obj.InvokeRequired)
            {
                var args = new object[0];
                obj.Invoke(action, args);
            }
            else
            {
                action();
            }
        }

        public static List<decimal?> WeighteedMovingAverage(this List<decimal?> data, int periyot)
        {
            var agirlikliHareketliOrtalamalar = new List<decimal?>();
            var dataKopya = new List<decimal?>(data);
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
                    for (int j = 0; j < k; j++)
                    {
                        temp.Add(sonEleman);
                    }
                }


                List<decimal?> tempList = new List<decimal?>();
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



    class EpostaSorumlusu
    {
        public static void Gonder(string mesaj)
        {
            //SmtpClient sc = new SmtpClient();
            //sc.Port = 587;
            //sc.Host = "smtp.gmail.com";
            //sc.EnableSsl = true;
            //sc.UseDefaultCredentials = false;
            //sc.Credentials = new NetworkCredential("adayazilim.isa@gmail.com", "***");

            //MailMessage mail = new MailMessage();


            //mail.From = new MailAddress("mustafa@adayazilim.com", "Mustafa Kemal Yıldız");

            //mail.ReplyToList.Add("mustafa@adayazilim.com");

            //mail.To.Add("adayazilim.isa@gmail.com");
            ////mail.CC.Add("alici3@mail.com");
            //mail.Subject = "E-Posta Konusu";
            //mail.IsBodyHtml = true;
            //mail.Body = "E-Posta İçeriği";


            //var attachment = new Attachment(@"DOA- Acente_Police_XML_Ciktisi_20180608_0928_7041400.xml");
            //string contentID = "test001@host";
            //attachment.ContentId = contentID;
            //mail.Attachments.Add(attachment);
            ////mail.Attachments.Add(new Attachment(@"C:\Sonuc.pptx"));
            //mail.IsBodyHtml=true;




            //sc.Send(mail);
        }
    }

}
