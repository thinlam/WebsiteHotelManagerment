namespace WebsiteHotelManagerment.Models
{
    public class EmailSettings
    {
        public string MailServer { get; set; }      // smtp.gmail.com
        public int MailPort { get; set; }           // 587 hoặc 465 (SSL)
        public bool UseSSL { get; set; }            // true hoặc false
        public string MailUserName { get; set; }    // email đăng nhập SMTP
        public string MailPassword { get; set; }    // mật khẩu hoặc app password
        public string SenderEmail { get; set; }     // email người gửi (thường giống MailUserName)
        public string SenderName { get; set; }      // tên người gửi hiển thị trên mail
    }

}
