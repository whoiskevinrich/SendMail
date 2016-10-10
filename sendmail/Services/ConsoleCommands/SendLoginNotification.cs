using System;
using ManyConsole;
using SendMail.Infrastructure;

namespace SendMail.Services.ConsoleCommands
{
    public class SendLoginNotification : ConsoleCommand
    {
        private const int Success = 0;
        private const int Failure = 2;

        private string _toAddress = Settings.DefaultRecipientAddress;
        private string _subject;
        private string _body;

        private readonly string _footer = $"<p>{Environment.MachineName}\\{Environment.UserName}</p>" +
                                 $"<p>{DateTimeOffset.Now}</p>";

        public SendLoginNotification()
        {
            IsCommand("SendUserInformation", "Identify Current user");

            HasLongDescription("Sends an email with the current user/machine names");

            HasRequiredOption("s|subject=", "Message Subject", x => _subject = x);

            HasOption("b|body=", "Message to send with login information", x => _body = x);
            HasOption("t|to=", $"Recipient email, default is {Settings.DefaultRecipientAddress}", x => _toAddress = x);
        }

        public override int Run(string[] args)
        {
            try
            {
                _body = string.IsNullOrEmpty(_body)
                    ? _footer
                    : $"{_body}<br/>{_footer}";

                var sender = new MailService();
                sender.Execute(_toAddress, _subject, _body).Wait();
                return Success;
            }
            catch (Exception)
            {
                return Failure;
            }
        }
    }
}