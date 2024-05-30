using System.Net;
using FlightMicroservice.Services;
using FlightMicroservice.Tests.Helper;
using NUnit.Framework;


[TestFixture]
public class FlightServiceTests
{
    private HttpClient _httpClient;
    private FlightService _flightService;

    [SetUp]
    public void SetUp()
    {
        
    }

    [Test]
    public async Task GetFlightsAsync_ShouldReturnStringContent()
    {
        // Arrange
        var responseContent = "<Flights><Flight></Flight></Flights>";
        var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(responseContent)
        };
        var handler = new MockHttpMessageHandler((request, cancellationToken) =>
        {
            return Task.FromResult(httpResponseMessage);
        });
        _httpClient = new HttpClient(handler);
        _flightService = new FlightService(_httpClient);

        // Act
        var result = await _flightService.GetFlightsAsync();

        // Assert
        Assert.That(responseContent == result);
    }

    [Test]
    public async Task GetFlightDetailsAsync_ShouldReturnDeserializedFlights()
    {
        // Arrange
        var responseContent = "<Flights><Flight></Flight></Flights>";
        var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(responseContent)
        };
        var handler = new MockHttpMessageHandler((request, cancellationToken) =>
        {
            return Task.FromResult(httpResponseMessage);
        });
        _httpClient = new HttpClient(handler);
        _flightService = new FlightService(_httpClient);

        // Act
        var result = await _flightService.GetFlightDetailsAsync();

        // Assert
        Assert.That(result!=null);
    }
}

