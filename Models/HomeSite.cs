using FishCamp.Models;

namespace VacationLog.Models;

public class HomeSite
{
    public int HomeSiteId { get; set; }
    public string Name { get; set; }
    public string Coordinates { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Location> Locations { get; set; }
    public List<ApplicationUser> Users { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Photo> Photos { get; set; }
}