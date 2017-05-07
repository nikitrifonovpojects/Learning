namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        public Wolf(string name, Point location, int size = 4) 
            : base(name, location, size)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
                else if (animal.State == AnimalState.Sleeping)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
