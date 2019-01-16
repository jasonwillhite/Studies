using System;
namespace DesignPatterns.Singleton.Common
{
    // Check Jon Skeet's well put together version of the Singleton pattern here:
    // http://csharpindepth.com/articles/general/singleton.aspx
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance { get { return lazy.Value; } }

        private Singleton()
        {
        }
    }


}
