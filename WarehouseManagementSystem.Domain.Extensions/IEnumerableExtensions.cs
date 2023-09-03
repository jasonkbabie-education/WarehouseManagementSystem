using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Domain.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Find<T>(this IEnumerable<T> source,  Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate?.Invoke(item) == true)
                {
                    yield return item;
                }
            }
        }
    }
}
