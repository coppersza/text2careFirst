using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Users
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", 
            ErrorMessage ="Password must have 1 uppercase, 1 lowerecase, 1 number, 1 non alpha and at least 6 character")]
        public string Password { get; set; }
    }
}
