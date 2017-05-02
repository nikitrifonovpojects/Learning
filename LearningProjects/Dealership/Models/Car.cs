using System;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Car : AbstractVehicle, ICar
    {
        private int seats;

        public Car(string make, string model, decimal price, int seats) 
            : base(VehicleType.Car, make, model, price, (int)VehicleType.Car)
        {
            this.Seats = seats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            private set
            {
                try
                {
                    Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats, Constants.NumberMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Seats", Constants.MinSeats, Constants.MaxSeats));
                }
                
                this.seats = value;
            }
        }
    }
}
