namespace ApiProject.WebAPI.Entities
{
    public class ContactMessage
    {
        public int ContactMessageId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SentTime { get; set; }
        public bool IsRead { get; set; }
    }
}
