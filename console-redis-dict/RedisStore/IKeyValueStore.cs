namespace console_redis_dict.RedisStore
{
    public interface IKeyValueStore<T>
    {
        T Get(string key);
        void Save(string key, T obj);
        void Delete(string key);
    }
}
