using GeodistanceApi.Models;
using GeodistanceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeodistanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeoDistanceController : ControllerBase
    {
        private readonly IGeoDistanceSerice _geoDistanceService;

        public GeoDistanceController(IGeoDistanceSerice geoDistanceService)
        {
            _geoDistanceService = geoDistanceService;
        }

        [HttpPost(Name = "GetDistance")]
        public double GetDistance(GeoDistanceRequest input)
        {
            return _geoDistanceService.GetDistance(input.From, input.To);
        }
    }
}