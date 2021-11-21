using e_commerce.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Model
{
    public class Campaign : Storable
    {
        public string name { get; set; }
        public string product_code { get; set; }
        public int duration { get; set; }
        public double price_limit { get; set; }
        public double target_sales { get; set; }
        public CampaignStatus status { get; set; }
        public double total_sales { get; set; }
        public double avg_item_price { get; set; }
        public double last_sales { get; set; }

        public Campaign(string [] objectArray)
        {
            key = objectArray[1];
            name = objectArray[1];
            product_code = objectArray[2];
            duration = Convert.ToInt32(objectArray[3]);
            price_limit = Convert.ToDouble(objectArray[4]);
            target_sales = Convert.ToDouble(objectArray[5]);
            status = CampaignStatus.Active;
            avg_item_price = 0;
            total_sales = 0;
            last_sales = 0;
        }
    }
}
