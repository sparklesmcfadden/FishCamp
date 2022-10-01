namespace FishCamp.Models;

public class UserCatches
{
    public int UserCatchesId { get; set; }
    public ApplicationUser User { get; set; }
    public Location Location { get; set; }
    public Fish Fish { get; set; }
    public int Count { get; set; }
    public string Notes { get; set; }
}