using System.Collections.Generic;

namespace Map {

    public class Map<T1, T2> {
        private Dictionary<T1, T2> _forward = new Dictionary<T1, T2>();
        private Dictionary<T2, T1> _reverse = new Dictionary<T2, T1>();

        public Map() {
            this.Forward = new Indexer<T1, T2>(_forward);
            this.Reverse = new Indexer<T2, T1>(_reverse);
        }

        public class Indexer<T3, T4> {
            private Dictionary<T3, T4> _dictionary;
            public Indexer(Dictionary<T3, T4> dictionary) {
                _dictionary = dictionary;
            }
            public T4 this[T3 index] {
                get { return _dictionary[index]; }
                set { _dictionary[index] = value; }
            }
        }

        public void Add(T1 t1, T2 t2) {
            _forward.Add(t1, t2);
            _reverse.Add(t2, t1);
        }

        public void Remove(T1 t1) {
            T2 t2;
            _forward.TryGetValue(t1, out t2);
            _forward.Remove(t1);
            _reverse.Remove(t2);
        }

        public void Remove(T2 t2) {
            T1 t1;
            _reverse.TryGetValue(t2, out t1);
            _reverse.Remove(t2);
            _forward.Remove(t1);
        }

        public void Clear() {
            _forward.Clear();
            _reverse.Clear();
        }

        public T2[] GetValues() {
            T2[] values = new T2[_forward.Count];
            _forward.Values.CopyTo(values, 0);
            return values;
        }

        public T1[] GetKeys() {
            T1[] keys = new T1[_forward.Count];
            _forward.Keys.CopyTo(keys, 0);
            return keys;
        }

        public Indexer<T1, T2> Forward { get; private set; }
        public Indexer<T2, T1> Reverse { get; private set; }
    }
}