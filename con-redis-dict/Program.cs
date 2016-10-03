using System;
using con_redis_dict.RedisStore;

namespace con_redis_dict
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = RedisConnectionFactory.GetConnection();
            var db = connection.GetDatabase(db: 0);

            var store = new RedisStore<Poco>(db);

            var p1 = new Poco(10);
            store.Save("mykey", p1);

            var p2 = store.Get("mykey");
            Console.WriteLine(p2);
        }
    }


    public class Poco
    {
        private readonly int _state;

        public Poco(int value)
        {
            _state = value;
        }

        public override string ToString()
        {
            return _state.ToString();
        }
    }


}
