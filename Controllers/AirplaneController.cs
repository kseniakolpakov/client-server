
using Microsoft.AspNetCore.Mvc;
using application.Data.Services;

[Route("api/[controller]")]
[ApiController]

public class AirplaneController : ControllerBase
{
    private readonly AirplaneService _context;

    public AirplaneController(AirplaneService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Airplane>>> GetAirplanes()
    {
        return await _context.GetAirplanes();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Airplane>> GetAirplane(int id)
    {
        var airplane = await _context.GetAirplane(id);

        if (airplane == null)
        {
            return NotFound();
        }

        return airplane;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Airplane>> PutAirplane(int id, [FromBody] AirplaneDTO airplane)
    {
        var result = await _context.UpdateAirplane(id, airplane);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Airplane>> PostAirplane([FromBody] AirplaneDTO airplane)
    {
        var result = await _context.AddAirplane(airplane);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirplane(int id)
    {
        var airplane = await _context.DeleteAirplane(id);
        if (airplane)
        {
            return Ok();
        }
        return BadRequest();
    }

}
