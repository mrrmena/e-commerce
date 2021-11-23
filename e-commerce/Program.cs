using e_commerce.Parser;
using e_commerce.Test;
using System;

namespace e_commerce.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            FileParser parser;
            string command;
            try
            {
                command = args.Length > 0 ? args[0] : Console.ReadLine();
                parser = new FileParser(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
