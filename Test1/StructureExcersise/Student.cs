using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
