using System;
using DesignPatterns.AbstractFactory.Common;

namespace DesignPatterns.AbstractFactory.Factories
{
    public class FastFoodFactory : MenuFactory
    {
        public FastFoodFactory() : base("Fast Food Menu")
        {

        }

        public override System.Collections.Generic.IEnumerable<MenuItem> Entrees
        {
            get
            {
                yield return new MenuItem() { Name = "Burger", Price = 2.99M };
                yield return new MenuItem() { Name = "Fries", Price = 1.99M };
                yield return new MenuItem() { Name = "Nuggets", Price = 3.99M };
                yield return new MenuItem() { Name = "Pie", Price = 0.99M };
            }
        }

        public override System.Collections.Generic.IEnumerable<MenuItem> Drinks
        {
            get
            {
                yield return new MenuItem() { Name = "Soda", Price = 2.99M };
                yield return new MenuItem() { Name = "Shake", Price = 1.99M };
                yield return new MenuItem() { Name = "Coffee", Price = 3.99M };
                yield return new MenuItem() { Name = "Beer", Price = 0.99M };
            }
        }
    }
}
