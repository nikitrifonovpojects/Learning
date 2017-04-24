using System.Collections.Generic;

namespace StructureExcersise
{
    public class Student : Person
    {
        public int Id { get; set; }

        public University University { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Subdject> Subjects { get; set; }

        public Person Supevisor { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
