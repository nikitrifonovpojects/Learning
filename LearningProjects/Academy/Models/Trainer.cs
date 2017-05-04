using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Models.Common;
using Academy.Models.Contracts;

namespace Academy.Models
{
    public class Trainer : ITrainer
    {
        private IList<string> technologies = new List<string>();
        private string userName;

        public Trainer(string username, string technologies)
        {
            this.Username = username;
            this.Technologies = technologies.ToString().Split(',');
        }

        public IList<string> Technologies
        {
            get
            {
                return this.technologies;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format(Constants.NullExceptionMessage, nameof(Technologies)));
                }

                this.technologies = value;
            }
        }

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
                if (value.Count() < Constants.MinTrainerAndStudentNameLenght || value.Count() > Constants.MaxTrainerAndStudentNameLenght)
                {
                    throw new ArgumentException(string.Format(Constants.TrainerAndStudentNameLenghtExceptionMessage, Constants.MinTrainerAndStudentNameLenght, Constants.MaxTrainerAndStudentNameLenght));
                }

                this.userName = value;
            }
        }

        public override string ToString()
        {
            var trainerPrint = new StringBuilder();
            trainerPrint.AppendLine("* Trainer:");
            trainerPrint.AppendLine(string.Format(" - Username: {0}", this.Username));
            trainerPrint.Append(" - Technologies: ");

            for (int i = 0; i < this.Technologies.Count; i++)
            {
                if (i != this.Technologies.Count - 1)
                {
                    trainerPrint.Append(this.Technologies[i] + ';' + ' ');
                }
                else
                {
                    trainerPrint.Append(this.Technologies[i]);
                }
            }

            return trainerPrint.ToString();
        }
    }
}
