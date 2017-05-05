using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Academy.Models.Utils
{
    public static class Utility
    {
        public static string ListItemsInCollection<T>(IList<T> collection)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < collection.Count; i++)
            {
                var current = collection[i];
                if (i == collection.Count - 1)
                {
                    builder.Append(current.ToString());
                }
                else
                {
                    builder.AppendLine(current.ToString());
                }
            }

            return builder.ToString();
        }

        public static string FormatDate(DateTime dateToFormat)
        {
            return dateToFormat.ToString("M/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        }
    }
}
