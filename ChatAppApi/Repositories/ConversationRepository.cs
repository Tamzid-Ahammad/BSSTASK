using ChatAppApi.Data;
using ChatAppApi.Interfaces;
using ChatAppApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ChatAppApi.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly ApplicationDbContext _context;
        public ConversationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Conversation> GetConversationByIdAsync(Guid conversationId)
        {
            return await _context.Conversations
                .Include(c => c.UsersConversations)
                .FirstOrDefaultAsync(c => c.Id == conversationId);
        }

        public async Task<ICollection<Conversation>> GetUserConversationsAsync(Guid userId)
        {
            return await _context.UsersConversations
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Conversation)
                .ToListAsync();
        }

        public async Task<Conversation> CreateConversationAsync(Conversation conversation)
        {
            await _context.Conversations.AddAsync(conversation);
            await _context.SaveChangesAsync();
            return conversation;
        }
        public async Task DeleteConversationAsync(Guid conversationId)  
        {
            var conversation = await _context.Conversations
                .Include(c => c.UsersConversations)
                .ThenInclude(uc => uc.Messages)  // Include related messages for deletion
                .FirstOrDefaultAsync(c => c.Id == conversationId);

            if (conversation != null)
            {
                _context.Conversations.Remove(conversation);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Conversation> GetOrCreate(Guid myUserId , Guid targetUserId)
        {
            var conversation = await _context.Conversations.SingleOrDefaultAsync(it => it.UsersConversations.Where(uc => (uc.UserId == myUserId || uc.UserId == targetUserId)).Count() == 2);
            if (conversation != null)
            {
                return conversation;
            }
            conversation = new Conversation()
            {
                Name = "new conversation ",

            };
            await _context.Conversations.AddAsync(conversation);
            await _context.UsersConversations.AddRangeAsync([
                new UsersConversation { ConversationId = conversation.Id, UserId = myUserId } ,
                new UsersConversation { ConversationId = conversation.Id, UserId = targetUserId } 
                ]);
            await _context.SaveChangesAsync();
            return conversation;
        }

       
    }
}
