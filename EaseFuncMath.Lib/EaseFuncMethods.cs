namespace Howardch.Animations
{
    public static class EaseFuncMethods
    {
        private static EaseFuncMethod easeOut;

        static EaseFuncMethods()
        {
            easeOut = new EaseOutQuadFuncMethod();
        }

        public static EaseFuncMethod EaseOutQuad { get { return easeOut; } }
    }
}