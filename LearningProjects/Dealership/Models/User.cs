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
        private readonly string noComments = "    --NO COMMENTS--";
        private readonly string comments = "    --COMMENTS--";
        private readonly string onlyDashes = "    ----------";

        private string userName;
        private string firstName;
        private string lastName;
        private string password;

        public User(string userName, string firstName, string lastName, string password, string role)
        {
            this.Username = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Vehicles = new List<IVehicle>();
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
                Validator.ValidateSymbols(value, Constants.UsernamePattern, string.Format(Constants.InvalidSymbols, "Username", Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength, string.Format(Constants.StringMustBeBetweenMinAndMax, "Username", Constants.MinNameLength, Constants.MaxNameLength));
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
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength, string.Format(Constants.StringMustBeBetweenMinAndMax, "Firstname", Constants.MinNameLength, Constants.MaxNameLength));
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
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength, string.Format(Constants.StringMustBeBetweenMinAndMax, "Lastname", Constants.MinNameLength, Constants.MaxNameLength));
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
                Validator.ValidateSymbols(value, Constants.PasswordPattern, string.Format(Constants.InvalidSymbols, "Password", Constants.MinPasswordLength, Constants.MaxPasswordLength));
                Validator.ValidateIntRange(value.Length, Constants.MinPasswordLength, Constants.MaxPasswordLength, string.Format(Constants.StringMustBeBetweenMinAndMax, "Password", Constants.MinPasswordLength, Constants.MaxPasswordLength));
                this.password = value;
            }
        }

        public Role Role { get; private set; }

        public IList<IVehicle> Vehicles { get; private set; }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            Validator.ValidateNull(commentToAdd, Constants.CommentCannotBeNull);
            Validator.ValidateNull(vehicleToAddComment, Constants.VehicleCannotBeNull);
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);
            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }
            else if (this.Vehicles.Count >= 5 && this.Role == Role.Normal)
            {
                throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd, Constants.MaxVehiclesToAdd));
            }
            else
            {
                this.Vehicles.Add(vehicle);
            }
        }

        public string PrintVehicles()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("--USER {0}--", this.userName));
            if (this.Vehicles.Count == 0)
            {
                builder.Append("--NO VEHICLES--");
            }
            else
            {
                int vehicleCount = 0;
                for (int i = 0; i < this.Vehicles.Count; i++)
                {
                    var currentVehicle = this.Vehicles[i];
                    vehicleCount++;
                    builder.AppendLine(string.Format("{0}. {1}:", vehicleCount, currentVehicle.Type));
                    builder.AppendLine(currentVehicle.ToString());
                    if (currentVehicle.Comments.Count == 0)
                    {
                        if (i == this.Vehicles.Count - 1)
                        {
                            builder.Append(this.noComments);
                        }
                        else
                        {
                            builder.AppendLine(this.noComments);
                        }
                    }
                    else
                    {
                        builder.AppendLine(this.comments);
                        builder.AppendLine(this.onlyDashes);
                        builder = AddCommentsToPrint(builder, currentVehicle);
                    }
                }
            }

            return builder.ToString();
        }

        private StringBuilder AddCommentsToPrint(StringBuilder builder, IVehicle currentVehicle)
        {
            for (int f = 0; f < currentVehicle.Comments.Count; f++)
            {
                var currentComment = currentVehicle.Comments[f].ToString();
                if (f != currentVehicle.Comments.Count - 1)
                {
                    builder.AppendLine(currentComment);
                    builder.AppendLine(this.onlyDashes);
                    builder.AppendLine(this.onlyDashes);
                }
                else
                {
                    builder.AppendLine(currentVehicle.Comments[f].ToString());
                }
            }

            builder.AppendLine(this.onlyDashes);
            builder.AppendLine(this.comments);

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
            this.Vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            return string.Format(Constants.UserToString + ", Role: {3}", this.userName, this.firstName, this.lastName, this.Role);
        }
    }
}
