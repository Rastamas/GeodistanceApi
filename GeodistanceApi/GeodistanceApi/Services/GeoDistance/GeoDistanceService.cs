using GeodistanceApi.Extensions;
using GeodistanceApi.Models;

namespace GeodistanceApi.Services
{
    public class GeoDistanceService : IGeoDistanceSerice
    {
        public double GetDistance(Coordinates from, Coordinates to)
        {
            var rlat1 = from.Latitude.ToRadian();
            var rlat2 = to.Latitude.ToRadian();
            var rtheta = (from.Longitude - to.Longitude).ToRadian();

            var distance = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);

            distance = Math.Acos(distance);
            distance = distance.FromRadian() * 60 * 1.1515 * 1.609344;

            return distance;
        }
    }
}
