namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public abstract class AbstractFurniture : IFurniture
    {
        protected string model;
        protected decimal price;
        protected decimal height;

        protected AbstractFurniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public virtual string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Model name is null, empty or under 3 symbols");
                }

                this.model = value;
            }
        }

        public virtual string Material { get; protected set; }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (decimal.Equals(value, 0.00) || value < 0)
                {
                    throw new ArgumentException("The price is zero or less");
                }

                this.price = value;
            }
        }

        public virtual decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if(decimal.Equals(value, 0.00) || value < 0)
                {
                    throw new ArgumentException("The height is zero or less");
                }

                this.height = value;
            }
        }
    }
}
