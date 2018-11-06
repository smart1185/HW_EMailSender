using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.model
{
    class SendMail
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="to">Кому</param>
        /// <param name="toCopy">Копия</param>
        /// <param name="subject">Тема</param>
        /// <param name="body">Сбщ</param>
        /// <param name="message">Сообщение</param>
        /// <returns></returns>
        public static bool SendMaiL(string to, string toCopy,
            string subject, string body, out string message)
        {
            bool result = false;

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(to));
            msg.CC.Add(new MailAddress(toCopy));
            msg.Subject = subject;
            msg.Body = body;
            msg.From = new MailAddress("s_mart11@mail.ru", "Step test");

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.mail.ru";//"smtp.gmail.com";
            smtp.Port = 465;//587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("s_mart11@mail.ru","***********");

            try
            {
                smtp.Send(msg);
                message = "Сообщение отправлено";
                result = true;
            }
            catch(Exception ex)
            {
                message = ex.Message;
                result = false;
            }
            return result;
        }
    }
}
