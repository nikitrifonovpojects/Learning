﻿using System;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class AbstractProduct : IProduct
    {
        private const int minProductNameLenght = 3;
        private const int maxProductNameLenght = 10;
        private const int minBrandNameLenght = 2;
        private const int maxBrandNameLenght = 10;
        private string name;
        private string brand;
        private decimal price;

        public AbstractProduct(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Gender = gender;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < AbstractProduct.minProductNameLenght ||
                   value.Length > AbstractProduct.maxProductNameLenght)
                {
                    throw new ArgumentException(string.Format("Product name must be between {0} and {1} symbols long!",
                                                               AbstractProduct.minProductNameLenght, AbstractProduct.maxProductNameLenght));
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                if (value.Length < AbstractProduct.minBrandNameLenght ||
                   value.Length > AbstractProduct.maxBrandNameLenght)
                {
                    throw new ArgumentException(string.Format("Product brand must be between {0} and {1} symbols long!",
                                                               AbstractProduct.minBrandNameLenght, AbstractProduct.maxBrandNameLenght));
                }
                else
                {
                    this.brand = value;
                }
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
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

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format("  * Price: ${0}", this.Price));
            result.Append(string.Format("  * For gender: {0}", this.Gender));

            return result.ToString();
        }
    }
}
