namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        public Rock(Point position, int hitPoints, int owner = 0) 
            : base(position, owner)
        {
            this.HitPoints = hitPoints;
        }

        public int Quantity
        {
            get
            {
                return this.HitPoints / 2;
            }
        }

        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }
    }
}
