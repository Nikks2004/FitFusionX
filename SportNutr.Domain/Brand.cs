using System.Collections.Generic;

namespace SportNutr.Domain
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Навигационное свойство
        public virtual ICollection<Product> Products { get; set; }
    }
}