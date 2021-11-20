using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Models.Model
{
    public class CampaignStatus
    {
        public string status { get; set; }
        public double total_sales { get; set; }
        public double avg_item_price { get; set; }
        public double last_sales { get; set; }
    }
}
