using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Biblioteca.Services.SMS
{
    public class SmsSender
    {
        private readonly string _accountSidValue;
        private readonly string _authTokenValue;
        private readonly string _senderPhoneNumber;

        // Construtor
        public SmsSender(string accountSid, string authToken, string fromNumber)
        {
            _accountSidValue = accountSid;
            _authTokenValue = authToken;
            _senderPhoneNumber = fromNumber;
        }

        // Método para enviar SMS
        public void SendSms(string recipientPhoneNumber, string messageBody)
        {
            TwilioClient.Init(_accountSidValue, _authTokenValue);

            var messageOptions = new CreateMessageOptions(new PhoneNumber(recipientPhoneNumber))
            {
                From = new PhoneNumber(_senderPhoneNumber),
                Body = messageBody
            };

            MessageResource.Create(messageOptions);
        }
    }
}
