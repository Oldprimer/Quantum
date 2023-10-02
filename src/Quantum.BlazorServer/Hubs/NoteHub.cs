using Microsoft.AspNetCore.SignalR;
using Quantum.Data.Model;

namespace Quantum.BlazorServer.Hubs
{
    public class NoteHub: Hub
    {
        public async Task SendNote()
        {
            await Clients.All.SendAsync("RecieveNote");
        }
    }
}
