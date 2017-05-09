using System.Collections.Generic;

namespace ExtensionDelegatesLamdbaLinq
{
    public class Student
    {
        public Student(string firstName, string lastName, int age, int fn, string tel, string email, int groupNumber, List<int> marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.Marks = marks;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int FN { get; private set; }

        public string Tel { get; private set; }

        public List<int> Marks { get; private set; }

        public string Email { get; private set; }

        public int GroupNumber { get; set; }

        public int Age { get; private set; }

        public override string ToString()
        {
            return string.Format("First Name: {0}, Last Name: {1}, Age: {2}, Group Number: {3}, Email: {4}, Phone: {5}", this.FirstName, this.LastName, this.Age, this.GroupNumber, this.Email, this.Tel);
        }
    }
}
