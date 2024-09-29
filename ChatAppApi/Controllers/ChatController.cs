using ChatAppApi.Hubs;
using ChatAppApi.Model;
using ChatAppApi.Service;
using ChatAppApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Security.Claims;

namespace ChatAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;
        private readonly IHubContext<ChatHub,IChatHub> _hubContext;

        public ChatController(ChatService chatService, IHubContext<ChatHub,IChatHub> hubContext)
        {
            _chatService = chatService;
            _hubContext = hubContext;
        }

        [HttpGet("conversation/{conversationId}/messages")]
        public async Task<IEnumerable<MessageDto>> GetMessages(Guid conversationId)
        {
            return await _chatService.GetConversationMessagesAsync(conversationId);
            
        }
        [HttpGet("getConversation/{myUserId}/{targetUserId}")]
        public async Task<Conversation> GetConversation(Guid myUserId,Guid targetUserId)
        {
            return await _chatService.GetConversation(myUserId,targetUserId);

        }
        [Authorize]
        [HttpPost("conversation/{conversationId}/send")]
        public async Task<IActionResult> SendMessage(Guid conversationId, [FromBody] SendMessageDto messageDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return BadRequest("Logged in user not found;");
                }
                var message = await _chatService.SendMessageAsync(new Guid(userId), conversationId, messageDto.Text);
               
                await _hubContext.Clients.Users([userId, messageDto.UserId.ToString()]).SendMessage(messageDto.UserId.ToString(),message);

                return Ok(message); // Return the created message with necessary details.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public class SendMessageDto
        {
            public Guid UserId { get; set; }
            public string Text { get; set; }
        }

     


    }
}
