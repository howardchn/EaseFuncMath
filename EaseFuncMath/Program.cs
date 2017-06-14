using Howardch.Animations;
using System;

namespace ConsoleApp7
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //var from = 0;
            //var to = 1000;
            //var duration = 60;
            //for (var i = 1; i <= duration; i++)
            //{
            //    //double v = LinearTween(i, from, to, duration);
            //    //double v = EaseInQuad(i, from, to, duration);
            //    //double v = EaseOutQuad(i, from, to, duration);
            //    //Console.WriteLine(v);
            //}

            EaseFuncAnimator.RunAsync(2000, 0, 1000, v =>
            {
                Console.WriteLine(v);
            }).Wait();

            Console.ReadLine();
        }

        public static double LinearTween(double time, double begin, double change, double duration)
        {
            return change * time / duration + begin;
        }

        public static double EaseInQuad(double time, double begin, double change, double duration)
        {
            time /= duration;
            return change * time * time + begin;
        }

        public static double EaseOutQuad(double time, double begin, double change, double duration)
        {
            time /= duration;
            return -change * time * (time - 2) + begin;
        }
    }
}
