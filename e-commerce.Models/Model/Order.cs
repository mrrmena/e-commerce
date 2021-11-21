using e_commerce.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Model
{
    public class Order : Storable
    {
        public string product_code { get; set; }
        public double quantity { get; set; }
        public Order(string[] objectArray)
        {
            key = Guid.NewGuid().ToString();
            product_code = objectArray[1];
            quantity = Convert.ToDouble(objectArray[2]);
        }
    }
}
