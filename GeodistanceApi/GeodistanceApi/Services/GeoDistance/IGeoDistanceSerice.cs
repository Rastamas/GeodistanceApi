using GeodistanceApi.Models;

namespace GeodistanceApi.Services
{
    public interface IGeoDistanceSerice
    {
        public double GetDistance(Coordinates from, Coordinates to);
    }
}
