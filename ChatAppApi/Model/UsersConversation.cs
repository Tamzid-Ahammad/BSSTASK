using System.ComponentModel.DataAnnotations.Schema;

namespace ChatAppApi.Model
{
    [Table("UsersConversation")]
    public class UsersConversation
    {
        public Guid Id { get; set; }
        public Guid UserId {  get; set; }

        public Guid ConversationId { get; set; }

        public Conversation Conversation { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
