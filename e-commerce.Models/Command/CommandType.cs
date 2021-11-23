using System.ComponentModel;

namespace e_commerce.Data.Command
{
    public enum CommandType
    {
        CreateProduct,
        CreateOrder,
        CreateCampaign,
        GetProductInfo,
        GetCampaignInfo,
        IncreaceTime,
    }
}
