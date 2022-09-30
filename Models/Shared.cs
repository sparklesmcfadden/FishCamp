using FishCamp.Models;

namespace VacationLog.Models;

public class Coordinates
{
    public decimal Lat { get; set; }
    public decimal Long { get; set; }
}

public class FishType
{
    public int FishTypeId { get; set; }
    public string FishTypeDescription { get; set; }
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