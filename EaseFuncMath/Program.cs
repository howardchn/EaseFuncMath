using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = 0;
            var to = 1000;
            var duration = 60;
            for (var i = 1; i <= duration; i++)
            {
                //double v = LinearTween(i, from, to, duration);
                //double v = EaseInQuad(i, from, to, duration);
                double v = EaseOutQuad(i, from, to, duration);
                Console.WriteLine(v);
            }
        }

        public static double LinearTween(int currentTime, double from, double to, int duration)
        {
            return to * currentTime / duration + from;
        }

        public static double EaseInQuad(int currentTime, double from, double to, int duration)
        {
            double t = currentTime;
            t /= duration;
            return to * t * t + from;
        }

        public static double EaseOutQuad(int currentTime, double from, double to, int duration)
        {
            double t = currentTime;
            t /= duration;
            return -to * t * (t - 2) + from;
        }
    }
}
