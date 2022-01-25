using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingDayDal
{
    public static class ListExtensionMethods
    {
        /// <summary>
        /// Adds an element to the list, if the list not already contains it.
        /// </summary>
        /// <typeparam name="T">Type of the Element to be added.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="element">The element to be added.</param>
        public static void AddIfNew<T>(this List<T> list, T element)
        {
            
            if (!list.Contains(element))
            {
                list.Add(element);
            }
        }
    }
}
