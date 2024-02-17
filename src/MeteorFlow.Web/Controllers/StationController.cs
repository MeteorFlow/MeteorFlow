using MeteorFlow.Core.Services.Stations;
using MeteorFlow.Domain;
using MeteorFlow.Domain.Tenants;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.Web.Controllers;

[ApiController]
[Route("api/stations")]
public class StationController(IStationService stationService, ILogger<StationController> logger) : ControllerBase
{
    private readonly ILogger<StationController> _logger = logger;

    [HttpGet]
    public async ValueTask<IActionResult> GetStations()
    {
        try
        {
            var stations = await stationService.GetStationsAsync();
            return Ok(stations);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpGet]
    [Route("{stationId}")]
    public async ValueTask<IActionResult> GetStationById(int stationId)
    {
        try
        {
            var station = await stationService.GetStationByIdAsync(stationId);
            return Ok(station);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
        
    [HttpPost]
    public async ValueTask<IActionResult> AddStation([FromBody] Stations station)
    {
        try
        {
            var result = await stationService.AddStationAsync(station);
            return CreatedAtAction(nameof(AddStation), result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpPut]
    public async ValueTask<IActionResult> UpdateStation([FromBody] Stations station)
    {
        try
        {
            await stationService.UpdateStationAsync(station);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}