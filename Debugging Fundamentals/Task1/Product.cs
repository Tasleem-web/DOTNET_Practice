using System;

namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public override bool Equals(object product)
        {
            if (product == null || product.GetType() != this.GetType())
                return false;
            Product incomingProduct = (Product)product;
            return this.Name == incomingProduct.Name && this.Price == incomingProduct.Price;
        }
        // Override GetHashCode to ensure consistency with Equals
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);

        }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
