namespace ApiProject.WebAPI.Dtos.MessageDtos
{
    public class GetByIdMessageDto
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
