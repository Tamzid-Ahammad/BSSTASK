using ChatAppApi.Interfaces;
using ChatAppApi.Model;
using ChatAppApi.ViewModels;

namespace ChatAppApi.Service
{
    public class ChatService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationRepository _conversationRepository;
        private readonly IUsersConversationRepository _usersConversationRepository;

        public ChatService(IMessageRepository messageRepository,
        IConversationRepository conversationRepository,
        IUsersConversationRepository usersConversationRepository)
        {
            _messageRepository = messageRepository;
            _conversationRepository = conversationRepository;
            _usersConversationRepository = usersConversationRepository;

        }
        public async Task<IEnumerable<MessageDto>> GetConversationMessagesAsync(Guid conversationId)
        {
            return await _messageRepository.GetMessagesByConversationIdAsync(conversationId);
        }

        public async Task<MessageDto> SendMessageAsync(Guid userId, Guid conversationId, string text)
        {
            var usersConversation = await _usersConversationRepository.GetUsersConversationAsync(conversationId, userId);
            if (usersConversation == null)
            {
                throw new Exception("User not part of this conversation.");
            }

            var message = new Message
            {
                Text = text,
                UsersConversationId = usersConversation.Id,
                MessageDate = DateTime.UtcNow
            };

             await _messageRepository.SendMessageAsync(message);

            return new MessageDto
            {
                MessageDate = message.MessageDate,
                ConversationId = conversationId,
                Text = message.Text,
                UserId = userId,
                Id = message.Id
            };
        }
        public async Task DeleteMessageAsync(int messageId)
        {
            await _messageRepository.DeleteMessageAsync(messageId);
        }

        public async Task DeleteConversationAsync(Guid conversationId)
        {
            await _conversationRepository.DeleteConversationAsync(conversationId);
        }
        public async Task<Conversation> GetConversation(Guid myUserId, Guid targetUserId)
        {
            return await _conversationRepository.GetOrCreate(myUserId, targetUserId);

        }
       


    }
}
