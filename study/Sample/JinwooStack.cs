namespace ConsoleAppSample.Study.Sample
{
    class JinwooStack<T>
    {
        Entry _top;

        public void push(T data)
        {
            _top = new Entry(_top, data);
        }

        public T pop()
        {
            if (_top == null)
            {
                throw new InvalidOperationException();
            }

            T result = _top._data;
            _top = _top._next;
            return result;
        }

        class Entry
        {
            public Entry _next { get; set; }

            public T _data { get; set; }

            public Entry(Entry next, T data)
            {
                _next = next;
                _data = data;
            }
        }
    }
}