using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.MerchantStore
{
    public class RealEmailSender : INotifier
    {
        private readonly string _to;
        private readonly string _subj;
        private readonly string _body;
        private string from = "support@ssebnet.com";
        SmtpClient smtpClient;

        public RealEmailSender(string to, string subj, string body)
        {
            _to = to;
            _subj = subj;
            _body = $"<div style='padding : 50px; border : 2px dotted #ff2444; border-radius: 20px; font-size:18px; font-family:arial; '>" +
                    $"<h2>CyberAcademy Class Work</h2>" +
                    $"<hr />" +
                    $"{body}" +
                    $"</div>";
            // read SMTP mail config
            InitSmtp();
        }

        private void InitSmtp()
        {
            smtpClient = new SmtpClient(Config.SmtpServerAddress, Config.SmtpServerPort);
            smtpClient.Credentials = new NetworkCredential(Config.SmtpServerId, Config.SmtpServerPassword);
        }

        public async Task SendNotification()
        {
            try
            {
                MailMessage mail = new MailMessage(@from, _to, _subj, _body);
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                new Thread(() => { smtpClient.Send(mail); Console.WriteLine("Mail Sent"); }).Start();
            }
            catch (SmtpException err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}