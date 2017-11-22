using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.AbstractFactory.Common
{
    public class Menu
    {
        private readonly MenuFactory _menuFactory;
        public Menu(MenuFactory menuFactory)
        {
            _menuFactory = menuFactory;
        }

        public IEnumerable<MenuItem> BuildCheapestMeal()
        {
            yield return _menuFactory.Drinks.OrderBy(x => x.Price).FirstOrDefault();
            yield return _menuFactory.Entrees.OrderBy(x => x.Price).FirstOrDefault();
        }

        public MenuItem GetMostExpensiveItem()
        {
            return _menuFactory.Entrees.Concat(_menuFactory.Drinks).OrderByDescending(x => x.Price).FirstOrDefault();
        }
    }
}
