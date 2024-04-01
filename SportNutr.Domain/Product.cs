namespace SportNutr.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }

        // Навигационное свойство
        public virtual Brand Brand { get; set; }
    }
}