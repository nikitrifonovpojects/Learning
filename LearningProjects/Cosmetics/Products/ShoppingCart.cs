using System.Collections.Generic;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class ShoppingCart : IShoppingCart
    {
        private List<IProduct> shoppingList = new List<IProduct>();

        public void AddProduct(IProduct product)
        {
            this.shoppingList.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.shoppingList.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.shoppingList.Remove(product);
        }

        public decimal TotalPrice()
        {
            decimal result = decimal.Zero;
            foreach (var item in this.shoppingList)
            {
                result += item.Price;
            }

            return result;
        }
    }
}
