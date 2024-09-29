using ChatAppApi.Model;
using ChatAppApi.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace ChatAppApi.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        private static ConcurrentDictionary<string, string> UserConnections = new ConcurrentDictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            // Add the connection to the user
            var userId = Context.UserIdentifier;
            UserConnections[Context.ConnectionId] = userId;
            await base.OnConnectedAsync();
        }

      
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Remove the connection when the user disconnects
            UserConnections.TryRemove(Context.ConnectionId, out _);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
