using FishCamp.Models;
using FishCamp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FishCamp.Controllers;

[Route("api/{controller}")]
public class LocationController : Controller
{
    private readonly LocationService _locationService;
    private readonly CommentService _commentService;

    public LocationController(LocationService locationService, CommentService commentService)
    {
        _locationService = locationService;
        _commentService = commentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLocations()
    {
        var result = await _locationService.GetLocations();
        return Ok(result);
    }

    [HttpGet("date")]
    public async Task<IActionResult> GetLocationsByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var result = await _locationService.GetLocationsByDate(startDate, endDate);
        return Ok(result);
    }

    [HttpGet("trip/{tripId}")]
    public async Task<IActionResult> GetLocationsByTripId([FromRoute] int tripId)
    {
        var result = await _locationService.GetLocationsByTripId(tripId);
        return Ok(result);
    }

    [HttpGet("{locationId}")]
    public async Task<IActionResult> GetLocationById([FromRoute] int locationId)
    {
        var result = await _locationService.GetLocationById(locationId);
        return Ok(result);
    }

    [HttpGet("{locationId}/visits")]
    public async Task<IActionResult> GetLocationVisits([FromRoute] int locationId)
    {
        var result = await _locationService.GetLocationVisits(locationId);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateLocation([FromBody] Location location)
    {
        var result = await _locationService.CreateLocation(location);
        return Ok(result);
    }

    [HttpPost("{locationId}/update")]
    public async Task<IActionResult> UpdateLocation([FromBody] Location location)
    {
        var result = await _locationService.UpdateLocation(location);
        return Ok(result);
    }

    [HttpPost("{locationId}/visits/create")]
    public async Task<IActionResult> CreateLocationVisit([FromRoute] int locationId, [FromBody] LocationVisit visit)
    {
        var result = await _locationService.CreateLocationVisit(locationId, visit);
        return Ok(result);
    }

    [HttpPost("{locationId}/visits/{visitId}/update")]
    public async Task<IActionResult> UpdateLocationVisit([FromBody] LocationVisit visit)
    {
        var result = await _locationService.UpdateLocationVisit(visit);
        return Ok(result);
    }

    [HttpPost("{locationId}/delete")]
    public async Task<IActionResult> DeleteLocation([FromRoute] int locationId)
    {
        var result = await _locationService.DeleteLocation(locationId);
        return Ok(result);
    }

    [HttpPost("{locationId}/visits/{visitId}/delete")]
    public async Task<IActionResult> DeleteLocationVisit([FromRoute] int visitId)
    {
        var result = await _locationService.DeleteLocationVisit(visitId);
        return Ok(result);
    }

    [HttpPost("{locationId}/comment")]
    public async Task<IActionResult> PostLocationComment(Comment comment, [FromRoute] int locationId)
    {
        var result = await _commentService.CreateLocationComment(comment, locationId);
        return Ok(result);
    }

    [HttpPost("{locationId}/visits/{visitId}/comment")]
    public async Task<IActionResult> PostVisitComment(Comment comment, [FromRoute] int visitId)
    {
        var result = await _commentService.CreateLocationVisitComment(comment, visitId);
        return Ok(result);
    }

    [HttpPost("{locationId}/comment/{commentId}")]
    public async Task<IActionResult> DeleteLocationComment([FromRoute] int commentId)
    {
        var result = await _commentService.DeleteLocationComment(commentId);
        return Ok(result);
    }

    [HttpPost("{locationId}/visits/{visitId}/comment/{commentId}")]
    public async Task<IActionResult> DeleteVisitComment([FromRoute] int commentId)
    {
        var result = await _commentService.DeleteLocationVisitComment(commentId);
        return Ok(result);
    }
}