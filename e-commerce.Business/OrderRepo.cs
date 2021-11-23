using e_commerce.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Business
{
    public static class OrderRepo
    {
        private static Dictionary<string, Order> Orders = new Dictionary<string, Order>(); 
        public static Order CreateOrder(string productCode, int quantity)
        {
            Order order = new Order { productCode = productCode, quantity = quantity };
            Orders.Add(productCode,order);
            Console.WriteLine($"Order created; product {order.productCode}, quantity {order.quantity}");
            CampaignRepo.EfFectToCampaign(order.productCode,order.quantity);
            return order;
        }
    }
}
