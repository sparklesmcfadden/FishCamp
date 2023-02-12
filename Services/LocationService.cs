using FishCamp.Models;
using Microsoft.EntityFrameworkCore;

namespace FishCamp.Services;

public class LocationService
{
    private readonly ApplicationDbContext _context;

    public LocationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Location>> GetLocations()
    {
        var locations = await _context.Locations.ToListAsync();
        return locations;
    }

    public async Task<List<Location>> GetLocationsByDate(DateTime startDate, DateTime endDate)
    {
        var locations = await _context.Locations
            .Include(l => l.LocationVisits)
            .Where(l => l.LocationVisits.Any(v => v.VisitDate >= startDate && v.VisitDate <= endDate))
            .ToListAsync();
        return locations;
    }

    public async Task<List<Location>> GetLocationsByTripId(int tripId)
    {
        var locations = await _context.LocationTrips
            .Include(t => t.Location)
            .Where(t => t.Trip.TripId == tripId)
            .Select(t => t.Location)
            .ToListAsync();
        return locations;
    }

    public async Task<Location> GetLocationById(int locationId)
    {
        var location = await _context.Locations
            .Include(l => l.LocationTrips)
            .ThenInclude(t => t.Trip)
            .Include(l => l.LocationComments)
            .ThenInclude(c => c.Comment)
            .Include(l => l.LocationPhotos)
            .ThenInclude(p => p.Photo)
            .Include(l => l.LocationVisits)
            .FirstOrDefaultAsync(l => l.LocationId == locationId);
        if (location == null)
        {
            return new Location
            {
                LocationId = -1
            };
        }
        return location;
    }

    //TODO need to filter/sort/group these by tripId too, maybe do that on front end?
    public async Task<List<LocationVisit>> GetLocationVisits(int locationId)
    {
        var visits = await _context.LocationVisits
            .Include(l => l.Location.LocationTrips)
            .ThenInclude(t => t.Trip)
            .Include(v => v.LocationVisitComments)
            .ThenInclude(c => c.Comment)
            .Include(v => v.LocationVisitPhotos)
            .ThenInclude(p => p.Photo)
            .Include(v => v.LocationVisitUsers)
            .ThenInclude(u => u.User)
            .Where(v => v.Location.LocationId == locationId)
            .ToListAsync();
        return visits;
    }

    public async Task<int> CreateLocation(Location location)
    {
        _context.Locations.Add(location);
        try
        {
            await _context.SaveChangesAsync();
            return location.LocationId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }
    }

    public async Task<int> CreateLocationVisit(int locationId, LocationVisit visit)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(l => l.LocationId == locationId);
        if (location != null)
        {
            _context.LocationVisits.Add(visit);
            try
            {
                await _context.SaveChangesAsync();
                return visit.LocationVisitId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }
        else
        {
            return -1;
        }
    }
    
    public async Task<bool> UpdateLocation(Location location)
    {
        _context.Locations.Update(location);
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

    public async Task<bool> UpdateLocationVisit(LocationVisit visit)
    {
        _context.LocationVisits.Update(visit);
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
    
    public async Task<bool> DeleteLocation(int id)
    {
        var locationToDelete = await _context.Locations.SingleAsync(h => h.LocationId == id);
        locationToDelete.Deleted = true;
        _context.Locations.Update(locationToDelete);
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

    public async Task<bool> DeleteLocationVisit(int id)
    {
        var visitToDelete = await _context.LocationVisits.SingleAsync(v => v.LocationVisitId == id);
        visitToDelete.Deleted = true;
        _context.LocationVisits.Update(visitToDelete);
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