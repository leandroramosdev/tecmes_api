using System;
namespace TecmesAPI.Models
{
	public class UserDto
	{
        public required string Username { get; set; } = String.Empty;
        public required string Password { get; set; } = String.Empty;
    }
}

