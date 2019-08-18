using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace MyPorftolioProject.ViewModel
{
    public class MailSend
    {
        public void SendMail(string _from, string _subject, string _body)
        {
            SmtpClient ss = new SmtpClient("smtp.gmail.com", 587);  // Genelde mail.domain.com şeklinde olan smtp mail sunucu adresinizi girmelisiniz.
            ss.Timeout = 10000;
            ss.DeliveryMethod = SmtpDeliveryMethod.Network;
            ss.UseDefaultCredentials = false;
            ss.Credentials = new NetworkCredential("panah01rh@gmail.com", "panah1994.04.19");  // mail adresinizi ve şifrenizi giriyorsunuz 
            MailMessage mm = new MailMessage(_subject + "<panahrh@code.edu.az>", "panahrh@code.edu.az");   // tekrar mail adresinizi yazıyorsunuz, alıcı mail adresini giriyorsunuz
            mm.IsBodyHtml = true;   // Mail içeriğinde html kullanılacaksa true, mail içereğinde htmli engellemek için false giriniz.
            mm.Subject = "E-mail from: " + _from;   // Mailinizin Konusunu, başlığını giriyorsunuz
            mm.Body = _body;  // Göndereceğiniz mailin içeriğini girin, IsBodyHtml = true yaptıysanız html etiketlerini de kullanabilirsiniz.
            ss.EnableSsl = true; // Sunucunuz mail göndermek için ssl gerektiriyorsa true, gerektirmiyorsa false girin. Genel olarak false girilir.
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            ss.Send(mm);
        }

    }
}