using System;

namespace SportNutr.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Навигационные свойства
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}