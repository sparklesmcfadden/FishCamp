using FishCamp.Data;
using FishCamp.Models;
using Microsoft.EntityFrameworkCore;

namespace FishCamp.Services;

public class LocationService
{
    private ApplicationDbContext _context;

    public LocationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Location>> GetLocationsBySiteId(int homeSiteId)
    {
        var locations = await _context.Locations.Where(x => x.HomeSite.HomeSiteId == homeSiteId).ToListAsync();
        return locations;
    }

    public async Task<Location?> GetLocationDetail(int id)
    {
        var location = await _context.Locations
            .Include(l => l.Comments)
            .Include(l => l.Photos)
            .Include(l => l.Fish)
            .FirstOrDefaultAsync(l => l.LocationId == id);
        return location;
    }

    public async Task<bool> CreateLocation(Location location)
    {
        _context.Locations.Add(location);
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
    
    public async Task<bool> DeleteLocation(int id)
    {
        var locationToDelete = await _context.Locations.FirstAsync(h => h.LocationId == id);
        _context.Locations.Remove(locationToDelete);
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