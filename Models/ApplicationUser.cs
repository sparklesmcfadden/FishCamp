﻿using Microsoft.AspNetCore.Identity;

namespace FishCamp.Models;

public class ApplicationUser : IdentityUser
{
    public List<Comment> Comments { get; set; }
    public List<Photo> Photos { get; set; }
}
