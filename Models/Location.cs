namespace FishCamp.Models;

public class Location
{
    public int LocationId { get; set; }
    public HomeSite HomeSite { get; set; }
    public string Coordinates { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }
    public List<Fish> Fish { get; set; }
    public List<ApplicationUser> User { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Photo> Photos { get; set; }
}