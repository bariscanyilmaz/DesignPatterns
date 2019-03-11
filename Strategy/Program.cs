using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new After2010CreditCalculater();
            customerManager.SaveCredit();


            customerManager.CreditCalculatorBase = new Before2010CreditCalculater();
            customerManager.SaveCredit();
            Console.ReadLine();
            
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculater : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit Calculated using Before2010");
        }
    }


    class After2010CreditCalculater : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit Calculated using After2010");
        }
    }

    class CustomerManager
    {

        public CreditCalculatorBase CreditCalculatorBase { get; set; }

        public void SaveCredit()
        {
            Console.WriteLine("Customer Manager Business");
            CreditCalculatorBase.Calculate();

        }
    }
}
