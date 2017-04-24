using System.Collections.Generic;

namespace StructureExcersise
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student()
            {
                Age = 21,
                FirstName = "Georgi",
                LastName = "Petkov",
                Id = 1 
            };
            Student student2 = new Student()
            {
                Age = 22,
                FirstName = "Ivailo",
                LastName = "Velinov",
                Id = 2
            };

            string uniName = "uni";
            University university = new University(uniName);
            university.Students = new List<Student>();
            university.Students.Add(student1);
            student1.University = university;
            university.Students.Add(student2);

            Teacher teacher1 = new Teacher()
            {
                FirstName = "Iliant",
                LastName = "Rifonov",
                Age = 35,
            };

            student1.Supevisor = student2;
            student2.Supevisor = teacher1;

            List<Person> people = new List<Person>();
            people.Add(student1);
            people.Add(student2);
            people.Add(teacher1);

            foreach (var item in people)
            {
                item.SayHi();
            }
        }
    }
}
