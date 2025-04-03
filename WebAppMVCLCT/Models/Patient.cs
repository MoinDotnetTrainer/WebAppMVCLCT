using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCLCT.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public PatientAddress? PatientAddress { get; set; }
    }
    public class PatientAddress
    {
        [Key]
        public int Id { get; set; }
        public string? City { get; set; }


        [ForeignKey("Id")]
        public int PatientID { get; set; }
    }


}
