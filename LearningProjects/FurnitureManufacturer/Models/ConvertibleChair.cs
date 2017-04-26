namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private decimal chairHeight;
        private bool isConverted = false;
        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = isConverted;
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

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.Height -= 0.10m;
            }
            else
            {
                this.Height += 0.10m;
                this.IsConverted = true;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal");
        }
    }
}
