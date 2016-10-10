using System.Configuration;

namespace SendMail.Infrastructure
{
    public static class Settings
    {
        public static string DefaultRecipientAddress 
            => ConfigurationManager.AppSettings["DefaultRecipientAddress"];

        public static string DefaultSenderAddress
            => ConfigurationManager.AppSettings["DefaultSenderAddress"];

        public static string ApiKey 
            => ConfigurationManager.AppSettings["ApiKey"];
    }
}
