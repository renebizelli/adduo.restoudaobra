using adduo.basetype.enums;
using System.Text.RegularExpressions;

namespace adduo.methodextension
{
    public static class StringMethodExtension
    {
        public static bool IsNullOrEmpty(this string _string)
        {
            return string.IsNullOrEmpty(_string);
        }

        public static bool NotIsNullOrEmpty(this string _string)
        {
            return !_string.IsNullOrEmpty();
        }

        public static string OnlyNumber(this string _string)
        {
            var result = string.Empty;

            if (_string.NotIsNull())
            {
                result = Regex.Replace(_string, @"[^\d]", "");
            }

            return result;
        }

        public static DATA_TYPE DataType(this string _string)
        {
            var type = DATA_TYPE.NONE;

            var result = new Regex(@"[a-z]");

            if (result.IsMatch(_string))
            {
                type = DATA_TYPE.EMAIL;
            }
            else
            {
                type = DATA_TYPE.CPF;
            }

            return type;
        }

        public static string EmailOfuscator(this string _string)
        {
            return _string;
        }
    }
}
