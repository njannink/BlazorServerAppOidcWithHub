using BlazorWebAppOidc.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BlazorWebAppOidc.Hubs;

[Authorize]
public class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
        var user = UserInfo.FromClaimsPrincipal(Context.User);
        await Clients.All.SendAsync("ReceiveMessage", user.Name, message);
    }
}