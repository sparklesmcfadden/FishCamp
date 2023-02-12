namespace FishCamp.Models;

public class Comment
{
    public int CommentId { get; set; }
    public ApplicationUser User { get; set; }
    public DateTime DatePosted { get; set; }
    public string CommentText { get; set; }
    public bool Flagged { get; set; }
    public bool Hidden { get; set; }
}