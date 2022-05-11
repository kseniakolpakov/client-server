using Microsoft.EntityFrameworkCore;

public class AirplaneService
{

    private AirplaneContext _context;
    public AirplaneService(AirplaneContext context)
    {
        _context = context;
    }

    // создание самолета
    public async Task<Airplane?> AddAirplane(AirplaneDTO airplane)
    {
        Airplane nairplane = new Airplane
        {
            NumberOfBussinessClassSeats = airplane.NumberOfBussinessClassSeats,
            NumberOfEconomyClassSeats = airplane.NumberOfEconomyClassSeats,
        };
        if (airplane.Flights.Any())
        {
            nairplane.Flights = _context.Flights.ToList().IntersectBy(airplane.Flights, flight => flight.Id).ToList();
        }
        var result = _context.Airplanes.Add(nairplane);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    // Получение самолета по его ID
    public async Task<Airplane?> GetAirplane(int id)
    {

        var result = _context.Airplanes.Include(ap => ap.Flights).FirstOrDefault(airplane => airplane.Id == id);

        return await Task.FromResult(result);
    }


    //Получение всех самолетов
    public async Task<List<Airplane>> GetAirplanes()
    {
        var result = await _context.Airplanes.Include(ap => ap.Flights).ToListAsync();
        return await Task.FromResult(result);
    }


    // Изменение самолета
    public async Task<Airplane?> UpdateAirplane(int id, AirplaneDTO airplane)
    {
        var nairplane = await _context.Airplanes.Include(airplane => airplane.Flights).FirstOrDefaultAsync(ap => ap.Id == id);
        if (nairplane != null)
        {
            nairplane.NumberOfBussinessClassSeats = airplane.NumberOfBussinessClassSeats;
            nairplane.NumberOfEconomyClassSeats = airplane.NumberOfEconomyClassSeats;
            if (airplane.Flights.Any())
            {
                nairplane.Flights = _context.Flights.ToList().IntersectBy(airplane.Flights, flight => flight.Id).ToList();
            }
            _context.Airplanes.Update(nairplane);
            _context.Entry(nairplane).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return nairplane;
        }

        return null;
    }

    // Удаление самолета
    public async Task<bool> DeleteAirplane(int id)
    {
        var airplane = await _context.Airplanes.FirstOrDefaultAsync(ap => ap.Id == id);
        if (airplane != null)
        {
            _context.Airplanes.Remove(airplane);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

}
