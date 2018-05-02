using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.Redis;
using System.Configuration;
using Newtonsoft.Json;


namespace CacheExperiment.Common
{
    public class LaCache : ICache
    {
        private IDatabase cache = null;
        private ConnectionMultiplexer connection = null;
        //private readonly bool IsCacheEnabled;

        /// <summary>
        /// Gets the cacheEndPoint
        /// </summary>
        public string cacheEndPoint
        {
            get
            {
                return string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["CacheEndPoint"]) ? "" :
                    Convert.ToString(ConfigurationManager.AppSettings["CacheEndPoint"]);
            }
        }

        public bool IsCacheEnabled
        {
            get
            {
                bool _isCache = false;
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["IsCacheEnabled"]))
                {
                    _isCache = Convert.ToBoolean(ConfigurationManager.AppSettings["IsCacheEnabled"]);
                }
                return _isCache;
            }
        }

        /// <summary>
        /// Constructor of CacheUtility
        /// </summary>
        public LaCache()
        {
            if (IsCacheEnabled && !string.IsNullOrEmpty(cacheEndPoint))
            {
                connection = ConnectionMultiplexer.Connect(cacheEndPoint);
                cache = connection.GetDatabase();
            }
        }

        /// <summary>
        /// Fetching data from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>     
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            if (cache != null && IsCacheEnabled)
            {
                if (!cache.KeyExists(key))
                {
                    return null;
                }
                else
                {
                    var deserializedObject = cache.StringGet(key);
                    return JsonConvert.DeserializeObject<T>(deserializedObject);
                }
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Pushing data to cache 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>      
        public void Add<T>(string key, T value)
        {
            if (cache != null && IsCacheEnabled)
            {
                var serializedObject = JsonConvert.SerializeObject(value);
                cache.StringSet(key, serializedObject);
            }
        }

        /// <summary>
        /// Flushing out all the cache keys
        /// </summary>
        /// <param name="_logger"></param>
        public void FlushCache()
        {
            if (IsCacheEnabled)
            {
                var endpoints = connection.GetEndPoints(true);
                foreach (var endpoint in endpoints)
                {
                    var server = connection.GetServer(endpoint);
                    server.FlushDatabase();
                }
            }
        }

        /// <summary>
        /// Deleting cache key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="_logger"></param>
        public void DeleteKey(string key)
        {
            if (cache != null && IsCacheEnabled)
            {
                if (cache.KeyExists(key))
                {
                    cache.KeyDelete(key);
                }
            }
        }
    }
}