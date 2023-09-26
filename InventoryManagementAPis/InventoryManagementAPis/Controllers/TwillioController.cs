using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using InventoryManagementAPis.Model;

namespace InventoryManagementAPis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioController : ControllerBase
    {
        private readonly TwilioService _twilioService;

        public TwilioController(IConfiguration configuration)
        {
            var twilioSettings = configuration.GetSection("Twilio").Get<TwilioSettings>();
            _twilioService = new TwilioService(
                twilioSettings.AccountSid,
                twilioSettings.AuthToken,
                twilioSettings.PhoneNumber
            );
        }

        [HttpPost("send-whatsapp")]
        public IActionResult SendWhatsAppMessage([FromBody] WhatsAppMessageModel messageModel)
        {
            try
            {
                _twilioService.SendWhatsAppMessage(messageModel.ToPhoneNumber, messageModel.Message);
                return Ok("WhatsApp message sent successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to send WhatsApp message: " + ex.Message);
            }
        }
    }
}
