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

        public static Student[] FirstBeforeLastName(this Student[] arrayOfStudents)
        {
            var result = arrayOfStudents.OrderBy(x => x.FirstName).ThenBy(c => c.LastName).ToArray();

            return result;
        }

        public static Student[] ListStudentsInAgeRange(this Student[] arrayOfStudents, int lowerBoudary, int upperBoundary)
        {
            var result = arrayOfStudents.Where(x => x.Age >= lowerBoudary && x.Age <= upperBoundary).ToArray();

            return result;
        }

        public static Student[] SortStudentsInDescendingOrderWithLambda(this Student[] arrayOfStudents)
        {
            var result = arrayOfStudents.OrderByDescending(x => x.FirstName).ThenByDescending(c => c.LastName).ToArray();

            return result;
        }

        public static IEnumerable<Student> SortStudentsInDescendingOrderWithLinq(this IEnumerable<Student> listOfStudents)
        {
            var result = from student in listOfStudents
                         orderby student.FirstName descending, student.LastName descending
                         select student;

            return result;
        }

        public static IEnumerable<int> ArrayNumbersDevisibleBy7And3Lambda(this IEnumerable<int> numbers)
        {
            var result = numbers.Where(x => x % 7 == 0 && x % 3 == 0).ToArray();

            return result;
        }

        public static IEnumerable<int> ArrayNumbersDevisibleBy7And3Linq(this IEnumerable<int> numbers)
        {
            var result = from number in numbers
                         where number % 7 == 0 && number % 3 == 0
                         select number;

            return result.ToArray();
        }
    }
}
