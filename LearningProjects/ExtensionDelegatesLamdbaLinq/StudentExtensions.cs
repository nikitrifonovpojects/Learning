using System.Collections.Generic;
using System.Linq;

namespace ExtensionDelegatesLamdbaLinq
{
    public static class StudentExtensions
    {
        public static IEnumerable<IGrouping<int, T>> StudentsByGroups<T>(IEnumerable<T> students) where T : Student
        {
            var result = students
                .OrderBy(x => x.GroupNumber)
                .GroupBy(x => x.GroupNumber);

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

        public static IEnumerable<T> FindStudentsByEmail<T>(this IEnumerable<T> students, string domain) where T : Student
        {
            var result = students
                         .Where(x => x.Email.Split('@').Last() == domain)
                         .ToArray();

            return result;
        }

        public static IEnumerable<T> ListStudentsByFirstName<T>(this IEnumerable<T> students) where T : Student
        {
            var result = from student in students
                         orderby student.FirstName
                         select student;

            return result.ToList();
        }

        public static IEnumerable<T> ListStudentsByGroupNumber<T>(this IEnumerable<T> students, int groupNumber) where T : Student
        {
            var result = from student in students
                         where student.GroupNumber == groupNumber
                         select student;

            return result.ToList();
        }
    }
}
