using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        private string name;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Topics = new List<string>();
            this.Teacher = teacher;
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

        public ITeacher Teacher { get; set; }

        private IList<string> Topics { get; set; }

        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        protected abstract string GetCourseType();

        protected abstract string GetLabOrTown();

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(string.Format("{0}: Name={1}", GetCourseType(), this.Name));
            if (this.Teacher != null)
            {
                builder.Append(string.Format("; Teacher={0}", this.Teacher.Name));
            }

            if (this.Topics.Count > 0)
            {
                builder.Append("; Topics=[");
                builder.Append(string.Join(", ", this.Topics.Select(x => x.ToString())));
                builder.Append("]");
            }

            builder.Append(";" + GetLabOrTown());
            return builder.ToString();
        }
    }
}
