using GeodistanceApi.Extensions;
using GeodistanceApi.Models;

namespace GeodistanceApi.Services
{
    public class GeoDistanceService : IGeoDistanceSerice
    {
        private const int EarthRadiusInKm = 6371;

        public double GetDistance(Coordinates from, Coordinates to)
        {
            var fromLatitideInR = from.Latitude.ToRadian();
            var toLatitudeInR = to.Latitude.ToRadian();
            var longitudeAngle = (from.Longitude - to.Longitude).ToRadian();

            var insideAngle = Math.Acos(Math.Sin(fromLatitideInR) * Math.Sin(toLatitudeInR) + 
                Math.Cos(fromLatitideInR) * Math.Cos(toLatitudeInR) * Math.Cos(longitudeAngle));

            return insideAngle * EarthRadiusInKm;
        }
    }
}
