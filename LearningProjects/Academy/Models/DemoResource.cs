using Academy.Models.Enums;

namespace Academy.Models
{
    public class DemoResource : AbstractResource
    {
        private readonly ResourseType type = ResourseType.Demo;
        
        public DemoResource(string name, string url) 
            : base(name, url)
        {
            
        }

        protected override string GetClassType()
        {
            return this.type.ToString();
        }
    }
}
