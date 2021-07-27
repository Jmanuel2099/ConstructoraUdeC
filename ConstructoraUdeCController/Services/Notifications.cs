using SendGrid;
using SendGrid.Helpers.Mail;
using System;

namespace ConstructoraUdeCController.Services
{
    public class Notifications
    {
        public Boolean SendEmail(string subject, string content, string toName, string toEmail)
        {
            string apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("jose.1701722372@ucaldas.edu.co", "Constructora UdeC");
            var to = new EmailAddress(toEmail, toName);
            var plainTextContent = content;
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
            return true;
        }
        //public Boolean SendEmail(string subject, string content, string toName, string toEmail)
        //{
        //    //la appi key no se puede quemar en el codigo porque al subirlo a github sendgrid me bloquea la cuenta
        //    string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        //    var client = new SendGridClient(apiKey);
        //    string emailFrom = System.Configuration.ConfigurationSettings.AppSettings["emailFromSendGrid"];
        //    string namelFrom = System.Configuration.ConfigurationSettings.AppSettings["nameFromSendGrid"];
        //    var from = new EmailAddress(emailFrom, namelFrom);
        //    //var subject = "Sending with SendGrid is Fun";
        //    var to = new EmailAddress(toEmail, toName);
        //    var plainTextContent = content;
        //    var htmlContent = content;
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = client.SendEmailAsync(msg);
        //    return true;
        //}
        public Boolean SendSMS(string subject, string content, string to, string from)
        {
            //twillio service
            return true;
        }
    }
}
