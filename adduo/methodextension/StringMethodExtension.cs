using adduo.basetype.enums;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

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

        public static bool SQLInjection(this string text)
        {
            var sql = new List<string>();
            var injection = false;
            sql.Add("--");
            sql.Add("SELECT");
            sql.Add("DELETE");
            sql.Add("INSERT");
            sql.Add("UPDATE");
            sql.Add("DROP");
            sql.Add("ALTER");
            sql.Add("ANALYZE");
            sql.Add("BEGIN");
            sql.Add("COMMIT");
            sql.Add("CREATE");
            sql.Add("DEALLOCATE");
            sql.Add("DECLARE");
            sql.Add("EXECUTE");
            sql.Add("EXPLAIN");
            sql.Add("GRANT");
            sql.Add("ROLLBACK");
            sql.Add("TRANSACTION");
            sql.Add("TRUNCATE");
            sql.Add("<");
            sql.Add(">");

            injection = (from c in sql
                         where text.ToUpper().Contains(c)
                         select c).Any();

            return injection;
        }


    }
}
