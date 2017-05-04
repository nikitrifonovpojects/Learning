using System;
using System.Linq;
using System.Text;
using Academy.Models.Common;
using Academy.Models.Contracts;

namespace Academy.Models
{
    public abstract class AbstractResource : ILectureResource
    {
        private string name;
        private string url;

        public AbstractResource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
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
                if (value.Count() < Constants.MinDemoResourceNameLenght || value.Count() > Constants.MaxDemoResourceNameLenght)
                {
                    throw new ArgumentException(string.Format(Constants.ResourceNameLenghtExceptionMessage, Constants.MinDemoResourceNameLenght, Constants.MaxDemoResourceNameLenght));
                }

                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(string.Format(Constants.NullExceptionMessage, nameof(Url)));
                }
                if (value.Count() < Constants.MinUrlNameLenght || value.Count() > Constants.MaxUrlNameLenght)
                {
                    throw new ArgumentException(string.Format(Constants.ResourceUrlLenghtExceptionMessage, Constants.MinUrlNameLenght, Constants.MaxUrlNameLenght));
                }

                this.url = value;
            }
        }

        protected abstract string GetClassType();

        public override string ToString()
        {
            var demoResourcePrint = new StringBuilder();
            demoResourcePrint.AppendLine("    * Resource:");
            demoResourcePrint.AppendLine(string.Format("     - Name: {0}", this.Name));
            demoResourcePrint.AppendLine(string.Format("     - Url: {0}", this.Url));
            demoResourcePrint.Append(string.Format("     - Type: {0}", this.GetClassType()));

            return demoResourcePrint.ToString();
        }
    }
}
