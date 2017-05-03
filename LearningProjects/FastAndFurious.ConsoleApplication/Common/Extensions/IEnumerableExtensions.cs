using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Models.ModelContracts;

namespace FastAndFurious.ConsoleApplication.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T GetById<T>(this IEnumerable<T> collection, int id) where T : IIdentifiable
        {
            return collection.FirstOrDefault(x => x.Id == id);
        }
    }
}
