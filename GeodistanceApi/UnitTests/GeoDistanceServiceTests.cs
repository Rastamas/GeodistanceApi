using FluentAssertions;
using GeodistanceApi.Models;
using GeodistanceApi.Services;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class GeoDistanceServiceTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void GetDistancePositive(Coordinates from, Coordinates to, double expectedDistance)
        {
            var service = new GeoDistanceService();

            var distance = service.GetDistance(from, to);

            distance.Should().BeApproximately(expectedDistance, precision: 2);
        }

        [Fact]
        public void GetDistanceIsTheSameBackwards()
        {
            var coordinatesFrom = new Coordinates(25, -25);
            var coordinatesTo = new Coordinates(-50, 50);

            var service = new GeoDistanceService();

            var distanceOneWay = service.GetDistance(coordinatesFrom, coordinatesTo);
            var distanceBackwards = service.GetDistance(coordinatesTo, coordinatesFrom);

            distanceOneWay.Should().Be(distanceBackwards);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { new Coordinates(46.8964, 19.6897), new Coordinates(47.4979, 19.0402), 82.95 },
                new object[] { new Coordinates(53.3498, -6.2603), new Coordinates(47.4979, 19.0402), 1894.68 }
            };
    }
}