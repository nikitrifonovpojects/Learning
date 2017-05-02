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
                try
                {
                    Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity, Constants.NumberMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Weight capacity", Constants.MinCapacity, Constants.MaxCapacity));
                }
                
                this.weightCapacity = value;
            }
        }
    }
}
