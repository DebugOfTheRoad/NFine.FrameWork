using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace NFine.Code.Mail
{
    public class MailHelper
    {
        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        public string MailServer
        {
            get; set;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string MailUserName
        {
            get; set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string MailPassword
        {
            get; set;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string MailName
        {
            get; set;
        }

        public bool Send(string to, string subject, string body, string encoding = "UTF-8",
            bool isBodyHtml = true, bool enableSsl = false)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress(MailUserName, MailName);
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = body;

                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;

                SmtpClient client = new SmtpClient(MailServer, 25)
                {
                    Credentials = new NetworkCredential(MailUserName, MailPassword),
                    EnableSsl = enableSsl
                };
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
