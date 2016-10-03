namespace console_redis_dict.Utils
{
    using System;
    using System.Diagnostics;

    public sealed class OperationTimer : IDisposable
    {
        private Stopwatch _stopwatch;
        private string _text;

        public OperationTimer(string text)
        {
            PrepareForOperation();
            _text = text;
            _stopwatch = Stopwatch.StartNew();
        }


        public void Dispose()
        {
            Console.WriteLine("{0} {1}", _stopwatch.Elapsed, _text);
        }

        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
