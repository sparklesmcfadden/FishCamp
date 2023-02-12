using FishCamp.Models;
using Microsoft.EntityFrameworkCore;

namespace FishCamp.Services;

// TODO add gettripsbwithusers
public class TripService
{
    private readonly ApplicationDbContext _context;

    public TripService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Trip>> GetTrips()
    {
        var trips = await _context.Trips
            .Where(t => !t.Deleted)
            .ToListAsync();
        return trips;
    }

    public async Task<Trip> GetTripById(int id)
    {
        var trip = await _context.Trips
            .Include(t => t.TripComments)
            .ThenInclude(c => c.Comment)
            .Include(t => t.TripUsers)
            .ThenInclude(u => u.User)
            .FirstOrDefaultAsync(h => h.TripId == id);
        if (trip == null)
        {
            return new Trip()
            {
                TripId = -1
            };
        }
        return trip;
    }

    public async Task<List<Trip>> GetTripByDate(DateTime startDate, DateTime endDate)
    {
        var trips = await _context.Trips
            .Where(t => t.StartDate >= startDate && t.StartDate <= endDate)
            .ToListAsync();
        return trips;
    }

    public async Task<List<Trip>> GetTripsByUser(string userId)
    {
        var trips = await _context.TripUsers
            .Include(u => u.Trip)
            .Where(u => u.User.Id == userId)
            .Select(u => u.Trip)
            .ToListAsync();
        return trips;
    }

    public async Task<int> CreateTrip(Trip trip)
    {
        _context.Trips.Add(trip);
        try
        {
            await _context.SaveChangesAsync();
            return trip.TripId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }
    }

    public async Task<int> AddTripComment(Comment comment, int tripId)
    {
        _context.Comments.Add(comment);
        var trip = await _context.Trips.SingleAsync(h => h.TripId == tripId);
        var tripComment = new TripComment
        {
            Trip = trip,
            Comment = comment
        };
        _context.TripComments.Add(tripComment);
        await _context.SaveChangesAsync();

        return comment.CommentId;
    }

    public async Task<int> AddUserToTrip(string userId, int tripId)
    {
        var user = await _context.Users.SingleAsync(u => u.Id == userId);
        var trip = await _context.Trips.SingleAsync(h => h.TripId == tripId);
        var tripUser = new TripUser
        {
            Trip = trip,
            User = user
        };
        _context.TripUsers.Add(tripUser);
        await _context.SaveChangesAsync();

        return tripUser.TripUserId;
    }

    public async Task<bool> UpdateTrip(Trip trip)
    {
        _context.Trips.Update(trip);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> DeleteTrip(int id)
    {
        var siteToDelete = _context.Trips.Single(h => h.TripId == id);
        siteToDelete.Deleted = true;
        _context.Trips.Update(siteToDelete);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}