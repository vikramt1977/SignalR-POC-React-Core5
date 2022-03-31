using Chatty.Api.Hubs;
using Chatty.Api.Hubs.Clients;
using Chatty.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatty.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;

        public ChatController(IHubContext<ChatHub, IChatClient> chatHub)
        {
            _chatHub = chatHub;
            
        }

        [HttpPost("messages")]
        public async Task Post(ChatMessage message)
        {
            // run some logic...
            await _chatHub.Clients.All.ReceiveMessage(message);
        }

        [HttpPost("messages/grid")]
        public async Task Post2(ChatMessage message)
        {
            // run some logic...
            message.Message += " Grid";
            await _chatHub.Clients.All.Grid(message);
        }

        [HttpPost("messages/allocPreview")]
        public async Task Post3(ChatMessage message)
        {
            // run some logic...
            message.Message += " AllocationPreview";

            await _chatHub.Clients.All.AllocationPreview(message);
        }
    }
}
