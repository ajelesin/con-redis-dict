namespace con_redis_dict.RedisStore
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using StackExchange.Redis;


    public class RedisStore<T> : IKeyValueStore<T>
    {
        private readonly IDatabase _db;

        public RedisStore(IDatabase db)
        {
            _db = db;
        } 

        public T Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));

            var bytes = (byte[]) _db.StringGet(key);
            var bf = new BinaryFormatter();
            var ms = new MemoryStream(bytes);

            var obj = bf.Deserialize(ms);
            return (T) obj;
        }

        public void Save(string key, T obj)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            var bytes = ms.ToArray();

            _db.StringSet(key, bytes);
        }

        public void Delete(string key)
        {
            throw new NotSupportedException("xyi");
        }
    }
}
