using MeteorFlow.Core.Services.Metadata;
using MeteorFlow.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeteorFlow.Web.Controllers;

[ApiController]
[Authorize]
[Route("api/metadata")]
public class MetadataController(IMetadataService metadataService, ILogger<MetadataController> logger) : ControllerBase
{
    private readonly ILogger<MetadataController> _logger = logger;

    [HttpGet]
    [Route("elements")]
    public async ValueTask<IActionResult> GetElements()
    {
        try
        {
            var elements = await metadataService.GetElementsAsync();
            return Ok(elements);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet]
    [Route("units")]
    public async ValueTask<IActionResult> GetUnits()
    {
        try
        {
            var units = await metadataService.GetUnitsAsync();
            return Ok(units);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }



    [HttpGet]
    [Route("value")]
    public async ValueTask<IActionResult> GetValue([FromQuery] int elementId, [FromQuery] int stationId)
    {
        try
        {
            var values = await metadataService.GetValuesAsync(elementId, stationId);
            return Ok(values);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
            
        }
    }

    [HttpPost]
    [Route("value")]
    public async ValueTask<IActionResult> AddValue([FromBody] ICollection<ObservationValues> values)
    {
        try
        {
            await metadataService.AddValuesAsync(values);
            return CreatedAtAction(nameof(AddValue), values);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpPost]
    [Route("element")]
    public async ValueTask<IActionResult> AddElement([FromBody] ICollection<ObservationElements> elements)
    {
        try
        {
            await metadataService.AddElementsAsync(elements);
            return CreatedAtAction(nameof(AddElement), elements);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpPut]
    [Route("value")]
    public async ValueTask<IActionResult> UpdateValue([FromBody] ICollection<ObservationValues> values)
    {
        try
        {
            await metadataService.UpdateValuesAsync(values);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}