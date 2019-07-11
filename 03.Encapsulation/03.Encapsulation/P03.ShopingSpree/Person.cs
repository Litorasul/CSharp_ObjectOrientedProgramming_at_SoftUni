using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.ShopingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return this.products.AsReadOnly(); }           
        }

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            this.Money -= product.Cost;
            AddProduct(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }

        private void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
