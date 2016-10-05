namespace console_redis_dict
{
    using System;


    [Serializable]
    public class Poco
    {
        private int _state;

        public Poco() { }

        public Poco(int state)
        {
            _state = state;
        }

        public void Change(int newState)
        {
            _state = newState;
        }

        public override string ToString()
        {
            return _state.ToString();
        }
    }
}
