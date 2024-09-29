using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChatAppApi.Model
{
    [Table("Messages")]
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid UsersConversationId { get; set; }
        public DateTime MessageDate { get; set; }
        [JsonIgnore]
        public UsersConversation UsersConversation { get; set; }
    }
}
