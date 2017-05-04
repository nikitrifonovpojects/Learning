using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Academy.Models.Common;
using Academy.Models.Contracts;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;
        private IList<IStudent> onsiteStudents;
        private IList<IStudent> onlineStudents;
        private IList<ILecture> lectures;

        public Course(string name, string lecturesPerWeek, string startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = int.Parse(lecturesPerWeek);
            this.StartingDate = DateTime.Parse(string.Format("{0} 00:00:00", startingDate));
            this.EndingDate = this.StartingDate.AddDays(30);
            this.onsiteStudents = new List<IStudent>();
            this.onlineStudents = new List<IStudent>();
            this.lectures = new List<ILecture>();
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
                    throw new ArgumentNullException(string.Format(Constants.NullExceptionMessage, nameof(Name)));
                }
                if (value.Count() < Constants.MinUserNameLenght || value.Count() > Constants.MaxUserNameLenght)
                {
                    throw new ArgumentException(string.Format(Constants.CourseNameLenghtExceptionMessage, Constants.MinUserNameLenght, Constants.MaxUserNameLenght));
                }

                this.name = value;
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }
            set
            {
                if (value < Constants.MinCourseLecturesPerWeek || value > Constants.MaxCourseLecturesPerWeek)
                {
                    throw new ArgumentException(string.Format(Constants.CourseLecturesPerWeekExceptionMessage, Constants.MinCourseLecturesPerWeek, Constants.MaxCourseLecturesPerWeek));
                }

                this.lecturesPerWeek = value;
            }
        }

        public DateTime StartingDate { get; set; }
        
        public DateTime EndingDate { get; set; }

        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;
            }
        }

        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;
            }
        }

        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;
            }
        }

        public override string ToString()
        {
            var printCourse = new StringBuilder();
            printCourse.AppendLine("* Course:");
            printCourse.AppendLine(string.Format(" - Name: {0}", this.Name));
            printCourse.AppendLine(string.Format(" - Lectures per week: {0}", this.LecturesPerWeek));
            printCourse.AppendLine(string.Format(" - Starting date: {0}", this.StartingDate.ToString("M/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)));
            printCourse.AppendLine(string.Format(" - Ending date: {0}", this.EndingDate.ToString("M/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)));
            printCourse.AppendLine(string.Format(" - Onsite students: {0}", this.OnsiteStudents.Count));
            printCourse.AppendLine(string.Format(" - Online students: {0}", this.OnlineStudents.Count));
            printCourse.AppendLine(" - Lectures:");

            if (this.Lectures.Count < 1)
            {
                printCourse.Append(Constants.PrintNoLecturesInTheCourseMessage);
            }
            else
            {
                for (int i = 0; i < this.Lectures.Count; i++)
                {
                    if (i != this.Lectures.Count - 1)
                    {
                        printCourse.AppendLine(this.Lectures[i].ToString());
                    }
                    else
                    {
                        printCourse.Append(this.Lectures[i].ToString());
                    }
                }
            }

            return printCourse.ToString();
        }
    }
}
