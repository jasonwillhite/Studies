using DesignPatterns.AbstractFactory.Common;

namespace DesignPatterns.AbstractFactory.Factories
{
    public class RestaurantFactory : MenuFactory
    {
        public RestaurantFactory() : base(nameof(RestaurantFactory))
        {
            
        }

        public override System.Collections.Generic.IEnumerable<MenuItem> Drinks
        {
            get
            {
                yield return new MenuItem() { Name = "Steak", Price = 20.99M };
                yield return new MenuItem() { Name = "Potatoes", Price = 6.32M };
                yield return new MenuItem() { Name = "Salad", Price = 7.15M };
            }
        }

        public override System.Collections.Generic.IEnumerable<MenuItem> Entrees
        {
            get
            {
                yield return new MenuItem() { Name = "Wine", Price = 9.15M };
                yield return new MenuItem() { Name = "Beer", Price = 5.99M };
                yield return new MenuItem() { Name = "Cocktail", Price = 13.99M };
            }
        }
    }
}
