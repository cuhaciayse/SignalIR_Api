using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalIR_Api.Hubs;
using System.Threading.Tasks;

namespace SignalIR_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<MyHub> _hubContext;

        public NotificationController(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpGet("{roomCount}")]
        public async Task<IActionResult> SetRoomCount(int roomCount)
        {
            MyHub.RoomCount= roomCount; 
            await _hubContext.Clients.All.SendAsync("Notify", $"Bu oda en fazla {roomCount} kişi alabilir");
            return Ok();
        }
    }
}
