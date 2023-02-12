namespace FishCamp.Models;

public class Location
{
    public int LocationId { get; set; }
    public string LocationName { get; set; }
    public string LocationDescription { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public bool Deleted { get; set; }
    public ApplicationUser CreatedBy { get; set; }
    public List<LocationTrip> LocationTrips { get; set; }
    public List<LocationComment> LocationComments { get; set; }
    public List<LocationPhoto> LocationPhotos { get; set; }
    public List<LocationVisit> LocationVisits { get; set; }
}

public class LocationTrip
{
    public int LocationTripId { get; set; }
    public Location Location { get; set; }
    public Trip Trip { get; set; }
}

public class LocationComment
{
    public int LocationCommentId { get; set; }
    public Location Location { get; set; }
    public Comment Comment { get; set; }
}

public class LocationPhoto
{
    public int LocationPhotoId { get; set; }
    public Location Location { get; set; }
    public Photo Photo { get; set; }
}
