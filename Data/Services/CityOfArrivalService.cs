//using Microsoft.EntityFrameworkCore;

//public class CityOfArrivalService
//{


//    private AirplaneContext _context;
//    public CityOfArrivalService(AirplaneContext context)
//    {
//        _context = context;
//    }

//    // создание города прибытия
//    public async Task<CityOfArrival?> AddCityOfArrival(CityOfArrivalDTO cityOfArrival)
//    {
//        CityOfArrival nCityOfArrival = new CityOfArrival
//        {
//            Name = cityOfArrival.Name,
//            CountryName = cityOfArrival.CountryName,
//        };
//        if (cityOfArrival.Flights.Any())
//        {
//            nCityOfArrival.Flights = _context.Flights.ToList().IntersectBy(cityOfArrival.Flights, flight => flight.Id).ToList();
//        }
//        var result = _context.CitiesOfArrival.Add(nCityOfArrival);
//        await _context.SaveChangesAsync();
//        return await Task.FromResult(result.Entity);

//    }

//    // Получение города по его ID
//    public async Task<CityOfArrival?> GetCityOfArrival(int id)
//    {

//        var result = _context.CitiesOfArrival.Include(ca => ca.Flights).FirstOrDefault(cityOfArrival => cityOfArrival.Id == id);

//        return await Task.FromResult(result);
//    }


//    //Получение всех городов прибытия
//    public async Task<List<CityOfArrival>> GetCitiesOfArrival()
//    {
//        var result = await _context.CitiesOfArrival.Include(ca => ca.Flights).ToListAsync();
//        return await Task.FromResult(result);
//    }


//    // Изменение города прибытия
//    public async Task<CityOfArrival?> UpdateCityOfArrival(int id, CityOfArrivalDTO cityOfArrival)
//    {
//        var nсityOfArrival = await _context.CitiesOfArrival.Include(cityOfArrival => cityOfArrival.Flights).FirstOrDefaultAsync(ca => ca.Id == id);
//        if (nсityOfArrival != null)
//        {
//            nсityOfArrival.Name = cityOfArrival.Name;
//            nсityOfArrival.CountryName = cityOfArrival.CountryName;
//            if (cityOfArrival.Flights.Any())
//            {
//                nсityOfArrival.Flights = _context.Flights.ToList().IntersectBy(cityOfArrival.Flights, flight => flight.Id).ToList();
//            }
//            _context.CitiesOfArrival.Update(nсityOfArrival);
//            _context.Entry(nсityOfArrival).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//            return nсityOfArrival;
//        }

//        return null;
//    }

//    // Удаление города прибытия
//    public async Task<bool> DeleteCityOfArrival(int id)
//    {
//        var сityOfArrival = await _context.CitiesOfArrival.FirstOrDefaultAsync(ca => ca.Id == id);
//        if (сityOfArrival != null)
//        {
//            _context.CitiesOfArrival.Remove(сityOfArrival);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        return false;
//    }
//}


