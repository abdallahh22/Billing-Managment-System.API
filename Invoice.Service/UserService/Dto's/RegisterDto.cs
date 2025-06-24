using System.ComponentModel.DataAnnotations;

namespace Invoice.Service.UserService.Dto_s
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
