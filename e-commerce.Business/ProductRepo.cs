using e_commerce.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Business
{
    public static class ProductRepo
    {
        private static Dictionary<string, Product> Products = new Dictionary<string, Product>();
        public static Product CreateProduct(string productCode, decimal price, int stock)
        {
            Product product = new Product { productsCode = productCode, price = price, stock = stock,firstPrice = price };
            Products.Add(productCode, product);
            Console.WriteLine($"Product created; code {product.productsCode}, price {product.price}, stock {product.stock}");
            return product;
        }

        public static Product GetProductInfo(string productCode, bool writeLine = true)
        {
            Product product = Products[productCode];
            if(writeLine)
                Console.WriteLine($"Product {product.productsCode} info; price {product.price}, stock {product.stock}");
            return product;
        }

        public static void SetProduct(Product product)
        {
            Products[product.productsCode] = product;
        }
    }
}
