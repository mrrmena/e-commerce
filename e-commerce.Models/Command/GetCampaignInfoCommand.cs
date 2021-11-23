using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Command
{
    public class GetCampaignInfoCommand : BaseCommand
    {
        public override CommandType commandType => CommandType.GetCampaignInfo;
        public string name { get; private set; }

        public GetCampaignInfoCommand(string line)
        {
            string[] lineProps = line.Split(' ');
            if (lineProps[0].ToLower() != "get_campaign_info")
            {
                throw new Exception("wrong object type");
            }
            name = lineProps[1];
        }
    }
}
