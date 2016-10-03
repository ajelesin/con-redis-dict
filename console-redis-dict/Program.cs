namespace console_redis_dict
{
    using System;
    using RedisStore;
    using StackExchange.Redis.Extensions.Core;
    using Serializer;

    class Program
    {
        static void Main(string[] args)
        {
            var connection = RedisConnectionFactory.GetConnection();

            var serializer = new BinarySerializer();
            var cacheClient = new StackExchangeRedisCacheClient(connection, serializer);

            var o1 = new Poco(10);
            cacheClient.Add("mykey", o1);

            var o2 = cacheClient.Get<Poco>("mykey");
            Console.WriteLine(o2);
        }
    }
}
