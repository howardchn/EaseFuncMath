using System;
using System.Threading;
using System.Threading.Tasks;

namespace Howardch.Animations
{
    public static class EaseFuncAnimator
    {
        public static double Fps = 60;

        public static async Task RunAsync(double duration, double from, double to, Action<double> tick)
        {
            await RunAsync(duration, from, to, tick, null, EaseFuncMethods.EaseOutQuad);
        }

        public static async Task RunAsync(double duration, double from, double to, Action<double> tick, CancellationTokenSource cancellation)
        {
            await RunAsync(duration, from, to, tick, cancellation, EaseFuncMethods.EaseOutQuad);
        }

        public static async Task RunAsync(double duration, double from, double to, Action<double> tick, CancellationTokenSource cancellation, EaseFuncMethod easeFunc)
        {
            if (tick == null || easeFunc == null) return;

            double suspend = 1000d / Fps;
            int steps = (int)(duration / suspend);
            double change = to - from;
            for (int i = 1; i <= steps; i++)
            {
                if (cancellation != null && cancellation.IsCancellationRequested) break;

                double v = easeFunc.GetCurrent(i, 0, change, steps);
                tick(v);

                await Task.Run(() => Thread.Sleep((int)suspend));
            }
        }

        public static async Task RunAsync(double duration, double from, double to, Action<double, int> tick, CancellationTokenSource cancellation)
        {
            if (tick == null) return;

            double suspend = 1000d / Fps;
            int steps = (int)(duration / suspend);
            double change = to - from;
            for (int i = 1; i <= steps; i++)
            {
                if (cancellation != null && cancellation.IsCancellationRequested) break;
                tick(i, steps);

                await Task.Run(() => Thread.Sleep((int)suspend));
            }
        }
    }
}
