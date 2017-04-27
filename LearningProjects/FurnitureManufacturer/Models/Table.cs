namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class Table : AbstractFurniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            protected set
            {
                if (value == 0.00m || value < 0)
                {
                    throw new ArgumentException("The height is zero or less");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                if (value == 0.00m || value < 0)
                {
                    throw new ArgumentException("The height is zero or less");
                }

                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + ',' + " Length: {0}, Width: {1}, Area: {2}",
                                                     this.Length, this.Width, this.Area);
        }
    }
}
