using FishCamp.Data;
using FishCamp.Models;
using Microsoft.EntityFrameworkCore;

namespace FishCamp.Services;

public class CommentService
{
    private ApplicationDbContext _context;

    public CommentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Comment> GetCommentById(int id)
    {
        var comment = await _context.Comments.FirstAsync(c => c.CommentId == id);
        return comment;
    }

    public async Task<bool> CreateComment(Comment comment)
    {
        _context.Comments.Add(comment);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> DeleteComment(int id)
    {
        var comment = await _context.Comments.FirstAsync(c => c.CommentId == id);
        _context.Comments.Remove(comment);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}