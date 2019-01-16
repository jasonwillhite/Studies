using System;
using System.Linq;
using System.Reflection;
using DesignPatterns.AbstractFactory.Common;

namespace DesignPatterns.AbstractFactory
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // An abstract factory is often a Singleton

            // Get the name of the factory from the app settings
            string factory = System.Configuration.ConfigurationManager.AppSettings["factory"];

            // Find the object with the corresponding name
            var type = Assembly.GetExecutingAssembly().ExportedTypes.FirstOrDefault(x => x.Name.ToLower().Contains(factory.ToLower()));

            // Instantiate the factory
            var f = Activator.CreateInstance(type) as MenuFactory;
            Menu menu = new Menu(f);

            Console.WriteLine($"Menu for {f.Name}");
            menu.BuildCheapestMeal().ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine($"Most expensive thing is {menu.GetMostExpensiveItem()}");
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                return Uri.UnescapeDataString(uri.Path);;
            }
        }
    }
}
