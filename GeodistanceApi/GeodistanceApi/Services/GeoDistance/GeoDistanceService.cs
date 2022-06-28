using GeodistanceApi.Models;

namespace GeodistanceApi.Services
{
    public class GeoDistanceService : IGeoDistanceSerice
    {
        public double GetDistance(Coordinates from, Coordinates to)
        {
            var rlat1 = Math.PI * from.Latitude / 180;
            var rlat2 = Math.PI * to.Latitude / 180;
            var theta = from.Longitude - to.Longitude;
            var rtheta = Math.PI * theta / 180;

            var distance = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);

            distance = Math.Acos(distance);
            distance = distance * 180 / Math.PI;
            distance = distance * 60 * 1.1515 * 1.609344;

            return distance;
        }
    }
}
