using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Data.Model
{
    public enum CampaignStatus
    {
        [Description("Active")]
        Active,
        [Description("Ended")]
        Ended
    }
}
