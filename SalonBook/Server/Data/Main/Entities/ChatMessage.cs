namespace SalonBook.Server.Data.Main.Entities
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public Guid To { get; set; }
        public Guid From { get; set; }
        public string Message { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
