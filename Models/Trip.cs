namespace FishCamp.Models;

public class Trip
{
    public int TripId { get; set; }
    public string TripName { get; set; }
    public string TripDescription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Deleted { get; set; }
    public List<TripUser> TripUsers { get; set; }
    public List<TripComment> TripComments { get; set; }
}

public class TripUser
{
    public int TripUserId { get; set; }
    public Trip Trip { get; set; }
    public ApplicationUser User { get; set; }
}

public class TripComment
{
    public int TripCommentId { get; set; }
    public Trip Trip { get; set; }
    public Comment Comment { get; set; }
}
