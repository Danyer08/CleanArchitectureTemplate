﻿namespace API.Auth;

public class AuthRequestDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}