using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
namespace WebsiteHotelManagerment.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Bạn có thể ghi log hoặc làm gì đó nếu muốn, hiện tại là giả lập không gửi mail thật
            return Task.CompletedTask;
        }
    }
}
