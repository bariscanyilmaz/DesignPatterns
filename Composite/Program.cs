using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee engin = new Employee { Name="Engin Demiroğ"};
            Employee salih = new Employee { Name = "Salih Demiroğ" };

            
            
            engin.AddSubOrdinate(salih);

            Employee derin= new Employee { Name = "Derin Demiroğ" };
            engin.AddSubOrdinate(derin);

            Contractor ali = new Contractor { Name = "Ali" };
            derin.AddSubOrdinate(ali);

            Employee ahmet = new Employee { Name = "ahmet Demiroğ" };
            salih.AddSubOrdinate(ahmet);


            Console.WriteLine(engin.Name);
            foreach (Employee manager in engin)
            {
                Console.WriteLine("  {0}",manager.Name);

                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string  Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> subordinates= new List<IPerson>();

        public void AddSubOrdinate(IPerson person)
        {
            subordinates.Add(person);
        }


        public void RemoveSubOrdinate(IPerson person)
        {
            subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return subordinates[index];
        }

        public string Name { get ; set ; }


        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in subordinates)
            {
                yield return subordinate;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
