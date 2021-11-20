using e_commerce.Structure;
using System;

namespace e_commerce.Models.Model
{
    public class Products : Storable
    {
        public string products_code { get; set; }
        public double price { get; set; }
        public double first_price { get; set; }
        public double stock { get; set; }
        public Products (string [] objectArray)
        {
            key = objectArray[1];
            products_code = objectArray[1];
            price = Convert.ToDouble(objectArray[2]);
            first_price = price;
            stock = Convert.ToDouble(objectArray[3]);
            created_comand = $"Product created; code {products_code}, price {price}, stock {stock}";
        }
    }
}
