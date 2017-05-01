using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    class Category : ICategory
    {
        private const int MinCategoryNameLenght = 2;
        private const int MaxCategoryNameLenght = 15;
        private string name;
        private List<IProduct> categoryProducts;

        public Category(string name)
        {
            this.Name = name;
            this.categoryProducts = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < Category.MinCategoryNameLenght || value.Length > Category.MaxCategoryNameLenght)
                {
                    throw new ArgumentException(string.Format("Category name must be between {0} and {1} symbols long!", Category.MinCategoryNameLenght, Category.MaxCategoryNameLenght));
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.categoryProducts.Add(cosmetics);
        }

        public string Print()
        {
            var result = new StringBuilder();
            var sortedCategoryProducts = this.categoryProducts
                                             .OrderBy(x => x.Brand)
                                             .ThenByDescending(x => x.Price)
                                             .ToList();

            result.Append(string.Format("{0} category - {1} {2} in total",
                                             this.Name,
                                             sortedCategoryProducts.Count != 0 ? sortedCategoryProducts.Count.ToString() : "0",
                                             sortedCategoryProducts.Count != 1 ? "products" : "product"));

            if (sortedCategoryProducts.Count > 0)
            {
                result.Append(Environment.NewLine);
            }
            
            for (int i = 0; i < sortedCategoryProducts.Count; i++)
            {
                var currentProduct = sortedCategoryProducts[i].Print();
                if (i != sortedCategoryProducts.Count - 1)
                {
                    result.AppendLine(currentProduct);
                }
                else
                {
                    result.Append(currentProduct);
                }
            }

            return result.ToString();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (ProductExists(this.categoryProducts, cosmetics))
            {
                this.categoryProducts.Remove(cosmetics);
            }
            else
            {
                Console.WriteLine(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
            
        }

        private bool ProductExists(List<IProduct> products, IProduct product)
        {
            foreach (var item in products)
            {
                if (item.Name == product.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
