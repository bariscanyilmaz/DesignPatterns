using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Attach(new CustomerObserver());
            productManager.Attach(new EmployeeObserver());
            productManager.UpdatePrice();
        }
    }

    class ProductManager
    {
        List<Observer> observers = new List<Observer>();

        public void UpdatePrice()
        {
            Console.WriteLine("Product Price Updated");
            Notify();
        }

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        private void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message To Customer : Product Price Change");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine();
        }
    }
}
