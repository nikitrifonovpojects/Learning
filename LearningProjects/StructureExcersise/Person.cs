using System;

namespace StructureExcersise
{
    public abstract class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public virtual void SayHi()
        {
            Console.WriteLine("Hi i'm a person.");
        }
    }
}
