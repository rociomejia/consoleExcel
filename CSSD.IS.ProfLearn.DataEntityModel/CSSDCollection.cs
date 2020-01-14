using System;
using System.Collections.Generic;
using System.Text;

namespace CSSD.IS.ProfLearn.DataEntityModel

{
    [Serializable]
    public class CSSDCollection<T> : IEnumerable<T>
    {
        protected IList<T> _list = new List<T>();

        public T Add(T obj)
        {
            _list.Add(obj);
            return obj;
        }

        public T Add()
        {
            return Add();
        }

        public void Insert(int index, T obj)
        {
            _list.Insert(index, obj);
        }

        public void Remove(T obj)
        {
            _list.Remove(obj);
        }

        public T this[int index]
        {
            get { return (T)_list[index]; }
            set { _list[index] = value; }
        }

        #region IEnumerable<T> Members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion
    }
}
