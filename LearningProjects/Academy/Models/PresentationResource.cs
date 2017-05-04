using Academy.Models.Enums;

namespace Academy.Models
{
    public class PresentationResource : AbstractResource
    {
        private readonly ResourseType type = ResourseType.Presentation;

        public PresentationResource(string name, string url) 
            : base(name, url)
        {
        }

        protected override string GetClassType()
        {
            return this.type.ToString();
        }
    }
}
