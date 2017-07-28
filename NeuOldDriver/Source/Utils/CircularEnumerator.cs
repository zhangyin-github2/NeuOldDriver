using System;
using System.Collections.Generic;

namespace NeuOldDriver.Utils {

    public class CircularEnumerator<T> : IDisposable {

        private IList<T> elems;
        private IEnumerator<T> i;

        public CircularEnumerator(params T[] param) {
            elems = new List<T>(param);
            i = elems.GetEnumerator();
        }

        public CircularEnumerator(IEnumerable<T> list) {
            elems = new List<T>(list);
            i = elems.GetEnumerator();
        }

        public void Dispose() {
            i.Dispose();
        }

        public T Next() {
            if (elems.Count == 0)
                return default(T);
            if (!i.MoveNext()) {
                i.Reset();
                i.MoveNext();
            }
            return i.Current;
        }
    }
}
