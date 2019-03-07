using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager customerManager;
        static object lockObject = new object();
        private CustomerManager() //Dış erişime kapalı
        {
        
        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (lockObject)//Aynı anda birden fazla create işlemi gerçekleşirse aynı isntance'ı dönmek için locklama yapılır. ikinci kez yaratma işlemi gerçekleşmez.
                //thread safe singleton
            {
                if (customerManager == null)
                {
                    customerManager = new CustomerManager();
                }

            }

            return customerManager;
            //kısaltımış hali

            /*return customerManager ?? (customerManager=new CustomerManager());*/

        }

        public void Save()
        {
            Console.WriteLine("Save");
        }

    }

    /* Her bir nesne için singleton pattern yazılmaz. 
    Factory Pattern ile nesnenin patterni oluşturulur.*/
}
