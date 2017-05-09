using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionDelegatesLamdbaLinq
{
    //1. Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.
    //2. Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
    //3.Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
    //4.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
    //5.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ.
    //6.Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
    //7.Using delegates write a class Timer that can execute certain method at each t seconds.

    public class Program
    {
        static void Main()
        {
            var student = new Student("Gosho", "Goshov", 13);
            var student1 = new Student("Pepi", "Toshov", 28);
            var student2 = new Student("Tosho", "Peshov", 19);
            var student3 = new Student("Aleks", "Ivanov", 23);
            Student[] listOfStudents = new Student[] { student, student1, student2, student3 };

            Student[] fistBeforeLast = listOfStudents.FirstBeforeLastName();
            Console.WriteLine("Task 3:");
            for (int i = 0; i < fistBeforeLast.Length; i++)
            {
                Console.WriteLine(fistBeforeLast[i].ToString());
            }

            Student[] ageRange = listOfStudents.ListStudentsInAgeRange(18, 24);
            Console.WriteLine("Task 4:");

            for (int i = 0; i < ageRange.Length; i++)
            {
                Console.WriteLine(ageRange[i].ToString());
            }

            Student[] orderDexcendingLambda = listOfStudents.SortStudentsInDescendingOrderWithLambda();
            Console.WriteLine("Task 5: With Lambda");

            for (int i = 0; i < orderDexcendingLambda.Length; i++)
            {
                Console.WriteLine(orderDexcendingLambda[i].ToString());
            }

            var orderDexcendingLinq = listOfStudents.SortStudentsInDescendingOrderWithLinq();
            Console.WriteLine("Task 5: With Linq");

            foreach (var item in orderDexcendingLinq)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Task 6: With Lambda");
            int[] numbers = new int[] { 3, 7, 28, 44, 77, 700, 335, 9, 70 };
            numbers.ArrayNumbersDevisibleBy7And3Lambda();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i].ToString());
            }

            Console.WriteLine("Task 6: With Linq");
            numbers.ArrayNumbersDevisibleBy7And3Linq();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i].ToString());
            }
        }
    }
}
