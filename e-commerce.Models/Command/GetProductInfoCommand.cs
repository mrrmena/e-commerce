using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Command
{
    public class GetProductInfoCommand : BaseCommand
    {
        public override CommandType commandType => CommandType.GetProductInfo;
        public string productCode { get; private set; }

        public GetProductInfoCommand(string line)
        {
            string[] lineProps = line.Split(' ');
            if (lineProps[0].ToLower() != "get_product_info")
            {
                throw new Exception("wrong object type");
            }
            productCode = lineProps[1];
        }
    }
}
