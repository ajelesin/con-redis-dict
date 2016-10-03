namespace console_redis_dict
{
    using System;


    [Serializable]
    public class Poco
    {
        private readonly int _state;

        public Poco() { }

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
