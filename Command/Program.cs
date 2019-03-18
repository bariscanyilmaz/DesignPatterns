using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockController stockController = new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);

            stockController.PlaceOrders();
            Console.ReadLine();


        }

    }

    class StockManager
    {
        private string name = "Laptop";
        private int quantity = 10;
        
        public void Buy()
        {
            Console.WriteLine("Stock :{0} ,{1} bought!!",name,quantity);
        }

        public void Sell()
        {
            Console.WriteLine("Stock :{0} ,{1} sold!!", name, quantity);

        }
    }

    interface IOrder
    {        
        void Execute();
    }

    class BuyStock : IOrder
    {
        private StockManager stockManager;
        public BuyStock(StockManager _stockManager)
        {
            stockManager = _stockManager;
        }

        public void Execute()
        {
            stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {
        private StockManager stockManager;
        public SellStock(StockManager _stockManager)
        {
            stockManager = _stockManager;
        }
        public void Execute()
        {
            stockManager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> orders = new List<IOrder>();
        public void TakeOrder(IOrder order)
        {
            orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in orders)
            {
                order.Execute();
            }

            orders.Clear();
        }

    }
}
