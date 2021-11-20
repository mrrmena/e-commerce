using e_commerce.Models.Model;
using e_commerce.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Business
{
    public static class Storage
    {
        public static Dictionary<string, Dictionary<string, Storable>> DataStoreage = new Dictionary<string, Dictionary<string, Storable>>();
        public static void AddStorage(Storable storable, string objectName)
        {
            try
            {
                if (DataStoreage.ContainsKey(objectName))
                {
                    if (DataStoreage[objectName].ContainsKey(storable.key))
                    {
                        throw new Exception($"This {objectName} already created");
                    }
                    else
                    {
                        DataStoreage[objectName].Add(storable.key, storable);
                    }
                }
                else
                {
                    Dictionary<string, Storable> storageObject = new Dictionary<string, Storable>();
                    storageObject.Add(storable.key, storable);
                    DataStoreage.Add(objectName, storageObject);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unhandled exception when campaign updated. Exception : " + ex.Message);
            }
            
        }

        public static void TimeTracker()
        {
            foreach (Campaign storage_item in DataStoreage["campaign"].Values)
            {
                Products products = Storage.DataStoreage["product"][storage_item.product_code] as Products;
                if ((Helper.Time - Helper.Time0).Days > storage_item.duration)
                {
                    storage_item.CampaignStatus.status = "Ended";
                }
                if (storage_item.CampaignStatus.status.Equals("Active") && storage_item.CampaignStatus.last_sales == 0)
                {
                    if (products.first_price * storage_item.price_limit / 100  == products.price)
                    {
                        products.price = products.first_price;
                        Storage.DataStoreage["product"][storage_item.product_code] = products;
                        continue;
                    }
                    products.price = products.price - 5;
                    Storage.DataStoreage["product"][storage_item.product_code] = products;
                }
                storage_item.CampaignStatus.last_sales = 0;
            }
        }

        public static void EffectToCampaign(Orders storable)
        {
            try
            {

                Campaign campaign = Storage.DataStoreage["campaign"][storable.product_code] as Campaign;
                Products products = Storage.DataStoreage["product"][storable.product_code] as Products;
                campaign.CampaignStatus.last_sales = storable.quantity;
                campaign.CampaignStatus.avg_item_price = (campaign.CampaignStatus.avg_item_price * campaign.CampaignStatus.total_sales + products.price * storable.quantity) / (storable.quantity + campaign.CampaignStatus.total_sales);
                campaign.CampaignStatus.total_sales += storable.quantity;
                Storage.DataStoreage["campaign"][storable.product_code] = campaign;
            }
            catch (Exception ex)
            {
                throw new Exception("Unhandled exception when campaign updated. Exception : " + ex.Message);
            }
        }

    }
}
