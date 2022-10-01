namespace FishCamp.Models;

public class Coordinates
{
    public decimal Lat { get; set; }
    public decimal Long { get; set; }
}

public class Fish
{
    public int FishId { get; set; }
    public string FishDescription { get; set; }
    public int FishCount { get; set; }
}

public class Comment
{
    public int CommentId { get; set; }
    public ApplicationUser User { get; set; }
    public DateTime DatePosted { get; set; }
    public string CommentText { get; set; }
    public bool Flagged { get; set; }
    public bool Hidden { get; set; }
}