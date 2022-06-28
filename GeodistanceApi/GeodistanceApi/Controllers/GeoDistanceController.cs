using Microsoft.AspNetCore.Mvc;

namespace GeodistanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeoDistanceController : ControllerBase
    {
        private readonly ILogger<GeoDistanceController> _logger;

        public GeoDistanceController(ILogger<GeoDistanceController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDistance")]
        public double Get(Coordinates coordinates)
        {
            return default;
        }
    }
}