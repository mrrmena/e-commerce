using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Command
{
    public class CreateProductCommand : BaseCommand
    {
        public override CommandType commandType => CommandType.CreateProduct;
        public string productCode { get; private set; }
        public decimal price { get; private set; }
        public int stock { get; private set; }

        public CreateProductCommand(string line)
        {
            string[] lineProps = line.Split(' ');
            if (lineProps[0].ToLower() != "create_product")
            {
                throw new Exception("wrong object type");
            }
            productCode = lineProps[1];
            price = Convert.ToDecimal(lineProps[2]);
            stock = Convert.ToInt32(lineProps[3]);
        }
    }
}
