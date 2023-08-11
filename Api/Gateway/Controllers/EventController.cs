using Gateway.AsyncDataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IMessageBusClient _messageBusClient;

        public EventController(IMessageBusClient messageBusClient)
        {
            _messageBusClient = messageBusClient;
        }

        [HttpPost(Name = "PublishEvent")]
        public string PublishEvent(EventDetail eventDetail)
        {
            _messageBusClient.PublishMessage(eventDetail.Event, eventDetail.Message);
            return "Message Published";

        }
    }
}

