using ChatAppApi.Data;
using ChatAppApi.Interfaces;
using ChatAppApi.Model;
using ChatAppApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ChatAppApi.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MessageDto>> GetMessagesByConversationIdAsync(Guid conversationId)
        {
            return await _context.Messages
                .Where(m => m.UsersConversation.ConversationId == conversationId)
                .Select(m=> new MessageDto
                {
                    Id= m.Id,
                    Text= m.Text,
                    ConversationId =m.UsersConversation.ConversationId,
                    UserId =m.UsersConversation.UserId,
                    MessageDate = m.MessageDate
                })
                .OrderBy(m => m.MessageDate)
                .ToListAsync();
        }

        public async Task<Message> SendMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return message;
        }
        public async Task DeleteMessageAsync(int messageId)  
        {
            var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == messageId);
            if (message != null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }
    }
}
