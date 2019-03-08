using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { FirtsName="Engin",LastName="Demiroğ",City="Ankara",Id=1};
            

            Customer customer2 =(Customer) customer.Clone();
            customer2.FirtsName = "Salih";
            Console.WriteLine(customer.FirtsName);
            Console.WriteLine(customer2.FirtsName);


        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }

    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();    
        }
    }

    public class Employee: Person
    {
        public decimal Salary{ get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

}
