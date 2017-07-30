using System;
using System.Collections.Generic;

namespace NeuOldDriver.Utils {

    public class CircularEnumerator<T> {

        private readonly IList<T> elems;
        private int i; // enumerating index

        public CircularEnumerator(params T[] param) {
            elems = new List<T>(param);
            i = 0;
        }

        public CircularEnumerator(IEnumerable<T> list) {
            elems = new List<T>(list);
            i = 0;
        }

        /// <summary>
        /// index of current element
        /// </summary>
        public int Index {
            get { return i; }
        }

        /// <summary>
        /// return current element, and forward to next
        /// </summary>
        /// <returns></returns>
        public T Next() {
            if (elems.Count == 0)
                return default(T);
            var ret = elems[i];
            if (++i == elems.Count)
                i = 0;
            return ret;
        }
    }
}
