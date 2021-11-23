using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Command
{
    public class CreateOrderCommand : BaseCommand
    {
        public override CommandType commandType => CommandType.CreateOrder;
        public string productCode { get; private set; }
        public int quantity { get; private set; }

        public CreateOrderCommand(string line)
        {
            string[] lineProps = line.Split(' ');
            if (lineProps[0].ToLower() != "create_order")
            {
                throw new Exception("wrong object type");
            }
            productCode = lineProps[1];
            quantity = Convert.ToInt32(lineProps[2]);
        }
    }
}
