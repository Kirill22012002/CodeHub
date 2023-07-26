using CodeHub.DTO;
using CodeHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeHub.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> SendEmail([FromQuery] string emailAddress, [FromQuery] string subject, [FromQuery] string body)
        {
            var sendEmailDto = new SendEmailDto
            {
                ToEmail = emailAddress,
                Subject = subject,
                Body = body
            };

            await _emailService.SendEmailAsync(sendEmailDto);

            return StatusCode(200);
        }
    }
}