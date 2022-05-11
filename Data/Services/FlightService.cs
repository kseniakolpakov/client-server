using Microsoft.EntityFrameworkCore;

public class FlightService
{

    private AirplaneContext _context;
    public FlightService(AirplaneContext context)
    {
        _context = context;
    }

    // добавление рейса
    public async Task<Flight?> AddFlight(FlightDTO flight)
    {
        Flight nflight = new Flight
        {
            Number = flight.Number,
            Duration = flight.Duration,
            TimeOfDeparture = flight.TimeOfDeparture,
            TimeOfArrival = flight.TimeOfArrival
        };
        if (flight.Tickets.Any())
        {
            nflight.Tickets = _context.Tickets.ToList().IntersectBy(flight.Tickets, ticket => ticket.Id).ToList();

        }
        if (flight.Airplane != null)
        {
            nflight.Airplane = _context.Airplanes.ToList().SingleOrDefault(flightInList => flightInList.Id == flight.Airplane);
        }
        //if (flight.CityOfArrival != null)
        //{
        //    nflight.CityOfArrival = _context.CitiesOfArrival.ToList().SingleOrDefault(flightInList => flightInList.Id == flight.CityOfArrival);
        //};
        //if (flight.CityOfDeparture != null)
        //{
        //    nflight.CityOfDeparture = _context.CitiesOfDeparture.ToList().SingleOrDefault(flightInList => flightInList.Id == flight.CityOfDeparture);
        //};
        var result = _context.Flights.Add(nflight);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    // Получение рейса по его ID
    public async Task<Flight?> GetFlight(int id)
    {

        var result = _context.Flights.Include(f => f.Tickets).Include(f => f.Airplane).FirstOrDefault(flight => flight.Id == id);

        return await Task.FromResult(result);
    }


    //Получение всех полетов
    public async Task<List<Flight>> GetFlights()
    {
        var result = await _context.Flights.Include(f => f.Tickets).Include(f => f.Airplane).ToListAsync();
        return await Task.FromResult(result);
    }


    // Изменение полета
    public async Task<Flight?> UpdateFlight(int id, FlightDTO updatedFlight)
    {
        var flight = await _context.Flights.Include(f => f.Tickets).Include(f => f.Airplane).FirstOrDefaultAsync(f => f.Id == id);
        if (flight != null)
        {
            flight.Number = updatedFlight.Number;
            flight.Duration = updatedFlight.Duration;
            flight.TimeOfDeparture = updatedFlight.TimeOfDeparture;
            flight.TimeOfArrival = updatedFlight.TimeOfArrival;
            if (updatedFlight.Tickets.Any())
            {
                flight.Tickets = _context.Tickets.ToList().IntersectBy(updatedFlight.Tickets, ticket => ticket.Id).ToList();

            }
            if (updatedFlight.Airplane != null)
            {
                flight.Airplane = _context.Airplanes.ToList().SingleOrDefault(flightInList => flightInList.Id == updatedFlight.Airplane);
            }
            //if (updatedFlight.CityOfArrival != null)
            //{
            //    flight.CityOfArrival = _context.CitiesOfArrival.ToList().SingleOrDefault(flightInList => flightInList.Id == updatedFlight.CityOfArrival);
            //};
            //if (updatedFlight.CityOfDeparture != null)
            //{
            //    flight.CityOfDeparture = _context.CitiesOfDeparture.ToList().SingleOrDefault(flightInList => flightInList.Id == updatedFlight.CityOfDeparture);
            //};
            _context.Flights.Update(flight);
            _context.Entry(flight).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return flight;
        }

        return null;
    }

    // Удаление полета
    public async Task<bool> DeleteFlight(int id)
    {
        var flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);
        if (flight != null)
        {
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

}


