namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        public Grass(Point location, int size = 2) 
            : base(location, size)
        {
        }

        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }
        }
    }
}
