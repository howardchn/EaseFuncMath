namespace Howardch.Animations
{
    public abstract class EaseFuncMethod
    {
        public abstract double GetCurrent(double t, double b, double c, double d);
    }

    public class EaseOutQuadFuncMethod : EaseFuncMethod
    {
        public override double GetCurrent(double t, double b, double c, double d)
        {
            t /= d;
            return -c * t * (t - 2) + b;
        }
    }
}
