namespace CourseBasket.Domain.Entities
{
    public class BasketCartItem
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CrouseShortName { get; set; }
        public int CreditHour { get; set; }
        public decimal Price { get; set; }
    }
}
