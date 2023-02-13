using FishCamp.Models;
using Microsoft.EntityFrameworkCore;

namespace FishCamp.Services;

public class CommentService
{
    private readonly ApplicationDbContext _context;

    public CommentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateTripComment(Comment comment, int tripId)
    {
        var trip = await _context.Trips.FirstOrDefaultAsync(t => t.TripId == tripId);
        if (trip != null)
        {
            var tripComment = new TripComment
            {
                Trip = trip,
                Comment = comment
            };

            _context.Comments.Add(comment);
            _context.TripComments.Add(tripComment);

            await _context.SaveChangesAsync();
            return comment.CommentId;
        }

        return -1;
    }

    public async Task<int> CreateLocationComment(Comment comment, int locationId)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(l => l.LocationId == locationId);
        if (location != null)
        {
            var locationComment = new LocationComment
            {
                Location = location,
                Comment = comment
            };

            _context.Comments.Add(comment);
            _context.LocationComments.Add(locationComment);

            await _context.SaveChangesAsync();
            return comment.CommentId;
        }

        return -1;
    }

    public async Task<int> CreateLocationVisitComment(Comment comment, int visitId)
    {
        var visit = await _context.LocationVisits.FirstOrDefaultAsync(v => v.LocationVisitId == visitId);
        if (visit != null)
        {
            var locationVisitComment = new LocationVisitComment
            {
                LocationVisit = visit,
                Comment = comment
            };

            _context.Comments.Add(comment);
            _context.LocationVisitComments.Add(locationVisitComment);

            await _context.SaveChangesAsync();
            return comment.CommentId;
        }

        return -1;
    }

    public async Task<int> CreatePhotoComment(Comment comment, int photoId)
    {
        var photo = await _context.Photos.FirstOrDefaultAsync(p => p.PhotoId == photoId);
        if (photo != null)
        {
            var photoComment = new PhotoComment
            {
                Photo = photo,
                Comment = comment
            };

            _context.Comments.Add(comment);
            _context.PhotoComments.Add(photoComment);

            await _context.SaveChangesAsync();
            return comment.CommentId;
        }

        return -1;
    }

    public async Task<bool> DeleteTripComment(int commentId)
    {
        var tripComment = await _context.TripComments
            .Include(t => t.Comment)
            .FirstOrDefaultAsync(c => c.Comment.CommentId == commentId);
        if (tripComment != null)
        {
            _context.Comments.Remove(tripComment.Comment);
            _context.TripComments.Remove(tripComment);
            await _context.SaveChangesAsync();
            
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteLocationComment(int commentId)
    {
        var locationComment = await _context.LocationComments
            .Include(l => l.Comment)
            .FirstOrDefaultAsync(c => c.Comment.CommentId == commentId);
        if (locationComment != null)
        {
            _context.Comments.Remove(locationComment.Comment);
            _context.LocationComments.Remove(locationComment);
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> DeleteLocationVisitComment(int commentId)
    {
        var visitComment = await _context.LocationVisitComments
            .Include(v => v.Comment)
            .FirstOrDefaultAsync(c => c.Comment.CommentId == commentId);
        if (visitComment != null)
        {
            _context.Comments.Remove(visitComment.Comment);
            _context.LocationVisitComments.Remove(visitComment);
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> DeletePhotoComment(int commentId)
    {
        var photoComment = await _context.PhotoComments
            .Include(p => p.Comment)
            .FirstOrDefaultAsync(c => c.Comment.CommentId == commentId);
        if (photoComment != null)
        {
            _context.Comments.Remove(photoComment.Comment);
            _context.PhotoComments.Remove(photoComment);
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }
}