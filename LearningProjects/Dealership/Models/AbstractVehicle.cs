using System;
using System.Collections.Generic;
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
                try
                {
                    Validator.ValidateIntRange(value, Constants.MinWheels, Constants.MaxWheels, Constants.NumberMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Wheels", Constants.MinWheels, Constants.MaxWheels));
                }
                
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
                try
                {
                    Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength, Constants.StringMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Make", Constants.MinMakeLength, Constants.MaxMakeLength));
                }
                
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
                try
                {
                    Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength, Constants.StringMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Model", Constants.MinModelLength, Constants.MaxModelLength));
                }

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
                try
                {
                    Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice, Constants.NumberMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Price", Constants.MinPrice, Constants.MaxPrice));
                }
                
                this.price = value;
            }
        }
    }
}
