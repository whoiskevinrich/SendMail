using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendMail.Infrastructure;

namespace SendMail.Services
{
    public class MailService
    {
        public async Task Execute(string toaddress, string subject, string body)
        {
            var from = new Email(Settings.DefaultSenderAddress);
            var to = new Email(toaddress);
            var messagebody = body;

            var content = new Content("text/html", messagebody);
            var mail = new Mail(from, subject, to, content);

            Console.WriteLine($"From: {from.Address}");
            Console.WriteLine($"To: {to.Address}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body:\n {body}");


            var sendgrid = new SendGridAPIClient(Settings.ApiKey);

            var response = await sendgrid.client.mail.send.post(requestBody: mail.Get());

            Console.WriteLine($"Response: {response.StatusCode}");
        }
    }
}