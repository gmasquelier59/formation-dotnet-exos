using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice08_Pile.Classes
{
    internal class Pile<T> : IEnumerable<T>
    {
        private readonly T[] _items;
        private readonly int _size;
        private int _count;

        public int Count { get { return _count; } }

        public Pile(int size)
        {
            if (size < 1)
                throw new ArgumentOutOfRangeException("size", "Size must be greater than 0");

            _items = new T[size];
            _count = 0;
            _size = size;
        }

        public void Push(T element)
        {
            if (_count == _size - 1)
                throw new InvalidOperationException("Unable to push : stack is full");

            _count++;
            _items[_count - 1] = element;
        }

        public T Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("Unable to pop: stack is empty");

            T element = _items[_count - 1];
            _items[_count - 1] = default!;
            _count--;
            return element;
        }

        public void Clear()
        {
            for (int i = 0; i < _size; i++)
                _items[i] = default!;
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)(_items.Where(e => e != null && !e.Equals(default(T))).ToArray<T>())).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine($"Contenu de la liste de {Count} élément" + (Count > 1 ? "s" : "") + $" de type {typeof(T).Name} :");
            Console.WriteLine();

            if (this.Count == 0)
                Console.WriteLine("\t(liste vide)");
            else
                foreach (var item in this)
                    Console.WriteLine("\t > " + item);

            Console.ResetColor();
        }
    }
}
