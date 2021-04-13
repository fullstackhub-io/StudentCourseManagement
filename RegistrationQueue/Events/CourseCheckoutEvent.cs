namespace EventBusRabbitMQ.Events
{
    public class CourseCheckoutEvent
    {
        public string CourseName { get; set; }

        public string CrouseShortName { get; set; }
        public decimal CreditHour { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
