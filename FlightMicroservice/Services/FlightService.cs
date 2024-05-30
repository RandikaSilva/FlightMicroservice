using System.Xml.Serialization;
using FlightMicroservice.Modals;

namespace FlightMicroservice.Services
{
    public class FlightService
	{
        private readonly HttpClient _httpClient;
        public FlightService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetFlightsAsync()
        {
            var response = await _httpClient.GetAsync("https://flighttestservice.azurewebsites.net/flights");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Flights> GetFlightDetailsAsync()
        {
            var xmlData = await GetFlightsAsync();
            using var stringReader = new StringReader(xmlData);
            var serializer = new XmlSerializer(typeof(Flights));
            return (Flights)serializer.Deserialize(stringReader);
        }
    }
}
