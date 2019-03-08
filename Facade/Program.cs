using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    interface ILogging
    {
        void Log();
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ICaching
    {
        void Cache();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Caching");
        }
    }

    interface IAuthorize
    {
        void CheckUser();
    }

    class Authorize:IAuthorize

    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    class CustomerManager
    {
        private CrossCuttingConcernsFacade concernsFacade;

        public CustomerManager()
        {
            concernsFacade = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            concernsFacade.Authorize.CheckUser();
            concernsFacade.Caching.Cache();
            concernsFacade.Logging.Log();
            concernsFacade.Validation.Validate();
            Console.WriteLine("Saved");
        }
        

    }

    interface IValidate
    {
        void Validate();
    }

    class Validetation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validation;
        public CrossCuttingConcernsFacade()
        {
            Validation = new Validetation();
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}
