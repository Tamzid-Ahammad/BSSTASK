using ChatAppApi.Data;
using ChatAppApi.Interfaces;
using ChatAppApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ChatAppApi.Repositories
{
    public class UsersConversationRepository : IUsersConversationRepository
    {
        public readonly ApplicationDbContext _context;
        public UsersConversationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UsersConversation?> GetUsersConversationAsync(Guid conversationId, Guid userId)
        {
            return await _context.UsersConversations
                .SingleOrDefaultAsync(uc => uc.ConversationId == conversationId && uc.UserId == userId);
        }

        public async Task AddUserToConversationAsync(UsersConversation usersConversation)
        {
            await _context.UsersConversations.AddAsync(usersConversation);
            await _context.SaveChangesAsync();
        }
    }
}
