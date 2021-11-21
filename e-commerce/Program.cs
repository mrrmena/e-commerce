using e_commerce.Business.Processors;
using System;

namespace e_commerce.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher;
            string command;
            while (true)
            {
                try
                {
                    command = args.Length > 0 ? args[0] : Console.ReadLine();
                    dispatcher = new Dispatcher(command);
                    Console.WriteLine(dispatcher.return_command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
