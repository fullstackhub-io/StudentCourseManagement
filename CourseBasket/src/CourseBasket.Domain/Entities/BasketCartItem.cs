namespace CourseBasket.Domain.Entities
{
    public class BasketCartItem
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseShortName { get; set; }
        public decimal CreditHour { get; set; }
        public decimal Price { get; set; }
    }
}
