using Microsoft.EntityFrameworkCore;

public class CityOfArrivalService
{

    private AirplaneContext _context;
    public CityOfArrivalService(AirplaneContext context)
    {
        _context = context;
    }

    public async Task<CityOfArrival?> AddCityOfArrival(CityOfArrivalDTO cityOfArrival)
    {
        CityOfArrival ncity = new CityOfArrival
        {
            Name = cityOfArrival.Name,
            CountryName = cityOfArrival.CountryName
        };
        if (cityOfArrival.Flights.Any())
        {
            ncity.Flights = _context.Flights.ToList().IntersectBy(cityOfArrival.Flights, flight => flight.Id).ToList();
        }
        var result = _context.CitiesOfArrival.Add(ncity);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<List<CityOfArrival>> GetCitiesOfArrival()
    {
        var result = await _context.CitiesOfArrival.Include(ca => ca.Flights).ToListAsync();
        return await Task.FromResult(result);
    }


    public async Task<CityOfArrival?> GetCityOfArrival(int id)
    {

        var result = _context.CitiesOfArrival.Include(ca => ca.Flights).FirstOrDefault(cityOfArrival => cityOfArrival.Id == id);

        return await Task.FromResult(result);
    } 

    public async Task<CityOfArrival?> UpdateCityOfArrival(int id, CityOfArrivalDTO cityOfArrival)
    {
        var ncity = await _context.CitiesOfArrival.Include(cityOfArrival => cityOfArrival.Flights).FirstOrDefaultAsync(ca => ca.Id == id);
        if (ncity != null)
        {
            ncity.Name = cityOfArrival.Name;
            ncity.CountryName = cityOfArrival.CountryName;
            if (cityOfArrival.Flights.Any())
            {
                ncity.Flights = _context.Flights.ToList().IntersectBy(cityOfArrival.Flights, flight => flight.Id).ToList();
            }
            _context.CitiesOfArrival.Update(ncity);
            _context.Entry(ncity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ncity;
        }

        return null;
    }

    public async Task<bool> DeleteCityOfArrival(int id)
    {
        var cityOfArrival = await _context.CitiesOfArrival.FirstOrDefaultAsync(ca => ca.Id == id);
        if (cityOfArrival != null)
        {
            _context.CitiesOfArrival.Remove(cityOfArrival);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }



}


