using System.Collections.Generic;

namespace CourseBasket.Domain.Entities
{
    public class BasketCheckout
    {
        public string UserEmail { get; set; }
        public decimal TotalPrice { get; set; }
        public List<string> BougthCourseName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
