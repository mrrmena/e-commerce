namespace e_commerce.Data.Model
{
    public class Campaign 
    {
        public string name { get; set; }
        public string productCode { get; set; }
        public int duration { get; set; }
        public decimal priceManipulationLimit { get; set; }
        public double targetSalesCount { get; set; }
        public CampaignStatus status { get; set; }
        public int totalSales { get; set; }
        public decimal avgItemPrice { get; set; }
        public int lastSales { get; set; }

        
    }
}
