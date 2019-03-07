using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    //nesnellik zaafiyetini önlemek için bir inheritance kullan
    public abstract class Logging
    {
        public abstract void Log(string message);

    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RedisCache");
        }

    }


    public abstract class CrossCuttingConcernsFactory
    {

        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();

    }

    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }

    }

    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager:IProductService
    {

        private CrossCuttingConcernsFactory crossCuttingConcernsFactory;
        private Logging logging;
        private Caching caching;

        public ProductManager(CrossCuttingConcernsFactory _crossCuttingConcernsFactory)
        {
            crossCuttingConcernsFactory = _crossCuttingConcernsFactory;
            logging = crossCuttingConcernsFactory.CreateLogger();
            caching = crossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            logging.Log("Logged");
            caching.Cache("Cache");
            Console.WriteLine("Products Listed");
        }


    }

    public interface IProductService
    {

    }

}
