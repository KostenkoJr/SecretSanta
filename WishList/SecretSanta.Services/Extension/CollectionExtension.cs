using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.Extension
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Randomly mixing collection
        /// </summary>
        /// <typeparam name="T">Some class</typeparam>
        /// <param name="list">Initial collection</param>
        public static void Mix<T>(this ICollection<T> list) where T : class
        {
            Random r = new Random();
            SortedList<Int64, T> mixedList = new SortedList<long, T>();
            
            foreach (var item in list)
                mixedList.Add(r.Next(), item);

            list.Clear();
            for (int i = 0; i < mixedList.Count; i++)
            {
                list.Add(mixedList.Values[i]);
            }
        }
    }
}
