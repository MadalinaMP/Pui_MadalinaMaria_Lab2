using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pui_MadalinaMaria_Lab2.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string name, string surname, string message, string time)
        {
            await Clients.All.SendAsync("ReceiveMessage", name, surname, message, time);
        }
    }
}
