using e_commerce.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Models.Model
{
    public class Campaign : Storable
    {
        public string name { get; set; }
        public string product_code { get; set; }
        public int duration { get; set; }
        public double price_limit { get; set; }
        public double target_sales { get; set; }
        public CampaignStatus CampaignStatus { get; set; }

        public Campaign(string [] objectArray)
        {
            key = objectArray[1];
            name = objectArray[1];
            product_code = objectArray[2];
            duration = Convert.ToInt32(objectArray[3]);
            price_limit = Convert.ToDouble(objectArray[4]);
            target_sales = Convert.ToDouble(objectArray[5]);
            CampaignStatus = new CampaignStatus();
            CampaignStatus.status = "Active";
            CampaignStatus.avg_item_price = 0;
            CampaignStatus.total_sales = 0;
            CampaignStatus.last_sales = 0;
            created_comand = $"Campaign created; name {name}, product {product_code}, duration {duration}, limit {price_limit}, target sales count {target_sales}";
        }
    }
}
