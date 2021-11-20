using e_commerce.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Models.Model
{
    public class Orders : Storable
    {
        public string product_code { get; set; }
        public double quantity { get; set; }
        public Orders(string[] objectArray)
        {
            key = Guid.NewGuid().ToString();
            product_code = objectArray[1];
            quantity = Convert.ToDouble(objectArray[2]);
            created_comand = $"Order created; product {product_code}, quantity {quantity}";
        }
    }
}
