namespace FishCamp.Models;

public class LocationVisit
{
    public int LocationVisitId { get; set; }
    public DateTime VisitDate { get; set; }
    public bool Deleted { get; set; }
    public Location Location { get; set; }
    public List<LocationVisitComment> LocationVisitComments { get; set; }
    public List<LocationVisitPhoto> LocationVisitPhotos { get; set; }
    public List<LocationVisitUser> LocationVisitUsers { get; set; }
}

public class LocationVisitComment
{
    public int LocationVisitCommentId { get; set; }
    public LocationVisit LocationVisit { get; set; }
    public Comment Comment { get; set; }
}

public class LocationVisitPhoto
{
    public int LocationVisitPhotoId { get; set; }
    public LocationVisit LocationVisit { get; set; }
    public Photo Photo { get; set; }
}

public class LocationVisitUser
{
    public int LocationVisitUserId { get; set; }
    public LocationVisit LocationVisit { get; set; }
    public ApplicationUser User { get; set; }
}