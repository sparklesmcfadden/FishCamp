using FishCamp.Data;
using FishCamp.Models;
using FishCamp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishCamp.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILogger<LocationController> _logger;
    private LocationService _locationService;

    public LocationController(ILogger<LocationController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _locationService = new LocationService(context);
    }

    [HttpGet("{siteId:int}")]
    public async Task<IActionResult> Get([FromRoute] int siteId)
    {
        var result = await _locationService.GetLocationsBySiteId(siteId);
        return Ok(result);
    }

    [HttpGet("detail/{id:int}")]
    public async Task<IActionResult> GetLocationDetail([FromRoute] int id)
    {
        var result = await _locationService.GetLocationDetail(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] Location location)
    {
        var locationId = await _locationService.CreateLocation(location);
        return Ok(locationId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation([FromBody] Location location)
    {
        var result = await _locationService.UpdateLocation(location);
        return Ok(location);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLocation([FromQuery] int id)
    {
        var result = await _locationService.DeleteLocation(id);
        return Ok(result);
    }
}