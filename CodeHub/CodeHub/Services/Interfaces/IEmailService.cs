using CodeHub.DTO;

namespace CodeHub.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(SendEmailDto dto);
    }
}
