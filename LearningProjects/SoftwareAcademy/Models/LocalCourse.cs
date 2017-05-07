using System;
using SoftwareAcademy.Contracts;

namespace SoftwareAcademy.Models
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value);
                }

                this.lab = value;
            }
        }

        protected override string GetCourseType()
        {
            return this.GetType().Name;
        }

        protected override string GetLabOrTown()
        {
            return string.Format(" Lab={0}", this.Lab);
        }
    }
}
