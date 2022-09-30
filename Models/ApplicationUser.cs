using Microsoft.AspNetCore.Identity;
using VacationLog.Models;

namespace FishCamp.Models;

public class ApplicationUser : IdentityUser
{
    public List<Comment> Comments { get; set; }
    public List<Photo> Photos { get; set; }
    public List<HomeSite> HomeSites { get; set; }
}
