namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private decimal originalHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this.originalHeight = height;
        }

        public bool IsConverted { get; set; }
        
        public void Convert()
        {
            if (this.IsConverted)
            {
                this.Height = originalHeight;
            }
            else
            {
                this.Height = 0.10m;
            }

            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + ',' + " State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
