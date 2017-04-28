namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("Company name is null, empty or under 5 symbols");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (!Regex.IsMatch(value, @"^\d+$") || value.Length != 10)
                {
                    throw new ArgumentException("Resigtration number is not exactly 10 digits or is not a number");
                }

                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();
            if (this.Furnitures.Count > 0)
            {
                result.AppendLine(this.ToString());
                var orderedFurnitures = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model).ToList();
                for (int i = 0; i < orderedFurnitures.Count; i++)
                {
                    if (i != orderedFurnitures.Count - 1)
                    {
                        result.AppendLine(orderedFurnitures[i].ToString());
                    }
                    else
                    {
                        result.Append(orderedFurnitures[i].ToString());
                    }
                }

                return result.ToString();
            }
            else
            {
                return this.ToString();
            }
        }

        public override string ToString()
        {
            string result = string.Format("{0} - {1} - {2} {3}",
                                    this.Name,
                                    this.RegistrationNumber,
                                    this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                                    this.Furnitures.Count != 1 ? "furnitures" : "furniture");
            return result;
        }

        public IFurniture Find(string model)
        {
            var firstFound = this.Furnitures.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());
                        
            return firstFound;
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }
    }
}
