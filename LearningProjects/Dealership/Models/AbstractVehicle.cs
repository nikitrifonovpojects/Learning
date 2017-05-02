using System;
using System.Collections.Generic;
using System.Text;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public abstract class AbstractVehicle : IVehicle
    {
        private int wheels;
        private string make;
        private string model;
        private IList<IComment> comments;
        private decimal price;

        public AbstractVehicle(VehicleType type, string make, string model, decimal price, int wheels)
        {
            this.Type = type;
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Wheels = wheels;
            this.comments = new List<IComment>();
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
            private set
            {
                Validator.ValidateIntRange(value, Constants.MinWheels, Constants.MaxWheels, string.Format(Constants.NumberMustBeBetweenMinAndMax, "Wheels", Constants.MinWheels, Constants.MaxWheels));
                this.wheels = value;
            }
        }

        public VehicleType Type { get; private set; }
       
        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength, string.Format(Constants.StringMustBeBetweenMinAndMax, "Make", Constants.MinMakeLength, Constants.MaxMakeLength));
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength, string.Format(Constants.StringMustBeBetweenMinAndMax, "Model", Constants.MinModelLength, Constants.MaxModelLength));
                this.model = value;
            }
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice, string.Format(Constants.NumberMustBeBetweenMinAndMax, "Price", Constants.MinPrice, Constants.MaxPrice));
                this.price = value;
            }
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("  Make: {0}", this.Make));
            builder.AppendLine(string.Format("  Model: {0}", this.Model));
            builder.AppendLine(string.Format("  Wheels: {0}", this.Wheels));
            builder.AppendLine(string.Format("  Price: ${0}", this.Price));

            return builder.ToString();
        }
    }
}
