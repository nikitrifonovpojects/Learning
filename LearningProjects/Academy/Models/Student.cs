using System;
using System.Collections.Generic;
using System.Text;
using Academy.Models.Common;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils;
using Academy.Models.Utils.Contracts;

namespace Academy.Models
{
    public class Student : IStudent
    {
        private string userName;

        public Student(string username, string track)
        {
            this.Username = username;
            Track result;
            if (Enum.TryParse<Track>(track, true, out result))
            {
                this.Track = result;
            }
            else
            {
                throw new ArgumentException(Constants.InvalidTrackExceptionMessage);
            }

            this.CourseResults = new List<ICourseResult>();
        }

        public Track Track { get; set; }

        public IList<ICourseResult> CourseResults { get; set; }

        public string Username
        {
            get
            {
                return this.userName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(string.Format(Constants.NullExceptionMessage, nameof(Username)));
                }

                if (value.Length < Constants.MinTrainerAndStudentNameLenght || value.Length > Constants.MaxTrainerAndStudentNameLenght)
                {
                    throw new ArgumentException(string.Format(Constants.TrainerAndStudentNameLenghtExceptionMessage, Constants.MinTrainerAndStudentNameLenght, Constants.MaxTrainerAndStudentNameLenght));
                }

                this.userName = value;
            }
        }

        public override string ToString()
        {
            var printStudent = new StringBuilder();
            printStudent.AppendLine("* Student:");
            printStudent.AppendLine(string.Format(" - Username: {0}", this.Username));
            printStudent.AppendLine(string.Format(" - Track: {0}", this.Track));
            printStudent.AppendLine(" - Course results:");

            if (this.CourseResults.Count < 1)
            {
                printStudent.Append(Constants.StudentHasNoCourseResultsMessage);
            }
            else
            {
                printStudent.Append(Utility.ListItemsInCollection(this.CourseResults));
            }

            return printStudent.ToString();
        }
    }
}
