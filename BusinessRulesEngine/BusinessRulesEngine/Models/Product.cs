namespace BusinessRulesEngine.Models
{
    public class Product
    {
        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public ProductType Type { get; set; }

        public enum ProductCategory
        {
            Physical,
            Digital
        }

        public enum ProductType
        {
            Generic,
            Book,
            Membership,
            MembershipUpgrade,
            Video
        }

    }
}