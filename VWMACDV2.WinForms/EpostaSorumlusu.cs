using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace VWMACDV2.WinForms
{
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
