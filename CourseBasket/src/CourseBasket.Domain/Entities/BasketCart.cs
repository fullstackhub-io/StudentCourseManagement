using System.Collections.Generic;

namespace CourseBasket.Domain.Entities
{
    public class BasketCart
    {
        public string UserEmail { get; set; }
        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();
        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price;
                }
                return totalprice;
            }
        }
    }
}
