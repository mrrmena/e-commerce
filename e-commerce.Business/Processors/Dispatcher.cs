using e_commerce.Models.Model;
using e_commerce.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Business.Processors
{
    public class Dispatcher
    {
        private string command { get; set; }
        private string redirect_command { get; set; }
        private string[] object_array { get; set; }
        private string object_name { get; set; }
        private string junk_command { get; } = "_info";
        public string return_command { get; set; }
        public Dispatcher(string command)
        {
            this.command = command.ToLower();
            SplitCommand();
            RunCommand();
        }

        private void SplitCommand()
        {
            string[] commandArray = command.Replace(junk_command, "").Split('_');
            if (commandArray.Length < 2)
            {
                throw new Exception("Informal Command");
            }
            else
            {
                redirect_command = commandArray[0];
                object_array = commandArray[1].Split(' ');
                if (object_array.Length < 2)
                    throw new Exception("Informal command for creating object");
                object_name = object_array[0];
            }
        }

        public void RunCommand()
        {
            if (CommandType.create.ToDescription().Equals(redirect_command))
            {
                AddToStorage();
            }
            else if (CommandType.get.ToDescription().Equals(redirect_command))
            {
                GetFromStroage();
            }
            else if (CommandType.increace.ToDescription().Equals(redirect_command))
            {
                Helper.Time = Helper.Time.AddHours(Convert.ToInt32(object_array[1]));
                return_command = Helper.GetTime();
                Storage.TimeTracker();
            }
            else
                throw new Exception("Informal RunCommand");

        }


        private void GetFromStroage()
        {
            //reflaction can be used but it will efect run time
            Storable storable = Storage.DataStoreage[object_name][object_array[1]];
            if (storable is Products) // objectName.Equals("product")
            {
                return_command = $"Product {(storable as Products).products_code} info; price {((Products)storable).price}, stock {(storable as Products).stock}";
            }
            else if (object_name.Equals("campaign")) //storable is Campaign
            { // TO DO kampanya bilgilerini ayarla
                return_command = $"Campaign {(storable as Campaign).name} info; Status {(storable as Campaign).CampaignStatus.status}, Target Sales  {(storable as Campaign).target_sales}, Total Sales  {(storable as Campaign).CampaignStatus.total_sales}, Turnover  {(storable as Campaign).CampaignStatus.total_sales * (storable as Campaign).CampaignStatus.avg_item_price}, Average Item Price  {(storable as Campaign).CampaignStatus.avg_item_price}";
            }
            else
            {
                throw new Exception($"You could not get any info about {object_name}");
            }
        }

        private void AddToStorage()
        {
            
            Storable storable;
            switch (object_name)
            {
                case "product":
                    if (object_array.Length < 4)
                        throw new Exception("Missing value for Products");
                    storable = new Products(object_array);
                    break;
                case "order":
                    if (object_array.Length < 3)
                        throw new Exception("Missing value for Orders");
                    storable = new Orders(object_array);
                    Storage.EffectToCampaign(((Orders)storable));
                    break;
                case "campaign":
                    if (object_array.Length < 6)
                        throw new Exception("Missing value for Campaign");
                    storable = new Campaign(object_array);
                    break;
                default:
                    throw new Exception("Unrecognize object type");
            }
            Storage.AddStorage(storable,object_name);
            return_command = storable.created_comand;
        }
        
    }
}
