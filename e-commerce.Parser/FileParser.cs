using e_commerce.Business.Processors;
using e_commerce.Data.Command;
using System;
using System.Collections.Generic;
using System.IO;

namespace e_commerce.Parser
{
    public class FileParser
    {
        private string filePath { get; set; }
        private Dispatcher dispatcher {get;set;}


        public FileParser(string filePath)
        {
            this.filePath = filePath;
            dispatcher = new Dispatcher(Parse());
        }
        public IEnumerable<BaseCommand> Parse()
        {
            List<BaseCommand> commands = new();
            FileInfo fileInfo = new(filePath);
            string line = "";
            using (FileStream stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var streamReader = new StreamReader(stream);
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Trim() == "")
                        continue;
                    commands.Add(ParseCommand(line));
                }
                stream.Close();
            }
            return commands;
        }

        private BaseCommand ParseCommand(string line)
        {
            string[] commandArray = line.Split(' ');
            if (commandArray.Length < 2)
                throw new Exception("Informal Command");
            switch (commandArray[0].ToLower())
            {
                case "create_product":
                    return new CreateProductCommand(line);
                case "create_order":
                    return new CreateOrderCommand(line);
                case "create_campaign":
                    return new CreateCampaignCommand(line);
                case "get_product_info":
                    return new GetProductInfoCommand(line);
                case "get_campaign_info":
                    return new GetCampaignInfoCommand(line);
                case "increase_time":
                    return new IncreaseTimeCommand(line);
                default:
                    throw new Exception("unhandled command");
            }
        }

    }
}
