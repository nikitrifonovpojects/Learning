using System;
using System.Globalization;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class HomeworkResource : AbstractResource
    {
        private readonly ResourseType type = ResourseType.Homework;

        public HomeworkResource(string name, string url, DateTime currentDate) 
            : base(name, url)
        {
            this.DueDate = currentDate.AddDays(7);
        }

        public DateTime DueDate { get; set; }

        protected override string GetClassType()
        {
            return this.type.ToString();
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + Environment.NewLine + "     - Due date: {0}", this.DueDate.ToString("M/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));
        }
    }
}
