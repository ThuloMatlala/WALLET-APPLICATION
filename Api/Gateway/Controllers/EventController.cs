using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PublishEvent")]
        public EventDetail PublishEvent(EventDetail eventDetail)
        {
            return eventDetail;

        }
    }
}

