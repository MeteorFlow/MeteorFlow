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
    public async ValueTask<IActionResult> AddStation([FromBody] Tenants tenant)
    {
        try
        {
            var result = await stationService.AddStationAsync(tenant);
            return CreatedAtAction(nameof(AddStation), result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpPut]
    public async ValueTask<IActionResult> UpdateStation([FromBody] Tenants tenant)
    {
        try
        {
            await stationService.UpdateStationAsync(tenant);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}