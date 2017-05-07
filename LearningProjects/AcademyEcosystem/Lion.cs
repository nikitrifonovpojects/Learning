namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        public Lion(string name, Point location, int size = 6) 
            : base(name, location, size)
        {
        }
        
        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size * 2)
                {
                    this.Size += 1;
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
