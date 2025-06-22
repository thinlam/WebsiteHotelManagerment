namespace WebsiteHotelManagerment.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string SenderId { get; set; }  // user id của người gửi

        public string ReceiverId { get; set; } // user id người nhận

        public string Content { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;

        // navigation properties nếu dùng IdentityUser
        public virtual ApplicationUser Sender { get; set; }

        public virtual ApplicationUser Receiver { get; set; }
    }

}
