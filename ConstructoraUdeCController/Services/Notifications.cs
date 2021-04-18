using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Services
{
    public class Notifications
    {
        public Boolean SendEmail(string subject, string content, string toName,string toEmail)
        {
            string apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("jose.1701722372@ucaldas.edu.co", "Constructora UdeC");
           
            var to = new EmailAddress(toEmail, toName);
            var plainTextContent = content;
            var htmlContent =content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response =  client.SendEmailAsync(msg);
            return true;
        }
        public Boolean SendSMS(string content, string to, string from)
        {
            //twillio service
            return true;
        }
    }
}
