using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CityOfArrivalController : ControllerBase
{

    private readonly CityOfArrivalService _context;

    public CityOfArrivalController(CityOfArrivalService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityOfArrival>>> GetCitiesOfArrival()
    {
        return await _context.GetCitiesOfArrival();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CityOfArrival>> GetCityOfArrival(int id)
    {
        var cityOfArrival = await _context.GetCityOfArrival(id);

        if (cityOfArrival == null)
        {
            return NotFound();
        }

        return cityOfArrival;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CityOfArrival>> PutCityOfArrival(int id, [FromBody] CityOfArrivalDTO cityOfArrival)
    {
        var result = await _context.UpdateCityOfArrival(id, cityOfArrival);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CityOfArrival>> PostCityOfArrival([FromBody] CityOfArrivalDTO cityOfArrival)
    {
        var result = await _context.AddCityOfArrival(cityOfArrival);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCityOfArrival(int id)
    {
        var cityOfArrival  = await _context.DeleteCityOfArrival(id);
        if (cityOfArrival)
        {
            return Ok();
        }
        return BadRequest();
    }


}


