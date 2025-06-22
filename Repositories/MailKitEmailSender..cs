using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Repositories
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public MailKitEmailSender(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Tạo email message
            var emailMessage = new MimeMessage();

            // From (người gửi)
            emailMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            // To (người nhận)
            emailMessage.To.Add(MailboxAddress.Parse(email));
            // Tiêu đề email
            emailMessage.Subject = subject;

            // Nội dung email (định dạng html)
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();

            // Kết nối tới SMTP server và gửi mail
            using var client = new SmtpClient();

            // Kết nối server SMTP (Gmail, Outlook,...)
            await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, _emailSettings.UseSSL);

            // Đăng nhập tài khoản email (nếu server yêu cầu)
            await client.AuthenticateAsync(_emailSettings.MailUserName, _emailSettings.MailPassword);

            // Gửi email
            await client.SendAsync(emailMessage);

            // Ngắt kết nối
            await client.DisconnectAsync(true);
        }
    }

}
