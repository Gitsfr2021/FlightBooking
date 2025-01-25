using Utravs.Application.Flights.DTOs;
using Utravs.Application.Interfaces;
using Utravs.Core.Entities.CMS;

namespace Utravs.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Int64> CreateFlightAsync(CreateFlightDto flightDto)
        {
            var flight = new Flight
            {
                FlightNumber = flightDto.FlightNumber,
                Origin = flightDto.Origin,
                Destination = flightDto.Destination,
                DepartureTime = flightDto.DepartureTime,
                ArrivalTime = flightDto.ArrivalTime,
                AvailableSeats = flightDto.AvailableSeats,
                Price = flightDto.Price
            };

            var createdFlight = await _flightRepository.CreateAsync(flight);
            return createdFlight.Id;
        }

        public async Task<IEnumerable<FlightDto>> GetFlightsAsync(string? origin, string? destination, DateTime? departureDate)
        {
            var flights = await _flightRepository.GetFlightsAsync(origin, destination, departureDate);
            return flights.Select(f => new FlightDto
            {
                Id = f.Id,
                FlightNumber = f.FlightNumber,
                Origin = f.Origin,
                Destination = f.Destination,
                DepartureTime = f.DepartureTime,
                ArrivalTime = f.ArrivalTime,
                AvailableSeats = f.AvailableSeats,
                Price = f.Price
            });
        }

        public async Task<bool> UpdateAvailableSeatsAsync(UpdateSeatsDto updateSeatsDto)
        {
            var flight = await _flightRepository.GetByIdAsync(updateSeatsDto.FlightId);
            if (flight == null) return false;

            flight.AvailableSeats += updateSeatsDto.SeatsToAdd;
            await _flightRepository.UpdateAsync(flight);
            return true;
        }
    }

}
