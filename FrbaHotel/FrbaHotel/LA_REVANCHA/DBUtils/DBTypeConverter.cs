using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.LA_REVANCHA.DBUtils
{
    class DBTypeConverter
    {
        public static DateTime ToDateTime(object ob)
        {
            return ob.GetType() != typeof(DateTime) ? DateTime.MinValue : (DateTime)ob;
        }

        public static String ToSQLDateTime(DateTime dateTime)
        {
            return (dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue) ?
                dateTime.ToString("yyyyMMdd HH:mm:ss.fff") :
                new DateTime(1900, 1, 1).ToString("yyyyMMdd HH:mm:ss.fff");
        }
    }
}
