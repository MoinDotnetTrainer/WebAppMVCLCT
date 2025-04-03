namespace WebAppMVCLCT.Models
{
    public class Person
    {
        public int PersonId { get; set; }  // Primary Key for Person
        public string Name { get; set; }

        // Navigation property to PersonDetail
        public PersonDetail PersonDetail { get; set; }
    }
    public class PersonDetail
    {
        public int PersonDetailId { get; set; } // Primary Key for PersonDetail
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        // Foreign Key to Person
        public int PersonId { get; set; }

        // Navigation property back to Person
        public Person Person { get; set; }
    }

}
