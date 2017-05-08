using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionDelegatesLamdbaLinq
{
    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder builder, int index, int lenght)
        {
            var result = new StringBuilder();
            var substring = builder.ToString().Substring(index, lenght);
            result.Append(substring);

            return result;
        }

        public static IEnumerable<T> Sum<T>(this IEnumerable<T> input)
        {
            var result = (from x in input select x).Sum<T>();
            

            return result;
        }

        public static IEnumerable<T> Product<T>(this IEnumerable<T> input)
        {
            var result = (from x in input select x).Product<T>();


            return result;
        }

        public static IEnumerable<T> Min<T>(this IEnumerable<T> input)
        {
            var result = (from x in input select x).Min<T>();


            return result;
        }

        public static IEnumerable<T> Max<T>(this IEnumerable<T> input)
        {
            var result = (from x in input select x).Max<T>();


            return result;
        }

        public static IEnumerable<T> Average<T>(this IEnumerable<T> input)
        {
            var result = (from x in input select x).Average<T>();


            return result;
        }

        //public static Array FirstBeforeLastName( students)
        //{
        //    var result = (from student in students select student).
                         
                         
        //}
    }
}
