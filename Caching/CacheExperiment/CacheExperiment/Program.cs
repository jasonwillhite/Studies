using System;
using System.Runtime.CompilerServices;
using CacheExperiment.Common;
using StackExchange.Redis;

namespace CacheExperiment
{
    class MainClass
    {
        private static readonly ICache cache = new LaCache();

        public static void Main(string[] args)
        {

            //using (var conn = ConnectionMultiplexer.Connect("127.0.0.1:6379"))
            //{
            //    var db = conn.GetDatabase();

            //    RedisKey key = Me();
            //    db.KeyDelete(key);
            //    db.StringSet(key, "abc");

            //    string s = (string)db.ScriptEvaluate(@"local val = redis.call('get', KEYS[1]) redis.call('del', KEYS[1])return val", new RedisKey[] { key }, flags: CommandFlags.NoScriptCache);

            //    Console.WriteLine(s);
            //    Console.WriteLine(db.KeyExists(key));
            //}       

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost, abortConnect=false,");

            Console.WriteLine("Saving random data in cache");
            SaveBigData();

            Console.WriteLine("Reading data from cache");
            ReadData();

            Console.ReadLine();
        }

        internal static string Me([CallerMemberName] string caller = null)
        {
            return caller;
        }

        internal static void ReadData()
        {
            //var cache =  //RedisConnectorHelper.Connection.GetDatabase();
            var devicesCount = 10000;
            for (int i = 0; i < devicesCount; i++)
            {
                var value = cache.Get<string>($"Device_Status:{i}");
                Console.WriteLine($"Valor={value}");
            }
        }

        internal static void SaveBigData()
        {
            var devicesCount = 10000;
            var rnd = new Random();
            //var cache = RedisConnectorHelper.Connection.GetDatabase();

            for (int i = 1; i < devicesCount; i++)
            {
                var value = rnd.Next(0, 10000);
                cache.Add($"Device_Status:{i}", value);
            }
        }
    }
}
