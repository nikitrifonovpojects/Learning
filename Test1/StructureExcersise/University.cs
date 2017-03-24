using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureExcersise
{
    public class University
    {
        private int age;

        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }

        public string Name { get; private set; }


        public University(string name) : this(name, 5)
        {
            
        }

        public University(string name, int age)
        {
            this.Name = name;
            this.age = age;
        }
    }
}
