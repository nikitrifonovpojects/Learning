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

        public static decimal MySum<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var result = collection
                .Select(x => Convert.ToDecimal(x))
                .Sum();

            return result;
        }

        public static decimal MyProduct<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var convertedCollection = collection
                .Select(x => Convert.ToDecimal(x));

            decimal result = 1;
            foreach (var number in convertedCollection)
            {
                result *= number;
            }

            return result;
        }

        public static decimal MyMin<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var convertedCollection = collection
                .Select(x => Convert.ToDecimal(x));

            var result = convertedCollection.FirstOrDefault();
            foreach (var number in convertedCollection)
            {
                if (number < result)
                {
                    result = number;
                }
            }

            return result;
        }

        public static decimal MyMax<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var convertedCollection = collection
                .Select(x => Convert.ToDecimal(x));

            var result = convertedCollection.FirstOrDefault();
            foreach (var number in convertedCollection)
            {
                if (number > result)
                {
                    result = number;
                }
            }

            return result;
        }

        public static decimal MyAverage<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            return collection.MySum() / collection.Count();
        }

        public static T[] FirstBeforeLastName<T>(this T[] arrayOfStudents) where T : Student
        {
            var result = arrayOfStudents.OrderBy(x => x.FirstName).ThenBy(c => c.LastName).ToArray();

            return result;
        }

        public static T[] ListStudentsInAgeRange<T>(this T[] arrayOfStudents, int lowerBoudary, int upperBoundary) where T : Student
        {
            var result = arrayOfStudents.Where(x => x.Age >= lowerBoudary && x.Age <= upperBoundary).ToArray();

            return result;
        }

        public static T[] SortStudentsInDescendingOrderWithLambda<T>(this T[] arrayOfStudents) where T : Student
        {
            var result = arrayOfStudents.OrderByDescending(x => x.FirstName).ThenByDescending(c => c.LastName).ToArray();

            return result;
        }

        public static IEnumerable<T> SortStudentsInDescendingOrderWithLinq<T>(this IEnumerable<T> listOfStudents) where T : Student
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

        public static IEnumerable<T> ListStudentsByGroupNumber<T>(this IEnumerable<T> students, int groupNumber) where T : Student
        {
            var result = from student in students
                                      where student.GroupNumber == groupNumber
                                      select student;

            return result.ToList();
        }

        public static IEnumerable<T> ListStudentsByFirstName<T>(this IEnumerable<T> students) where T : Student
        {
            var result = from student in students
                         orderby student.FirstName
                         select student;

            return result.ToList();
        }

        public static IEnumerable<T> FindStudentsByEmail<T>(this IEnumerable<T> students, string domain) where T : Student
        {
            var result = students
                         .Where(x => x.Email.Split('@').Last() == domain)
                         .ToArray();

            return result;
        }

        public static IEnumerable<T> FindStudentsByPhone<T>(this IEnumerable<T> students, string expectedGroupContain) where T : Student
        {
            var result = students
                .Where(x => x.Tel.Split(' ')
                                .FirstOrDefault() == expectedGroupContain)
                .ToArray();
            return result;
        }
    }
}
