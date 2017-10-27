using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Threading.Tasks;
using Twilio.Clients;

namespace SoT.Infra.CrossCutting.Identity.Configuration
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            if (ConfigurationManager.AppSettings["Internet"] == "true")
            {
                // Using TWILIO as the SMS Provider.
                // https://www.twilio.com/docs/quickstart/csharp/sms/sending-via-rest

                const string accountSid = "ACCOUNT ID";
                const string authToken = "ACCOUNT TOKEN";

                var client = new TwilioRestClient(accountSid, authToken);

                // TODO: send twilio SMS
                //client.SendMessage("814-350-7742", message.Destination, message.Body);
            }

            return Task.FromResult(0);
        }
    }
}
