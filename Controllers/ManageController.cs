// Services/SmsSender.cs
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public class SmsSender
{
    private readonly string _accountSid;
    private readonly string _authToken;
    private readonly string _fromNumber;

    public SmsSender(string accountSid, string authToken, string fromNumber)
    {
        _accountSid = accountSid;
        _authToken = authToken;
        _fromNumber = fromNumber;
    }

    public void SendSms(string toNumber, string message)
    {
        TwilioClient.Init(_accountSid, _authToken);

        var messageOptions = new CreateMessageOptions(new PhoneNumber(toNumber))
        {
            From = new PhoneNumber(_fromNumber),
            Body = message
        };

        MessageResource.Create(messageOptions);
    }
}
