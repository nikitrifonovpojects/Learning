namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        public Zombie(string name, Point location, int size = 0) 
            : base(name, location, size)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            this.IsAlive = true;
            return 10;
        }
    }
}
