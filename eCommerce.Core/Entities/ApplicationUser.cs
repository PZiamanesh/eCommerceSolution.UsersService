﻿using UsersMicroService.Core.Dtos;

namespace UsersMicroService.Core.Entities;

public class ApplicationUser
{
    public Guid UserID { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    public GenderOptions? Gender { get; set; }
}
