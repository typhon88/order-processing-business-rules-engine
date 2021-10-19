using System.Collections.Generic;

namespace BusinessRulesEngine.Models
{
    public class PackingSlip
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}