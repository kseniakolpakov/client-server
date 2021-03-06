using application.Data.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class TicketController : ControllerBase
{
    private readonly TicketService _context;

    public TicketController(TicketService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
    {
        return await _context.GetTickets();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> GetTicket(int id)
    {
        var ticket = await _context.GetTicket(id);

        if (ticket == null)
        {
            return NotFound();
        }

        return ticket;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Ticket>> PutTicket(int id, [FromBody] TicketDTO ticket)
    {
        var result = await _context.UpdateTicket(id, ticket);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Ticket>> PostTicket([FromBody] TicketDTO ticket)
    {
        var result = await _context.AddTicket(ticket);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        var ticket = await _context.DeleteTicket(id);
        if (ticket)
        {
            return Ok();
        }
        return BadRequest();
    }

}
