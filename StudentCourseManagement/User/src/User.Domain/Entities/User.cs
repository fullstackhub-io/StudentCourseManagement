namespace User.Domain.Entities
{
    using Dapper.Contrib.Extensions;
    using System;

    [Table("[User]")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
