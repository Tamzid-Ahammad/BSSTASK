using ChatAppApi.Model;

namespace ChatAppApi.Interfaces
{
    public interface IConversationRepository
    {
        Task<Conversation> GetConversationByIdAsync(Guid conversationId);
        Task<ICollection<Conversation>> GetUserConversationsAsync(Guid userId);
        Task<Conversation> CreateConversationAsync(Conversation conversation);
        Task DeleteConversationAsync(Guid conversationId);
        Task<Conversation> GetOrCreate(Guid myUserId, Guid targetUserId);
        
    }
}
