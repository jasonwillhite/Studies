using DesignPatterns.AbstractFactory.Common;

namespace DesignPatterns.AbstractFactory.Factories
{
    public class OrganicDinerFactory : MenuFactory
    {
        public OrganicDinerFactory() : base(nameof(OrganicDinerFactory))
        {
            
        }

        public override System.Collections.Generic.IEnumerable<MenuItem> Drinks
        {
            get
            {
                yield return new MenuItem() { Name = "Kambucha", Price = 3.99M };
                yield return new MenuItem() { Name = "Water", Price = 0.99M };
                yield return new MenuItem() { Name = "Green Tea", Price = 2.99M };
            }
        }

        public override System.Collections.Generic.IEnumerable<MenuItem> Entrees
        {
            get
            {
                yield return new MenuItem() { Name = "Organic Chicken", Price = 4.99M };
                yield return new MenuItem() { Name = "Tofu", Price = 5.99M };
                yield return new MenuItem() { Name = "Soy Patty", Price = 6.99M };
            }
        }
    }
}
