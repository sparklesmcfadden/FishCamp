using FishCamp.Models;
using FishCamp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FishCamp.Controllers;

[Route("api/{controller}")]
public class TripController : Controller
{
    private TripService _tripService;

    public TripController(TripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTrips()
    {
        var result = await _tripService.GetTrips();
        return Ok(result);
    }
    
    [HttpGet("{tripId}")]
    public async Task<IActionResult> GetTripById([FromRoute] int tripId)
    {
        var result = await _tripService.GetTripById(tripId);
        return Ok(result);
    }

    [HttpGet("date")]
    public async Task<IActionResult> GetTripsByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var result = await _tripService.GetTripByDate(startDate, endDate);
        return Ok(result);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetTripsByUser([FromQuery] string userId)
    {
        var result = await _tripService.GetTripsByUser(userId);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTrip([FromBody] Trip trip)
    {
        var result = await _tripService.CreateTrip(trip);
        return Ok(result);
    }

    [HttpPost("{tripId}/comment")]
    public async Task<IActionResult> PostTripComment([FromBody] Comment comment, [FromRoute] int tripId)
    {
        var result = await _tripService.AddTripComment(comment, tripId);
        return Ok(result);
    }

    [HttpPost("{tripId}/user/{userId}")]
    public async Task<IActionResult> AddUserToTrip([FromRoute] int tripId, [FromRoute] string userId)
    {
        var result = await _tripService.AddUserToTrip(userId, tripId);
        return Ok(result);
    }

    [HttpPost("{tripId}")]
    public async Task<IActionResult> UpdateTrip([FromBody] Trip trip)
    {
        var result = await _tripService.UpdateTrip(trip);
        return Ok(result);
    }

    [HttpPost("{tripId}/delete")]
    public async Task<IActionResult> DeleteTrip([FromRoute] int tripId)
    {
        var result = await _tripService.DeleteTrip(tripId);
        return Ok(result);
    }

}