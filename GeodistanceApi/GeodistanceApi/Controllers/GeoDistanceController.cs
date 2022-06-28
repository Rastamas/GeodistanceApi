using GeodistanceApi.Models;
using GeodistanceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeodistanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeoDistanceController : ControllerBase
    {
        private readonly ILogger<GeoDistanceController> _logger;
        private readonly IGeoDistanceSerice _geoDistanceService;

        public GeoDistanceController(ILogger<GeoDistanceController> logger, IGeoDistanceSerice geoDistanceService)
        {
            _logger = logger;
            _geoDistanceService = geoDistanceService;
        }

        [HttpPost(Name = "GetDistance")]
        public double Get(GeoDistanceRequest input)
        {
            return _geoDistanceService.GetDistance(input.From, input.To);
        }
    }
}