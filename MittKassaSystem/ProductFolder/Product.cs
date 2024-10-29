using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ProductFolder
{
    public class Product
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(byte id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public Product() { }
        public string ToCsv()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price:C}";
        }
    }
}
