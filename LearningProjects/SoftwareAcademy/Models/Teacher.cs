using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftwareAcademy.Contracts;

namespace SoftwareAcademy.Models
{
    public class Teacher : ITeacher
    {
        private string name;

        public Teacher(string name)
        {
            this.Name = name;
            this.Courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value);
                }

                this.name = value;
            }
        }

        public IList<ICourse> Courses { get; private set; }

        public void AddCourse(ICourse course)
        {
            this.Courses.Add(course);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(string.Format("Teacher: Name={0}", this.Name));

            if (this.Courses.Count > 0)
            {
                builder.Append("; Courses=[");
                builder.Append(string.Join(", ", this.Courses.Select(x => x.Name)));
                builder.Append("]");
            }

            return builder.ToString();
        }
    }
}
