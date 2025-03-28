using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVCLCT.Models
{
    [Table("GeninueData")]
    public class ValidateModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name Required")]  // data annotation 
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Dob Required")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Salary Required")]
        public double Salary { get; set; }


        [Required(ErrorMessage = "Age Required")]
        [Range(18, 50, ErrorMessage = "Not in Range")]
        public int Age { get; set; }


        [StringLength(50, MinimumLength = 20)]
        public string Address { get; set; }
    }
}
