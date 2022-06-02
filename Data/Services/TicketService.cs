
using Microsoft.EntityFrameworkCore;

public class TicketService
{

    private AirplaneContext _context;
    public  TicketService(AirplaneContext context)
    {
        _context = context;
    }

    // добавление билета
    public async Task<Ticket?> AddTicket(TicketDTO ticket)
    {
        Ticket nticket = new Ticket
        {
            Seat = ticket.Seat,
            DateOfFlight = ticket.DateOfFlight,
            Price = ticket.Price,
        };
        if (ticket.Flight != null)
        {
            nticket.Flight = _context.Flights.ToList().SingleOrDefault(ticketInList => ticketInList.Id == ticket.Flight);
        };
        
        var result = _context.Tickets.Add(nticket);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    // Получение билета по его ID
    public async Task<Ticket?> GetTicket(int id)
    {

        var result = _context.Tickets
            .Include(t => t.Flight)
            .ThenInclude(f => f.CityOfDeparture)
            .Include(t => t.Flight)
            .ThenInclude(f => f.CityOfArrival)
            .FirstOrDefault(ticket => ticket.Id == id);
        

        return await Task.FromResult(result);
    }


    //Получение всех билетов
    public async Task<List<Ticket>> GetTickets()
    {
        var result = await _context.Tickets.Include(t => t.Flight).ToListAsync();
        return await Task.FromResult(result);
    }


    // Изменение билета
    public async Task<Ticket?> UpdateTicket(int id, TicketDTO ticket)
    {
        var nticket = await _context.Tickets.Include(ticket => ticket.Flight).FirstOrDefaultAsync(p => p.Id == id);
        if (nticket != null)
        {
            nticket.Seat = ticket.Seat;
            nticket.DateOfFlight = ticket.DateOfFlight;
            nticket.Price = ticket.Price;
            _context.Tickets.Update(nticket);
            _context.Entry(nticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return nticket;
        }
        if (ticket.Flight != null)
        {
            nticket.Flight = _context.Flights.ToList().SingleOrDefault(ticketInList => ticketInList.Id == ticket.Flight);
        };
        

        return null;
    }

    // Удаление билета
    public async Task<bool> DeleteTicket(int id)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

}

