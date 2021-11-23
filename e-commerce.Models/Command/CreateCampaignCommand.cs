using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Command
{
    public class CreateCampaignCommand : BaseCommand
    {
        public override CommandType commandType => CommandType.CreateCampaign;
        public string name { get; private set; }
        public string productCode { get; private set; }
        public int duration { get; private set; }
        public int priceManipulationLimit { get; private set; }
        public int targetSalesCount { get; private set; }

        public CreateCampaignCommand(string line)
        {
            string[] lineProps = line.Split(' ');
            if (lineProps[0].ToLower() != "create_campaign")
            {
                throw new Exception("wrong object type");
            }
            name = lineProps[1];
            productCode = lineProps[2];
            duration = Convert.ToInt32(lineProps[3]);
            priceManipulationLimit = Convert.ToInt32(lineProps[4]);
            targetSalesCount = Convert.ToInt32(lineProps[5]);
        }
    }
}
