namespace ApiProject.WebAPI.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SentTime { get; set; }
        public bool IsRead { get; set; }
    }
}
