namespace con_redis_dict.RedisStore
{
    using System;
    using System.Configuration;
    using StackExchange.Redis;


    public class RedisConnectionFactory
    {
        private static readonly Lazy<ConnectionMultiplexer> Connection;

        static RedisConnectionFactory()
        {
            var connectionString = ConfigurationManager.AppSettings["RedisConnection"];
            var options = ConfigurationOptions.Parse(connectionString);

            Connection = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(options)
                );
        }

        public static ConnectionMultiplexer GetConnection() => Connection.Value;
    }
}
