namespace DesignPatterns.AbstractFactory.Common
{
    public class MenuItem
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Price:C}";   
        }
    }
}
