namespace adduo.methodextension
{
    public static class IntMethodExtension
    {
        public static bool Zero(this int _int)
        {
            return _int.Equals(0);
        }

        public static bool NotZero(this int _int)
        {
            return !_int.Equals(0);
        }
    }
}
