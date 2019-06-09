using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    interface IDynamicArr<T>
    {
        void Add(T item);
        void Remove(T item);
        void RemoveAt(int index);
        void Clear();
        bool Contains(T item);
        int IndexOf(T item);
        T[] ToArray();
        void AddRange(T[] array);
    }

    public class ListEnumerator<T> : IEnumerator<T>
    {
        private int i = -1;
        private List<T> list;

        public ListEnumerator(List<T> list)
        {
            this.list = list;
        }

        public T Current => list[i];

        object IEnumerator.Current => Current;

        public void Dispose()
        { }

        public bool MoveNext()
        {
            i++;
            return i < list.Count;
        }

        public void Reset()
        {
            i = -1;
        }
    }


    public class List<T> : IDynamicArr<T>, IEnumerable<T>
    {
        private T[] inner;

        private int сount;
        public int Count
        {
            get
            {
                return сount;
            }
            private set
            {
                if (value > 0)
                {
                    сount = value;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                return inner[index];
            }
            set
            {
                inner[index] = value;
            }
        }

        public void Add(T item)
        {
            if (inner == null)
            {
                inner = new T[] { item };
            }
            else
            {
                T[] newinner = new T[inner.Length + 1];

                int i = 0;
                while (i != (newinner.Length - 1))
                {
                    newinner[i] = inner[i];
                    i++;
                }

                newinner[newinner.Length - 1] = item;

                inner = newinner;
            }
            Count++;
        }

        public void Remove(T item)
        {
            if (IndexOf(item) != -1)
            {
                RemoveAt(IndexOf(item));
            }
        }

        public void RemoveAt(int index)
        {
            T[] newinner = new T[inner.Length - 1];

            int i = 0;
            while (i != index)
            {
                newinner[i] = inner[i];
                i++;
            }

            i = index;
            while (i < newinner.Length)
            {
                newinner[i] = inner[i + 1];
                i++;
            }

            inner = newinner;

            Count--;
        }

        public int IndexOf(T item)
        {
            int index = -1;

            for (int j = 0; j < inner.Length; j++)
            {
                if (inner[j].Equals(item))
                {
                    index = j;
                    j = inner.Length;
                }
            }

            return index;
        }

        public void Clear()
        {
            T[] newinner = new T[0];

            inner = newinner;
        }

        public bool Contains(T item)
        {
            bool result = false;

            for (int i = 0; i < inner.Length; i++)
            {
                if (inner[i].Equals(item))
                {
                    result = true;
                }
            }

            return result;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = inner[i];
            }

            return result;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(T[] array)
        {
            if(this.Count == 0)
            {
                inner = array;
            }
            else
            {
                T[] newinner = new T[inner.Length + array.Length];

                for (int i = 0; i < inner.Length; i++)
                {
                    newinner[i] = inner[i];
                }

                for (int i = inner.Length; i < array.Length; i++)
                {
                    newinner[i] = array[i];
                }

                inner = newinner;
            }
            Count += array.Length;
        }
    }
}