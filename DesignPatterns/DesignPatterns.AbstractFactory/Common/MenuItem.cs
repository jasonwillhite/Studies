using System;
namespace DesignPatterns.AbstractFactory.Common
{
    public class MenuItem
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public override String ToString()
        {
            return $"{Name} - {Price:C}";   
        }
    }
}
