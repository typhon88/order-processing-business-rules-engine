namespace BusinessRulesEngine.Models
{
    public class Product
    {
        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public enum ProductCategory
        {
            Physical,
            Digital
        }
    }
}