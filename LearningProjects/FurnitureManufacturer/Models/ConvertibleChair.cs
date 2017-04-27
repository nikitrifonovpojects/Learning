namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private decimal chairHeight;
        private decimal originalHeight;
        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
        }

        public override decimal Height
        {
            get
            {
                return this.chairHeight;
            }
            protected set
            {
                if ( value == 0 || value < 0)
                {
                    throw new ArgumentException("The height is zero or less");
                }

                this.chairHeight = value;
            }
        }

        public bool IsConverted { get; set; }
        
        public void Convert()
        {
            if (this.IsConverted)
            {
                this.Height = originalHeight;
                
                this.IsConverted = false;
            }
            else
            {
                this.originalHeight = this.Height;
                this.Height = 0.10m;
                this.IsConverted = true;
            }
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + ',' + " State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
