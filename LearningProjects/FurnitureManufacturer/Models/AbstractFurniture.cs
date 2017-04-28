namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public abstract class AbstractFurniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        protected AbstractFurniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
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

        public string Material { get; protected set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price is zero or less");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("The height is zero or less");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                                     this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
