using System;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo : AbstractProduct, IShampoo
    {
        private uint milliliters;
        private decimal price;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) 
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public override decimal Price
        {
            get
            {
                return this.price * this.milliliters;
            }
            protected set
            {
                if (value < 0)

                {
                    throw new ArgumentException("Price cannot be less than 0!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            private set
            {
                if (value < 0)

                {
                    throw new ArgumentException("Quantity cannot be less than 0!");
                }
                else
                {
                    this.milliliters = value;
                }
            }
        }

        public UsageType Usage { get; private set; }

        public override string Print()
        {
            return string.Format(base.Print() + Environment.NewLine + "  * Quantity: {0} ml" + Environment.NewLine + "  * Usage: {1}", this.Milliliters, this.Usage);
        }
    }
}
