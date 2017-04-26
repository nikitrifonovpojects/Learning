namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class AdjustableChair : Chair, IAdjustableChair
    {
        private decimal chairHeight;

        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.Height = height;
        }

        public override decimal Height
        {
            get
            {
                return this.chairHeight;
            }
            protected set
            {
                if (decimal.Equals(value, 0.00) || value < 0)
                {
                    throw new ArgumentException("The height is zero or less");
                }

                this.chairHeight = value;
            }
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
