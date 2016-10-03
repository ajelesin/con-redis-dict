namespace console_redis_dict.Serializer
{
    using System;
    using System.Threading.Tasks;
    using StackExchange.Redis.Extensions.Core;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;

    public class BinarySerializer : ISerializer
    {
        public object Deserialize(byte[] serializedObject)
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream(serializedObject);
            var obj = bf.Deserialize(ms);
            return obj;
        }

        public T Deserialize<T>(byte[] serializedObject)
        {
            return (T)Deserialize(serializedObject);
        }

        public byte[] Serialize(object item)
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, item);

            var content = ms.ToArray();
            return content;
        }

        public Task<object> DeserializeAsync(byte[] serializedObject)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeserializeAsync<T>(byte[] serializedObject)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> SerializeAsync(object item)
        {
            throw new NotImplementedException();
        }
    }
}
