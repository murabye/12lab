using System;
using System.Collections.Generic;
using System.Collections;
using Verification;

namespace _3task
{

    public class MyEnum<TObj> : IEnumerator
    {
        public TObj[] _Objs;
        private int position = -1;

        public MyEnum(TObj[] list)
        {
            _Objs = list;
        }
        public bool MoveNext()
        {
            position++;
            return (position < _Objs.Length);
        }
        public void Reset()
        {
            position = -1;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public TObj Current
        {
            get
            {
                try
                {
                    return _Objs[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }


    public class MyStack<TObj> : IEnumerable
    {
        int capacity;
        int count;          // field properties



        // interface
        private TObj[] _objs;
        public MyStack(TObj[] oArray)
        {
            _objs = new TObj[oArray.Length];

            for (int i = 0; i < oArray.Length; i++)
            {
                _objs[i] = oArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public MyEnum<TObj> GetEnumerator()
        {
            return new MyEnum(_objs);
        }
        
    }

    
    
}
