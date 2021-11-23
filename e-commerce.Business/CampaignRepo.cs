using e_commerce.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace e_commerce.Business
{
    public static class CampaignRepo
    {
        private static Dictionary<string, Campaign> Campaigns = new Dictionary<string, Campaign>();


        public static Campaign CreateCampaign(string name, string productCode, int duration, int priceManipulationLimit, int targetSalesCount)
        {
            Campaign campaign = new Campaign { name = name, productCode = productCode, duration = duration, priceManipulationLimit = priceManipulationLimit, targetSalesCount = targetSalesCount, status = CampaignStatus.Active, totalSales = 0, avgItemPrice = 0, lastSales = 0 };
            Campaigns.Add(name, campaign);
            Console.WriteLine($"Campaign created; name {campaign.name}, product {campaign.productCode}, duration {campaign.duration}, limit {campaign.priceManipulationLimit}, target sales count {campaign.targetSalesCount}");
            return campaign;
        }

        public static void EfFectToCampaign(string productCode, int quantity)
        {
            Product product = ProductRepo.GetProductInfo(productCode, false);
            foreach (Campaign campaign in Campaigns.Values)
            {
                if (campaign.productCode == productCode)
                {
                    campaign.avgItemPrice = (campaign.avgItemPrice * campaign.totalSales + product.price * quantity) / quantity + campaign.totalSales;
                    campaign.lastSales = quantity;
                    campaign.totalSales += quantity;
                    CampaignRepo.SetCampaign(campaign);
                }
            }
        }

        public static void SetCampaign(Campaign campaign)
        {
            Campaigns[campaign.name] = campaign;
        }

        public static Campaign GetCampaignInfo(string name)
        {
            Campaign campaign = Campaigns[name];
            Console.WriteLine($"Campaign {campaign.name} info; Status {campaign.status.ToDescription()}, Target Sales  {campaign.targetSalesCount}, Total Sales  {campaign.totalSales}, Turnover  {campaign.totalSales * campaign.avgItemPrice}, Average Item Price  {campaign.avgItemPrice}");
            return campaign;
        }
        public static void TimeTracker()
        {
            Product product;
            foreach (Campaign campaign in Campaigns.Values)
            {
                product = ProductRepo.GetProductInfo(campaign.productCode, false);
                if (TimeSimulator.Past() > campaign.duration)
                {
                    campaign.status = CampaignStatus.Ended;
                    SetCampaign(campaign);
                }
                if (campaign.status == CampaignStatus.Active && campaign.lastSales == 0)
                {
                    if (product.firstPrice - (product.firstPrice * campaign.priceManipulationLimit / 100) == product.price)
                    {
                        product.price = product.firstPrice;
                        ProductRepo.SetProduct(product);
                        continue;
                    }
                    product.price -= 5;
                    ProductRepo.SetProduct(product);
                }
                campaign.lastSales = 0;
                SetCampaign(campaign);
            }
        }
        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] mem_info = type.GetMember(en.ToString());

            if (mem_info != null && mem_info.Length > 0)
            {
                object[] attrs = mem_info[0].GetCustomAttributes(
                                              typeof(DescriptionAttribute),
                                              false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
    }
}
