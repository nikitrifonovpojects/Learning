using System;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Motorcycle : AbstractVehicle, IMotorcycle
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, string category) 
            : base(VehicleType.Motorcycle, make, model, price, (int)VehicleType.Motorcycle)
        {
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength, string.Format(Constants.StringMustBeBetweenMinAndMax, "Category", Constants.MinCategoryLength, Constants.MaxCategoryLength));
                this.category = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("  Category: {0}", this.Category);
        }
    }
}
