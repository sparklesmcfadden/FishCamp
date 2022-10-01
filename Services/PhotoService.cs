using FishCamp.Data;

namespace FishCamp.Services;

public class PhotoService
{
    // Will need a way to upload photos here
    private ApplicationDbContext _context;

    public PhotoService(ApplicationDbContext context)
    {
        _context = context;
    }
}