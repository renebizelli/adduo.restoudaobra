namespace adduo.methodextension
{
    public static class DecimalMethodExtension
    {
        public static bool Zero(this decimal number)
        {
            return number.Equals(0);
        }

        public static bool NotZero(this decimal number)
        {
            return !number.Equals(0);
        }


    }
}
