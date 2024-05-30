using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightMicroservice.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private readonly FlightService _flightService;

        public FlightsController(FlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights([FromQuery] string destination = null)
        {
            var flights = await _flightService.GetFlightDetailsAsync();
            if (!string.IsNullOrEmpty(destination))
            {
                flights.FlightList = flights.FlightList
                    .Where(f => f.DestinationCity.Equals(destination, StringComparison.OrdinalIgnoreCase))
                    .ToArray();
            }
            return Ok(flights.FlightList);
        }
    }
}

