using System;
using Academy.Models.Enums;
using Academy.Models.Utils;

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
            return string.Format(base.ToString() + Environment.NewLine + "     - Uploaded on: {0}", Utility.FormatDate(this.UploadedOn));
        }
    }
}
