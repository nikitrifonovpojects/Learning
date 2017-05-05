using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Academy.Models.Common;
using Academy.Models.Contracts;
using Academy.Models.Utils;

namespace Academy.Models
{
    public class Lecture : ILecture
    {
        private string name;

        public Lecture(string name, string date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = DateTime.Parse(string.Format("{0} 00:00:00", date));
            this.Trainer = trainer;
            this.Resources = new List<ILectureResource>();
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

                if (value.Length < Constants.MinLectureNameLenght || value.Length > Constants.MaxLectureNameLenght)
                {
                    throw new ArgumentException(string.Format(Constants.LectureNameLenghtExceptionMessage, Constants.MinLectureNameLenght, Constants.MaxLectureNameLenght));
                }

                this.name = value;
            }
        }

        public DateTime Date { get; set; }

        public ITrainer Trainer { get; set; }
        
        public IList<ILectureResource> Resources { get; }

        public override string ToString()
        {
            var printLecture = new StringBuilder();
            printLecture.AppendLine("  * Lecture:");
            printLecture.AppendLine(string.Format("   - Name: {0}", this.Name));
            printLecture.AppendLine(string.Format("   - Date: {0}", Utility.FormatDate(this.Date)));
            printLecture.AppendLine(string.Format("   - Trainer username: {0}", this.Trainer.Username));
            printLecture.AppendLine("   - Resources:");

            if (this.Resources.Count < 1)
            {
                printLecture.Append(Constants.NoResorsesInLectureMessage);
            }
            else
            {
                printLecture.Append(Utility.ListItemsInCollection(this.Resources));
            }

            return printLecture.ToString();
        }
    }
}
