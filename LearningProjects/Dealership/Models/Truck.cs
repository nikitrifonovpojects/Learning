using System;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Truck : AbstractVehicle, ITruck
    {
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) 
            : base(VehicleType.Truck, make, model, price, (int)VehicleType.Truck)
        {
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            private set
            {
                Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity, string.Format(Constants.NumberMustBeBetweenMinAndMax, "Weight capacity", Constants.MinCapacity, Constants.MaxCapacity));
                this.weightCapacity = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("  Weight Capacity: {0}t", this.WeightCapacity);
        }
    }
}
