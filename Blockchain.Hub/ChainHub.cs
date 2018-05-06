using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using SignalRHub = Microsoft.AspNetCore.SignalR.Hub;

namespace Blockchain.Hub
{
    public class ChainHub : SignalRHub
    {
        public void BlockReceived(Block block)
        {
            NodeHub.Blockchain.AddBlock(block);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Blockchain", JsonConvert.SerializeObject(NodeHub.Blockchain));
            await base.OnConnectedAsync();
        }

        // public async Task SendBlock(Block block)
        // {
        //     // HubConnection connection = new HubConnection();
        //     await Clients.All.SendAsync("Block", block);
        // }

        // public override async Task OnDisconnectedAsync(System.Exception exception)
        // {
        //     await base.OnDisconnectedAsync(exception);
        // }
    }
}