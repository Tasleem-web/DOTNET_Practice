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
        public override bool Equals(object productObject)
        {
            if (productObject == null || productObject.GetType() != this.GetType())
                return false;
            Product incomingProductObject = (Product)productObject;
            return this.Name == incomingProductObject.Name && this.Price == incomingProductObject.Price;
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
