using System;
using System.Globalization;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class VideoResource : AbstractResource
    {
        private readonly ResourseType type = ResourseType.Video;

        public VideoResource(string name, string url, DateTime currentDate) 
            : base(name, url)
        {
            this.UploadedOn = currentDate;
        }

        public DateTime UploadedOn { get; set; }

        protected override string GetClassType()
        {
            return this.type.ToString();
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + Environment.NewLine + "     - Uploaded on: {0}", this.UploadedOn.ToString("M/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));
        }
    }
}
