using System;
using SoftwareAcademy.Contracts;

namespace SoftwareAcademy.Models
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value);
                }

                this.town = value;
            }
        }

        protected override string GetCourseType()
        {
            return this.GetType().Name;
        }

        protected override string GetLabOrTown()
        {
            return string.Format(" Town={0}", this.Town);
        }
    }
}
