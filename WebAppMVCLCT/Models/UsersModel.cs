using System.ComponentModel.DataAnnotations;

namespace WebAppMVCLCT.Models
{
    public class UsersModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
    }
}
