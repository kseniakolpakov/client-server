using application.Data.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class PassengerController : ControllerBase
{
    private readonly PassengerService _context;

    public PassengerController(PassengerService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Passenger>>> GetPassenger()
    {
        return await _context.GetPassengers();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Passenger>> GetPassenger(int id)
    {
        var passenger = await _context.GetPassenger(id);

        if (passenger == null)
        {
            return NotFound();
        }

        return passenger;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Passenger>> PutPassenger(int id, [FromBody] PassengerDTO passenger)
    {
        var result = await _context.UpdatePassenger(id, passenger);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Passenger>> PostPassenger([FromBody] PassengerDTO passenger)
    {
        var result = await _context.AddPassenger(passenger);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePassenger(int id)
    {
        var passenger = await _context.DeletePassenger(id);
        if (passenger)
        {
            return Ok();
        }
        return BadRequest();
    }
}
