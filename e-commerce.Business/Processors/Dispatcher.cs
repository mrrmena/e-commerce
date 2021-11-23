using e_commerce.Data.Command;
using System;
using System.Collections.Generic;

namespace e_commerce.Business.Processors
{
    public class Dispatcher
    {
        private IEnumerable <BaseCommand> scenario { get; set; }
        public Dispatcher(IEnumerable<BaseCommand> scenario)
        {
            this.scenario = scenario;
            Run();
        }

        private void Run()
        {
            foreach (BaseCommand command in scenario)
            {
                switch (command.commandType)
                {
                    case Data.Command.CommandType.CreateProduct:
                        RunCreateProduct(command as CreateProductCommand);
                        break;
                    case Data.Command.CommandType.CreateOrder:
                        RunCreateOrder(command as CreateOrderCommand);
                        break;
                    case Data.Command.CommandType.CreateCampaign:
                        RunCreateCampaign(command as CreateCampaignCommand);
                        break;
                    case Data.Command.CommandType.GetProductInfo:
                        RunGetProductInfo(command as GetProductInfoCommand);
                        break;
                    case Data.Command.CommandType.GetCampaignInfo:
                        RunGetCampaignInfo(command as GetCampaignInfoCommand);
                        break;
                    case Data.Command.CommandType.IncreaceTime:
                        RunIncreaceTime(command as IncreaseTimeCommand);
                        break;
                    default:
                        throw new Exception("unhandled object type");
                }
            }
        }

        private void RunIncreaceTime(IncreaseTimeCommand increaseTimeCommand)
        {
            TimeSimulator.IncrementTime(increaseTimeCommand.hour);
        }

        private void RunGetCampaignInfo(GetCampaignInfoCommand getCampaignInfoCommand)
        {
            CampaignRepo.GetCampaignInfo(getCampaignInfoCommand.name);
        }

        private void RunGetProductInfo(GetProductInfoCommand getProductInfoCommand)
        {
            ProductRepo.GetProductInfo(getProductInfoCommand.productCode);
        }

        private void RunCreateCampaign(CreateCampaignCommand createCampaignCommand)
        {
            CampaignRepo.CreateCampaign(createCampaignCommand.name, createCampaignCommand.productCode, createCampaignCommand.duration, createCampaignCommand.priceManipulationLimit, createCampaignCommand.targetSalesCount);
        }

        private void RunCreateOrder(CreateOrderCommand createOrderCommand)
        {
            OrderRepo.CreateOrder(createOrderCommand.productCode,createOrderCommand.quantity);
        }

        private void RunCreateProduct(CreateProductCommand createProductCommand)
        {
            ProductRepo.CreateProduct(createProductCommand.productCode, createProductCommand.price, createProductCommand.stock);
        }

        
    }
}
