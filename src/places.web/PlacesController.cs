using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace places.web
{
    [Route("api")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesService _placesService;
        private readonly IRequestLogger _requestLogger;

        public PlacesController(IPlacesService placesService, IRequestLogger requestLogger)
        {
            _placesService = placesService;
            _requestLogger = requestLogger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PlacesWebRequest placesWebRequest)
        {
            // TODO: Raise SingalR event
            var response = _placesService.GetResponse(placesWebRequest);
            _requestLogger.Log(placesWebRequest, response);
            return Ok(response);
        }
    }
}
