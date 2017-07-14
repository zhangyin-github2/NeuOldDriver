using System;
using System.Collections.Generic;

namespace NeuOldDriver.Linq {

    public static class LinqExtensions {

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var item in source)
                action(item);
        }

        public static IEnumerable<T> Merge<T>(this IEnumerable<IEnumerable<T>> list) {
            foreach (var elem in list) {
                foreach (var subelem in elem)
                    yield return subelem;
            }
        }

    }
}
