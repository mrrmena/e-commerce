using e_commerce.Structure;
using System;

namespace e_commerce.Data.Model
{
    public class Product : Storable
    {
        public string products_code { get; set; }
        public double price { get; set; }
        public double first_price { get; set; }
        public double stock { get; set; }
        public Product (string [] objectArray)
        {
            key = objectArray[1];
            products_code = objectArray[1];
            price = Convert.ToDouble(objectArray[2]);
            first_price = price;
            stock = Convert.ToDouble(objectArray[3]);
        }
    }
}
