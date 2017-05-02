using System;
using System.Collections.Generic;
using System.Text;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string userName;
        private string firstName;
        private string lastName;
        private string password;
        private IList<IVehicle> vehicles;
        private Role role;

        public User(string userName, string firstName, string lastName, string password, string role)
        {
            this.Username = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.vehicles = new List<IVehicle>();
            this.Role = (Role)Enum.Parse(typeof(Role), role);
        }

        public string Username
        {
            get
            {
                return this.userName;
            }
            private set
            {
                try
                {
                    Validator.ValidateSymbols(value, Constants.UsernamePattern, Constants.InvalidSymbols);
                    Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength, Constants.StringMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Username", Constants.MinNameLength, Constants.MaxNameLength));
                }
                
                this.userName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                try
                {
                    Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength, Constants.StringMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Firstname", Constants.MinNameLength, Constants.MaxNameLength));
                }
                
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                try
                {
                    Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength, Constants.StringMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Lastname", Constants.MinNameLength, Constants.MaxNameLength));
                }
                
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                try
                {
                    Validator.ValidateSymbols(value, Constants.PasswordPattern, Constants.InvalidSymbols);
                    Validator.ValidateIntRange(value.Length, Constants.MinPasswordLength, Constants.MaxPasswordLength, Constants.StringMustBeBetweenMinAndMax);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException(string.Format(exception.Message, "Password", Constants.MinPasswordLength, Constants.MaxPasswordLength));
                }
                
                this.password = value;
            }
        }

        public Role Role { get; private set; }

        public IList<IVehicle> Vehicles { get; private set; }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            try
            {
                Validator.ValidateNull(vehicleToAddComment, Constants.CommentCannotBeNull);
            }
            catch (ArgumentNullException exception)
            {
                throw new ArgumentNullException(exception.Message);
            }

            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);
            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }
            else if (this.vehicles.Count >= 5 && this.Role == Role.Normal)
            {
                throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd.ToString(), Constants.MaxVehiclesToAdd));
            }
            else
            {
                this.vehicles.Add(vehicle);
            }
        }

        public string PrintVehicles()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("--USER {0}--", this.userName));
            if (this.vehicles.Count == 0)
            {
                builder.Append("--NO VEHICLES--");
            }
            else
            {
                builder = ListUserVehicles(builder);
            }

            return builder.ToString();
        }

        private StringBuilder ListUserVehicles(StringBuilder builder)
        {
            int vehicleCount = 0;
            for (int i = 0; i < this.vehicles.Count; i++)
            {
                var currentVehicle = this.vehicles[i];
                vehicleCount++;
                builder.AppendLine(string.Format("{0}. {1}:", vehicleCount, currentVehicle.GetType().Name));
                builder.AppendLine(string.Format("  Make: {0}", currentVehicle.Make));
                builder.AppendLine(string.Format("  Model: {0}", currentVehicle.Model));
                builder.AppendLine(string.Format("  Wheels: {0}", currentVehicle.Wheels));
                builder.AppendLine(string.Format("  Price: ${0}", currentVehicle.Price));

                switch (currentVehicle.GetType().Name)
                {
                    case "Motorcycle":
                        var Motorcycle = currentVehicle as Motorcycle;
                        builder.AppendLine(string.Format("  Category: {0}", Motorcycle.Category));
                        break;
                    case "Car":
                        var car = currentVehicle as Car;
                        builder.AppendLine(string.Format("  Seats: {0}", car.Seats));
                        break;
                    case "Truck":
                        var truck = currentVehicle as Truck;
                        builder.AppendLine(string.Format("  Weight Capacity: {0}t", truck.WeightCapacity));
                        break;
                    default:
                        throw new ArgumentException(string.Format("{0} is not a valid type", currentVehicle.GetType().Name));
                }

                builder = AddComments(builder, i, currentVehicle);
            }

            return builder;
        }

        private StringBuilder AddComments(StringBuilder builder, int i, IVehicle currentVehicle)
        {
            if (currentVehicle.Comments.Count == 0)
            {
                if (i == this.vehicles.Count - 1)
                {
                    builder.Append("    --NO COMMENTS--");
                }
                else
                {
                    builder.AppendLine("    --NO COMMENTS--");
                }
            }
            else
            {
                builder.AppendLine("    --COMMENTS--");
                builder.AppendLine("    ----------");
                for (int f = 0; f < currentVehicle.Comments.Count; f++)
                {
                    var currentComment = currentVehicle.Comments[f].ToString();
                    if (f != currentVehicle.Comments.Count - 1)
                    {
                        builder.AppendLine(currentComment);
                        builder.AppendLine("    ----------");
                        builder.AppendLine("    ----------");
                    }
                    else
                    {
                        builder.AppendLine(currentVehicle.Comments[f].ToString());
                    }
                }

                builder.AppendLine("    ----------");
                builder.AppendLine("    --COMMENTS--");
            }

            return builder;
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            Validator.ValidateNull(commentToRemove, Constants.CommentCannotBeNull);
            Validator.ValidateNull(vehicleToRemoveComment, Constants.VehicleCannotBeNull);
            if (commentToRemove.Author == this.Username)
            {
                vehicleToRemoveComment.Comments.Remove(commentToRemove);
            }
            else
            {
                throw new ArgumentException(Constants.YouAreNotTheAuthor);
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);
            this.vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            return string.Format(Constants.UserToString + ", Role: {3}", this.userName, this.firstName, this.lastName, this.role);
        }
    }
}
