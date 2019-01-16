using System.Collections.Generic;

namespace DesignPatterns.AbstractFactory.Common
{
    public class MenuFactory
    {        
        public MenuFactory(string name)
        {
            Name = name;
        }

        public string Name { get; internal set; }

        public virtual IEnumerable<MenuItem> Drinks { get; }

        public virtual IEnumerable<MenuItem> Entrees { get; }
    }
}
