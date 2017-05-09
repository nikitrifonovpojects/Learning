using System;
using System.Diagnostics;

namespace ExtensionDelegatesLamdbaLinq
{
    public class Timer
    {
        private readonly int seconds;
        public delegate void PrintSomething();

        public Timer(int seconds)
        {
            this.seconds = seconds;

        }

        public void InvokeDelegate()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var myDelegate = new PrintSomething(PrintTime);

            while (true)
            {
                if (stopwatch.Elapsed.Seconds != this.seconds)
                {
                    continue;
                }

                myDelegate.Invoke();
                stopwatch.Restart();
            }
        }

        private static void PrintTime()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
