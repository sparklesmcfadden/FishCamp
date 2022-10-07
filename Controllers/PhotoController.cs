using FishCamp.Data;
using FishCamp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FishCamp.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]")]
public class PhotoController : ControllerBase
{
    private readonly ILogger<LocationController> _logger;
    private PhotoService _photoService;
    private readonly IConfiguration _config;

    public PhotoController(IConfiguration config, ILogger<LocationController> logger, ApplicationDbContext context)
    {
        _config = config;
        _logger = logger;
        _photoService = new PhotoService(context);
    }

    [HttpPost]
    public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
    {
        var size = files.Sum(f => f.Length);

        foreach (var formFile in files)
        {
            if (formFile.Length > 0)
            {
                var filePath = Path.Combine(_config.GetValue<string>("PhotosPath"), 
                    Path.GetRandomFileName());

                await using var stream = System.IO.File.Create(filePath);
                await formFile.CopyToAsync(stream);
            }
        }

        return Ok(new { count = files.Count, size });
    }
}