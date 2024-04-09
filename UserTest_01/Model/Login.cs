using System.ComponentModel.DataAnnotations;

namespace UserTest_01.Model
{
    public class Login
    {
        public int Id { get; set; } 
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
