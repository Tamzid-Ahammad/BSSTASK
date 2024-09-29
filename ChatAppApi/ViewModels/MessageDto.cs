using ChatAppApi.Model;
using System.Text.Json.Serialization;

namespace ChatAppApi.ViewModels
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
      
        public DateTime MessageDate { get; set; }
        public Guid UserId { get; set; }

        public Guid ConversationId { get; set; }
    
    }
}
