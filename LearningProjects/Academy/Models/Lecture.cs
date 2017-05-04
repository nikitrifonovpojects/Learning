using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Academy.Models.Common;
using Academy.Models.Contracts;

namespace Academy.Models
{
    public class Lecture : ILecture
    {
        private string name;
        private IList<ILectureResource> resources = new List<ILectureResource>();

        public Lecture(string name, string date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = DateTime.Parse(string.Format("{0} 00:00:00", date));
            this.Trainer = trainer;
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
                if (value.Count() < Constants.MinLectureNameLenght || value.Count() > Constants.MaxLectureNameLenght)
                {
                    throw new ArgumentException(string.Format(Constants.LectureNameLenghtExceptionMessage, Constants.MinLectureNameLenght, Constants.MaxLectureNameLenght));
                }

                this.name = value;
            }
        }

        public DateTime Date { get; set; }

        public ITrainer Trainer { get; set; }
        
        public IList<ILectureResource> Resources
        {
            get
            {
                return this.resources;
            }
        }

        public override string ToString()
        {
            var printLecture = new StringBuilder();
            printLecture.AppendLine("  * Lecture:");
            printLecture.AppendLine(string.Format("   - Name: {0}", this.Name));
            printLecture.AppendLine(string.Format("   - Date: {0}", this.Date.ToString("M/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)));
            printLecture.AppendLine(string.Format("   - Trainer username: {0}", this.Trainer.Username));
            printLecture.AppendLine("   - Resources:");

            if (this.Resources.Count < 1)
            {
                printLecture.Append(Constants.NoResorsesInLectureMessage);
            }
            else
            {
                for (int i = 0; i < this.Resources.Count; i++)
                {
                    if (i != this.Resources.Count - 1)
                    {
                        printLecture.AppendLine(this.Resources[i].ToString());
                    }
                    else
                    {
                        printLecture.Append(this.Resources[i].ToString());
                    }
                }
            }

            return printLecture.ToString();
        }
    }
}
