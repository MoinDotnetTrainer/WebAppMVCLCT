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
        public double Salary { get; set; }
    }
}
