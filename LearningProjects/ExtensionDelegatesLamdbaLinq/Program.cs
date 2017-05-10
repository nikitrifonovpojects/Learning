using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionDelegatesLamdbaLinq
{
    //1. Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.
    //2. Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
    //3.Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
    //4.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
    //5.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ.
    //6.Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
    //7.Using delegates write a class Timer that can execute certain method at each t seconds.
    //9.Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.Create a List<Student> with sample students. Select only the students that are from group number 2.Use LINQ query. Order the students by FirstName.
    //10.Implement the previous using the same query expressed with extension methods.
    //11.Extract all students that have email in abv.bg. Use string methods and LINQ
    //12.xtract all students with phones in Sofia. Use LINQ.
    //13.Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.
    //14.Write down a similar program that extracts the students with exactly two marks "2".
    //15.Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
    //16.Create a class Group with properties GroupNumber and DepartmentName. Introduce a property GroupNumber in the Student class. Extract all students from "Mathematics" department.Use the Join operator.
    //17.Write a program to return the string with maximum length from an array of strings.

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Task 1:");
            var builder = new StringBuilder();
            builder.Append("This is a string for homework.");
            StringBuilder substing = builder.Substring(10, 6);
            Console.WriteLine(substing);
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 2:");
            var listOfnumbersForTask2 = new []{ 2, 3, 4, 5, 6, 10, 45 };
            var sum = listOfnumbersForTask2.MySum();
            var product = listOfnumbersForTask2.MyProduct();
            var min = listOfnumbersForTask2.MyMin();
            var max = listOfnumbersForTask2.MyMax();
            var average = listOfnumbersForTask2.MyAverage();

            Console.WriteLine("Sum = {0}, Product = {1}, Min = {2}, Max = {3}, Average = {4}", sum, product, min, max, average);
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            List<Student> studentsForTask9 = CreateStudentsList();
            Student[] listOfStudents = CreateStudentsArray();
            Student[] fistBeforeLast = listOfStudents.FirstBeforeLastName();

            Console.WriteLine("Task 3:");
            for (int i = 0; i < fistBeforeLast.Length; i++)
            {
                Console.WriteLine(fistBeforeLast[i].ToString());
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Student[] ageRange = listOfStudents.ListStudentsInAgeRange(18, 24);
            Console.WriteLine("Task 4:");

            for (int i = 0; i < ageRange.Length; i++)
            {
                Console.WriteLine(ageRange[i].ToString());
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Student[] orderDexcendingLambda = listOfStudents.SortStudentsInDescendingOrderWithLambda();
            Console.WriteLine("Task 5: With Lambda");

            for (int i = 0; i < orderDexcendingLambda.Length; i++)
            {
                Console.WriteLine(orderDexcendingLambda[i].ToString());
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            var orderDexcendingLinq = listOfStudents.SortStudentsInDescendingOrderWithLinq();
            Console.WriteLine("Task 5: With Linq");

            foreach (var item in orderDexcendingLinq)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 6: With Lambda");
            int[] numbers = new int[] { 3, 7, 28, 44, 77, 700, 335, 9, 70 };
            numbers.ArrayNumbersDevisibleBy7And3Lambda();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(string.Format("{0}, ", numbers[i].ToString()));
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 6: With Linq");
            numbers.ArrayNumbersDevisibleBy7And3Linq();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(string.Format("{0}, ", numbers[i].ToString()));
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 7:");
            //Timer timer = new Timer(1);
            //timer.InvokeDelegate();

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 9:");

            var result = from studentTask9 in studentsForTask9
                         where studentTask9.GroupNumber == 2
                         orderby studentTask9.FirstName
                         select studentTask9;

            foreach (var studentForTask9 in result)
            {
                Console.WriteLine(studentForTask9);
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 10:");
            var orderedByFirstName = studentsForTask9.ListStudentsByFirstName();
            var orderedByGroup = studentsForTask9.ListStudentsByGroupNumber(2);

            Console.WriteLine("Students by Name:");

            foreach (var item in orderedByFirstName)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Students by Group:");

            foreach (var item in orderedByGroup)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 11:");
            var studentsByMail = studentsForTask9.FindStudentsByEmail("abv.bg");

            foreach (var item in studentsByMail)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 12:");
            Console.WriteLine("Students with phones starting with 02 are from Sofia!");

            var studentsByCity = studentsForTask9.FindStudentsByPhone("02");

            foreach (var item in studentsByCity)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 13:");

            var anonymousArray = new[]
            {
                new {FullName = "Pesho Ivanov", Marks=new List<int> { 6, 5, 2, 6, 2, 4 }},
                new {FullName = "George Petkov", Marks=new List<int> {3, 5, 3, 6, 5, 4 }},
                new {FullName = "Ivan Georgiev", Marks=new List<int> { 3, 5, 5, 6, 3, 4 }},
                new {FullName = "Stefan Varbanov", Marks=new List<int> { 2, 5, 2, 6, 2, 4 }},
                new {FullName = "Stefan Kostov", Marks=new List<int> { 3, 5, 2, 3, 2, 4 }},
                new {FullName = "Nikolay Yankov", Marks=new List<int> { 3, 5, 2, 6, 4, 4 }},
                new {FullName = "Dimityr Blagoev", Marks=new List<int> { 4, 5, 2, 6, 2, 4 }},
                new {FullName = "Hristo Gospodinov", Marks=new List<int> { 5, 5, 6, 6, 3, 4  }},
                new {FullName = "Petar Hristov", Marks=new List<int> { 4, 5, 2, 6, 4, 4 }},
                new {FullName = "Atanas Atanasov", Marks=new List<int> { 2, 5, 2, 3, 2, 4 }}
            };

            Console.WriteLine("Students with atleast 1 mark = 6");
                
            foreach (var item in anonymousArray.Where(x => x.Marks.Contains(6)))
            {
                Console.WriteLine($"{item.FullName} marks: {string.Join(" ", item.Marks)}");
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 14:");
            Console.WriteLine("Students with exact 2 marks = 2");

            foreach (var item in anonymousArray.Where(x => x.Marks.Where(m => m == 2).Count() == 2))
            {
                Console.WriteLine($"{item.FullName} marks: {string.Join(" ", item.Marks)}");
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 15:");

            var studentsFrom2006 = studentsForTask9.Where(x => x.FN.ToString()[4] == '0' && x.FN.ToString()[5] == '6');

            foreach (var item in studentsFrom2006)
            {
                Console.WriteLine(string.Join(" ", item.Marks));
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 16:");
            var math = new Group(2, "Mathematics");
            var lang = new Group(1, "Language");
            var foreign = new Group(3, "Foreign Languages");

            var groupedStudents = studentsForTask9.ListStudentsByGroupNumber(2);

            foreach (var item in groupedStudents)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine("Task 17:");

            var strings = GetStrings();
            var longestString = strings
                .OrderByDescending(x => x.Length)
                .FirstOrDefault();
            Console.WriteLine(longestString);
        }

        private static Student[] CreateStudentsArray()
        {
            var allStudents = new Student[7];
            allStudents[0] = new Student("Gosho", "Goshov", 13, 123406, "02 937 2211", "abv@gmail.bg", 2, new List<int> { 6, 5, 2, 6, 2, 4 });
            allStudents[1] = new Student("Pepi", "Toshov", 28, 669933, "02 937 2212", "aaa@abv.bg", 1, new List<int> { 3, 5, 3, 6, 5, 4 });
            allStudents[2] = new Student("Tosho", "Peshov", 19, 888777, "02 937 2213", "bbb@yahoo.bg", 2, new List<int> { 3, 5, 5, 6, 3, 4 });
            allStudents[3] = new Student("Aleks", "Ivanov", 23, 654306, "032 656 700", "ccc@abv.bg", 1, new List<int> { 2, 5, 2, 6, 2, 4 });
            allStudents[4] = new Student("Eli", "Pavlova", 20, 554477, "032 656 703", "ddd@gmail.bg", 1, new List<int> { 4, 5, 2, 6, 2, 4 });
            allStudents[5] = new Student("Gloria", "Tran", 26, 712506, "052 937 211", "eee@abv.bg", 2, new List<int> { 5, 5, 6, 6, 3, 4 });
            allStudents[6] = new Student("Krasi", "Shishov", 18, 489364, "042 937 211", "ggg@yahoo.bg", 1, new List<int> { 2, 5, 2, 3, 2, 4 });

            return allStudents;
        }

        private static List<Student> CreateStudentsList()
        {
            var allStudents = new List<Student>();
            allStudents.Add(new Student("Gosho", "Goshov", 13, 123406, "02 937 2211", "abv@gmail.bg", 2, new List<int> { 6, 5, 2, 6, 2, 4 }));
            allStudents.Add(new Student("Pepi", "Toshov", 28, 669933, "02 937 2212", "aaa@abv.bg", 1, new List<int> { 3, 5, 3, 6, 5, 4 }));
            allStudents.Add(new Student("Tosho", "Peshov", 19, 888777, "02 937 2213", "bbb@yahoo.bg", 2, new List<int> { 3, 5, 5, 6, 3, 4 }));
            allStudents.Add(new Student("Aleks", "Ivanov", 23, 654306, "032 656 700", "ccc@abv.bg", 1, new List<int> { 2, 5, 2, 6, 2, 4 }));
            allStudents.Add(new Student("Eli", "Pavlova", 20, 554477, "032 656 703", "ddd@gmail.bg", 1, new List<int> { 4, 5, 2, 6, 2, 4 }));
            allStudents.Add(new Student("Gloria", "Tran", 26, 712506, "052 937 211", "eee@abv.bg", 2, new List<int> { 5, 5, 6, 6, 3, 4 }));
            allStudents.Add(new Student("Krasi", "Shishov", 18, 489364, "042 937 211", "ggg@yahoo.bg", 1, new List<int> { 2, 5, 2, 3, 2, 4 }));

            return allStudents;
        }

        private static Group[] GroupsGenerator()
        {
            var result = new Group[5];
            result[0] = new Group(1, "Programming");
            result[1] = new Group(2, "Mathematics");
            result[2] = new Group(3, "Physics");
            result[3] = new Group(4, "Philosophy");
            result[4] = new Group(5, "Biology");

            return result;
        }

        private static string[] GetStrings()
        {
            string[] strings = new string[]
            {
               "Create a class Group with properties GroupNumber and DepartmentName.",
               "Create a program that extracts all students grouped by GroupNumber and then prints them to the console.",
               "sorts query results in ascending or descending order",
               "Lambda functions can be stored in variables of type",
               "Teachers, we salute you! Celebrate National Teacher Day with a look at some inspirational quotes from our favorite on-screen educators.",
               "BFI, Creative Scotland among backers of UK movie now in production"

            };

            return strings;
        }
    }
}
