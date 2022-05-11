using Microsoft.EntityFrameworkCore;

namespace application.Data.Services { 
    public class PassengerService
    {
     
        private AirplaneContext _context;
        public PassengerService(AirplaneContext context)
        {
            _context = context;
        }

        // добавление пассажира
        public async Task<Passenger?> AddPassenger(PassengerDTO passenger)
        {
            Passenger npassenger = new Passenger
            {
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                DateOfBirth = passenger.DateOfBirth,
                Email = passenger.Email,
                PhoneNumber = passenger.PhoneNumber,
                PassportNumber = passenger.PassportNumber
            };
            if (passenger.Tickets.Any())
            {
                npassenger.Tickets = _context.Tickets.ToList().IntersectBy(passenger.Tickets, ticket => ticket.Id).ToList();
            }
            var result = _context.Passengers.Add(npassenger);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        // Получение пассажира по его ID
        public async Task<Passenger?> GetPassenger(int id)
        {
            
            var result = _context.Passengers.Include(p => p.Tickets).FirstOrDefault(passenger => passenger.Id == id);

            return await Task.FromResult(result);
        }


        //Получение всех пассажиров
        public async Task<List<Passenger>> GetPassengers()
        {
            var result = await _context.Passengers.Include(p => p.Tickets).ToListAsync();
            return await Task.FromResult(result);
        }


        // Изменение пассажира
        public async Task<Passenger?> UpdatePassenger(int id, PassengerDTO passenger)
        {
            var npassenger = await _context.Passengers.Include(passenger => passenger.Tickets).FirstOrDefaultAsync(p => p.Id == id);
            if (npassenger != null)
            {
                npassenger.FirstName = passenger.FirstName;
                npassenger.LastName = passenger.LastName;
                npassenger.DateOfBirth = passenger.DateOfBirth;
                npassenger.Email = passenger.Email;
                npassenger.PhoneNumber = passenger.PhoneNumber;
                npassenger.PassportNumber = passenger.PassportNumber;
                if (passenger.Tickets.Any())
                {
                    npassenger.Tickets = _context.Tickets.ToList().IntersectBy(passenger.Tickets, ticket => ticket.Id).ToList();
                }
                _context.Passengers.Update(npassenger);
                _context.Entry(npassenger).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return npassenger;
            }

            return null;
        }

        // Удаление пассажира
        public async Task<bool> DeletePassenger(int id)
        {
            var passenger = await _context.Passengers.FirstOrDefaultAsync(p => p.Id == id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}