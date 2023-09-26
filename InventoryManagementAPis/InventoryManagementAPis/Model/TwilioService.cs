using Twilio;
using Twilio.Rest.Api.V2010.Account;

public class TwilioService
{
    private readonly string _accountSid;
    private readonly string _authToken;
    private readonly string _twilioPhoneNumber;

    public TwilioService(string accountSid, string authToken, string twilioPhoneNumber)
    {
        _accountSid = accountSid;
        _authToken = authToken;
        _twilioPhoneNumber = twilioPhoneNumber;
        TwilioClient.Init(_accountSid, _authToken);
    }

    public void SendWhatsAppMessage(string toPhoneNumber, string message)
    {
        MessageResource.Create(
            body: message,
            from: new Twilio.Types.PhoneNumber("whatsapp:" + _twilioPhoneNumber),
            to: new Twilio.Types.PhoneNumber("whatsapp:" + toPhoneNumber)
        );
    }
}
