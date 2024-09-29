using System.ComponentModel.DataAnnotations.Schema;

namespace ChatAppApi.Model
{
    [Table("Conversation")]
    public class Conversation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UsersConversation> UsersConversations { get; set; }

    }
}
