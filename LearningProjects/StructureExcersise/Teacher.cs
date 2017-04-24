using System;
using System.Collections.Generic;

namespace StructureExcersise
{
    public class Teacher : Person
    {
        public List<University> Universities { get; set; }

        public Subdject Subject { get; set; }


        public override void SayHi()
        {
            Console.WriteLine("Hi i'm a teacher.");
        }
    }
}
