namespace FishCamp.Models;

public class Photo
{
    public int PhotoId { get; set; }
    public ApplicationUser User { get; set; }
    public string PhotoUrl { get; set; }
    public List<PhotoComment> PhotoComments { get; set; }
}

public class PhotoComment
{
    public int PhotoCommentId { get; set; }
    public Photo Photo { get; set; }
    public Comment Comment { get; set; }
}