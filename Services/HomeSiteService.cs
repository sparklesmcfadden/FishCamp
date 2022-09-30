using FishCamp.Data;
using Microsoft.EntityFrameworkCore;
using VacationLog.Models;

namespace FishCamp.Services;

public class HomeSiteService
{
    private ApplicationDbContext _context;

    public HomeSiteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<HomeSite>> GetHomeSites()
    {
        var homeSites = await _context.HomeSites.ToListAsync();
        return homeSites;
    }

    public async Task<HomeSite?> GetHomeSiteById(int id)
    {
        var homeSite = await _context.HomeSites.FirstOrDefaultAsync(h => h.HomeSiteId == id);
        return homeSite;
    }

    public async Task<List<HomeSite>> GetHomeSitesByUserId(string id)
    {
        var userSites = (await _context.Users.FirstAsync(u => u.Id == id)).HomeSites.ToList();
        return userSites;
    }

    public async Task<List<HomeSite>> GetHomeSitesByDate(DateTime startDate, DateTime endDate)
    {
        var homeSites = await _context.HomeSites.Where(h => startDate <= h.EndDate && endDate >= h.StartDate)
            .ToListAsync();
        return homeSites;
    }

    public async Task<bool> CreateHomeSite(HomeSite homeSite)
    {
        _context.HomeSites.Add(homeSite);
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

    public async Task<bool> UpdateHomeSite(HomeSite homeSite)
    {
        _context.HomeSites.Update(homeSite);
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