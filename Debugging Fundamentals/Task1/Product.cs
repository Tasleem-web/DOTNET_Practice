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

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            Product other = (Product)obj;
            return this.Name == other.Name && this.Price == other.Price;
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
