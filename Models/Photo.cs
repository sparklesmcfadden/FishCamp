using FishCamp.Models;

namespace VacationLog.Models;

public class Photo
{
    public int PhotoId { get; set; }
    public ApplicationUser User { get; set; }
    public string PhotoUrl { get; set; }
    public string Notes { get; set; }
    public List<Comment> Comments { get; set; }
}