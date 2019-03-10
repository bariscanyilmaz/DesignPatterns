using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonalCar { Make="BMW",Model="3.20",HirePrice=2500};
            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine("Conceret HirePrice:{0}",personelCar.HirePrice);
            Console.WriteLine("Special Offer HirePrice:{0}", specialOffer.HirePrice);

        }
    }

    abstract class  CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get ; set; }
        public override string Model { get ; set ; }
        public override decimal HirePrice { get ; set; }

    }

    class CommercialCar : CarBase
    {
        public override string Make { get ; set ; }
        public override string Model { get ; set ; }
        public override decimal HirePrice { get ; set ; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase carBase;
        protected CarDecoratorBase(CarBase _carBase)
        {
            carBase = _carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        private readonly CarBase carBase;
        public int DiscountPercentage { get; set; }
        public SpecialOffer(CarBase _carBase) : base(_carBase)
        {
            carBase = _carBase;
        }

        public override string Make { get; set ; }
        public override string Model { get ; set; }
        public override decimal HirePrice {
            get
            {
                return carBase.HirePrice-carBase.HirePrice*DiscountPercentage/100;
            }

            set { }
        }

        
    }
}
