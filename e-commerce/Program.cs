using e_commerce.Business.Processors;
using System;

namespace e_commerce
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher;
            while (true)
            {
                try
                {
                    string command = Console.ReadLine();
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
