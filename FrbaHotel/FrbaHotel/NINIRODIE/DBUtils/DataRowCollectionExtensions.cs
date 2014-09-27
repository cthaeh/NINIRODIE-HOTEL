using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaHotel.NINIRODIE.DBUtils
{
    static class DataRowCollectionExtensions
    {
        public static List<TResult> ToList<TResult>(this DataRowCollection dataRows, Func<DataRow, TResult> function)
        {
            return dataRows.Cast<DataRow>().Select(function).ToList();
        }

        public static TResult GetFirstAs<TResult>(this DataRowCollection dataRows, Func<DataRow, TResult> function)
        where TResult : class
        {
            return dataRows.Count == 0 ? null : function.Invoke(dataRows[0]);
        }
    }
}