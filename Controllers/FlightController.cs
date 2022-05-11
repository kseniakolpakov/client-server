using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class FlightController : ControllerBase
{
    private readonly FlightService _context;

    public FlightController(FlightService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flight>>> GetFlight()
    {
        return await _context.GetFlights();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Flight>> GetFlight(int id)
    {
        var flight = await _context.GetFlight(id);

        if (flight == null)
        {
            return NotFound();
        }

        return flight;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Flight>> PutFlight(int id, [FromBody] FlightDTO flight)
    {
        var result = await _context.UpdateFlight(id, flight);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Flight>> PostFlight([FromBody] FlightDTO flight)
    {
        var result = await _context.AddFlight(flight);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlight(int id)
    {
        var flight = await _context.DeleteFlight(id);
        if (flight)
        {
            return Ok();
        }
        return BadRequest();
    }

}
