using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public string Name 
        { 
            get { return name; } 
           private set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value; } 
        }
        public double Money { 
            get { return this.money; }
            private set {

                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value; }
        
        }

        public string AddProduct(Product product)
        {
            if (this.CanAfford(product)==true)
            {
            this.products.Add(product);
               this.ReduceMoney(product);
                //Peter  Bread
               return $"{this.Name} bought {product.Name}";
            }
            else
            {
                return $"{this.Name} can't afford {product.Name}"; 
            }
        }

        private  bool CanAfford(Product product)
        {
            if (this.Money < product.Cost) { return false; }
            return  true;
        }

        private void ReduceMoney(Product product)
        {
            this.Money -=product.Cost; 
        }

        public bool HasProducts()
        {
            if (this.products.Count>0)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} - ");
            for (int i = 0; i < products.Count; i++)
            {
                if (i<products.Count-1)
                {
                    sb.Append(products[i].ToString()+ ", ");

                }
                else
                {
                    sb.Append(products[i].ToString());
                }
            }
           
            return sb.ToString().TrimEnd();
        }
    }
}
