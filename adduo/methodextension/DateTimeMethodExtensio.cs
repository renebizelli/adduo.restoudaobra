using System;
using System.Collections.Generic;
using System.Text;

namespace adduo.methodextension
{
    public static class DateTimeMethodExtensio
    {
        public static DateTime AjustNow(this DateTime dt, int hoursAjust = 4)
        {
            return dt.AddHours(hoursAjust);
        }
    }
}
