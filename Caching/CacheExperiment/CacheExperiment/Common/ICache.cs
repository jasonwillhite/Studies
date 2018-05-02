namespace CacheExperiment.Common
{
    public interface ICache
    {

        /// <summary>
        /// Fetching data from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>     
        /// <returns></returns>
        T Get<T>(string key) where T : class;

        /// <summary>
        /// Pushing data to cache 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>      
        void Add<T>(string key, T value);

        /// <summary>
        /// Flushing out all the cache keys
        /// </summary>
        /// <param name="_logger"></param>
        void FlushCache();

        /// <summary>
        /// Deleting cache key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="_logger"></param>
        void DeleteKey(string key);
    }
}
