using System;

namespace API.Dtos.Users
{
    public class UserDto
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }

        public string Token { get; set; }
    }
}