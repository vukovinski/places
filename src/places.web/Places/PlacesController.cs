using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace places.web
{
    [Route("api")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesService _placesService;
        private readonly IRequestLogger _requestLogger;
        private readonly IHubContext<SubscribersHub> _subscribersHub;

        public PlacesController(
            IPlacesService placesService,
            IRequestLogger requestLogger,
            IHubContext<SubscribersHub> subscribersHub)
        {
            _placesService = placesService;
            _requestLogger = requestLogger;
            _subscribersHub = subscribersHub;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] PlacesWebRequest placesWebRequest)
        {
            try
            {
                _subscribersHub.Clients.All.SendAsync("NewSearch", placesWebRequest.Latitude, placesWebRequest.Longitude);
                var response = _placesService.GetResponse(placesWebRequest);
                _requestLogger.Log(placesWebRequest, response);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
