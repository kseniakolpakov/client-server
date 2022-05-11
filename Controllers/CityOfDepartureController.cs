//using Microsoft.AspNetCore.Mvc;

//[Route("api/[controller]")]
//[ApiController]
//public class CityOfDepartureController : ControllerBase
//{

//    private readonly CityOfDepartureService _context;

//    public CityOfDepartureController(CityOfDepartureService context)
//    {
//        _context = context;
//    }

//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<CityOfDeparture>>> GetCityOfDeparture()
//    {
//        return await _context.GetCitiesOfDeparture();
//    }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<CityOfDeparture>> GetCityOfDeparture(int id)
//    {
//        var cityOfDeparture = await _context.GetCityOfDeparture(id);

//        if (cityOfDeparture == null)
//        {
//            return NotFound();
//        }

//        return cityOfDeparture;
//    }

//    [HttpPut("{id}")]
//    public async Task<ActionResult<CityOfDeparture>> PutCityOfDeparture(int id, [FromBody] CityOfDepartureDTO cityOfDeparture)
//    {
//        var result = await _context.UpdateCityOfDeparture(id, cityOfDeparture);
//        if (result == null)
//        {
//            return BadRequest();
//        }
//        return Ok(result);
//    }

//    [HttpPost]
//    public async Task<ActionResult<CityOfDeparture>> PostCityOfDeparture([FromBody] CityOfDepartureDTO cityOfDeparture)
//    {
//        var result = await _context.AddCityOfDeparture(cityOfDeparture);
//        if (result == null)
//        {
//            BadRequest();
//        }

//        return Ok(result);
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteCityOfDeparture(int id)
//    {
//        var cityOfDeparture = await _context.DeleteCityOfDeparture(id);
//        if (cityOfDeparture)
//        {
//            return Ok();
//        }
//        return BadRequest();
//    }

//}


