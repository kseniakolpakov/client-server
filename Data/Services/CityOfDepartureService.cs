
//using Microsoft.EntityFrameworkCore;

//public class CityOfDepartureService
//{

//    private AirplaneContext _context;
//    public CityOfDepartureService(AirplaneContext context)
//    {
//        _context = context;
//    }

//    // создание города отправления
//    public async Task<CityOfDeparture?> AddCityOfDeparture(CityOfDepartureDTO cityOfDeparture)
//    {
//        CityOfDeparture nCityOfDeparture = new CityOfDeparture
//        {
//            Name = cityOfDeparture.Name,
//            CountryName = cityOfDeparture.CountryName,
//        };
//        if (cityOfDeparture.Flights.Any())
//        {
//            nCityOfDeparture.Flights = _context.Flights.ToList().IntersectBy(cityOfDeparture.Flights, flight => flight.Id).ToList();
//        }
//        var result = _context.CitiesOfDeparture.Add(nCityOfDeparture);
//        await _context.SaveChangesAsync();
//        return await Task.FromResult(result.Entity);
//    }

//    // Получение города отправления по его ID
//    public async Task<CityOfDeparture?> GetCityOfDeparture(int id)
//    {

//        var result = _context.CitiesOfDeparture.Include(cd => cd.Flights).FirstOrDefault(cityOfDeparture => cityOfDeparture.Id == id);

//        return await Task.FromResult(result);
//    }


//    //Получение всех городов отправления
//    public async Task<List<CityOfDeparture>> GetCitiesOfDeparture()
//    {
//        var result = await _context.CitiesOfDeparture.Include(cd => cd.Flights).ToListAsync();
//        return await Task.FromResult(result);
//    }


//    // Изменение города отправления
//    public async Task<CityOfDeparture?> UpdateCityOfDeparture(int id, CityOfDepartureDTO cityOfDeparture)
//    {
//        var nсityOfDeparture = await _context.CitiesOfDeparture.Include(cityOfDeparture => cityOfDeparture.Flights).FirstOrDefaultAsync(cd => cd.Id == id);
//        if (nсityOfDeparture != null)
//        {
//            nсityOfDeparture.Name = cityOfDeparture.Name;
//            nсityOfDeparture.CountryName = cityOfDeparture.CountryName;
//            if (cityOfDeparture.Flights.Any())
//            {
//                nсityOfDeparture.Flights = _context.Flights.ToList().IntersectBy(cityOfDeparture.Flights, flight => flight.Id).ToList();
//            }
//            _context.CitiesOfDeparture.Update(nсityOfDeparture);
//            _context.Entry(nсityOfDeparture).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//            return nсityOfDeparture;
//        }

//        return null;
//    }

//    // Удаление города отправления
//    public async Task<bool> DeleteCityOfDeparture(int id)
//    {
//        var сityOfDeparture = await _context.CitiesOfDeparture.FirstOrDefaultAsync(cd => cd.Id == id);
//        if (сityOfDeparture != null)
//        {
//            _context.CitiesOfDeparture.Remove(сityOfDeparture);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        return false;
//    }
//}


