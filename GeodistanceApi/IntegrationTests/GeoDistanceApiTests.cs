using FluentAssertions;
using GeodistanceApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class GeoDistanceApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public GeoDistanceApiTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetDistancePositive()
        {
            const double expectedValue = 82.95;
            var requestBody = JsonSerializer.Serialize(new GeoDistanceRequest
            {
                From = new Coordinates(46.8964, 19.6897),
                To = new Coordinates(47.4979, 19.0402)
            });

            var client = _factory.CreateClient();

            var response = await client.PostAsync("/GeoDistance", new StringContent(requestBody, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var responseValue = double.Parse(await response.Content.ReadAsStringAsync());

            responseValue.Should().BeApproximately(expectedValue, precision: 2);
        }
    }
}