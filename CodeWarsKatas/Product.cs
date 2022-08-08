using System.Collections.Generic;
namespace CodeWarsKatas
{
    internal class Product
    {
        readonly string name;
        public string Name { get { return name; } }

        public int SupplierId { get; set; }

        decimal? price;
        public decimal? Price
        {
            get { return price; } private set { price = value; }
        }
        public Product(string name, decimal? price = null)
        {
            this.name = name;
            this.price = price;
        }
        public static List<Product> GetSampleProducts()
        {
            return new List<Product>()
            {
                new Product( name: "West Side Story", price: 9.99m),
                new Product( name: "Assassins", price: 14.99m)
            };
        }
        public override string ToString()
        {
            return string.Format("{0}:{1}", name, price);
        }
    }
}