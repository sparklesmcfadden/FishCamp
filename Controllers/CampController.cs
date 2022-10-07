using FishCamp.Data;
using FishCamp.Models;
using FishCamp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishCamp.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]")]
public class CampController : ControllerBase
{
    private readonly ILogger<CampController> _logger;
    private HomeSiteService _homeSiteService;

    public CampController(ILogger<CampController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _homeSiteService = new HomeSiteService(context);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _homeSiteService.GetHomeSites();
        return Ok(result);
    }

    [HttpGet("site/{id}")]
    public async Task<IActionResult> GetSiteById([FromRoute] int id)
    {
        var result = await _homeSiteService.GetHomeSiteById(id);
        return Ok(result);
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetSiteDetails([FromRoute] int id)
    {
        var result = await _homeSiteService.GetHomeSiteDetail(id);
        return Ok(result);
    }

    [HttpGet("date")]
    public async Task<IActionResult> GetSitesByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var result = await _homeSiteService.GetHomeSitesByDate(startDate, endDate);
        return Ok(result);
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetSitesByUser([FromRoute] string id)
    {
        var result = await _homeSiteService.GetHomeSitesByUserId(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHomeSite([FromBody] HomeSite homeSite)
    {
        var siteId = await _homeSiteService.CreateHomeSite(homeSite);
        return Ok(siteId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateHomeSite([FromBody] HomeSite homeSite)
    {
        var result = await _homeSiteService.UpdateHomeSite(homeSite);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteHomeSite([FromQuery] int id)
    {
        var result = await _homeSiteService.DeleteHomeSite(id);
        return Ok(result);
    }
}
