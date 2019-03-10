using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
        }
    }
    class ProductManager
    {
        private ILogger logger;

        public ProductManager(ILogger _logger)
        {
            logger = _logger;
        }


        public void Save()
        {
            logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);

    }

    class OwnLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged {0} With own logger service ",message);

        }
    }

    //Nuget
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged withh Log4Net {0}",message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
