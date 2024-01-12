using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice08_Pile.Classes
{
    internal class Pile<T>
    {
        private readonly T[] _items;
        private readonly int _size;
        private int _count;

        public int Count { get { return _count; } }

        /// <summary>
        /// Indexer permettant d'utiliser la notation []
        /// </summary>
        /// <param name="i">Index dans la pile</param>
        /// <returns>L'élément situé à l'index spécifié</returns>
        public T this[int i]
        {
            get { return _items[i]; }
            set { _items[i] = value; }
        }

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

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine($"Contenu de la liste de {Count} élément" + (Count > 1 ? "s" : "") + $" de type {typeof(T).Name} :");
            Console.WriteLine();

            if (this.Count == 0)
                Console.WriteLine("\t(liste vide)");
            else
            {
                T[] elements = _items.Where(e => e != null && !e.Equals(default(T))).ToArray<T>();

                foreach (var item in elements)
                    Console.WriteLine("\t > " + item);
            }

            Console.ResetColor();
        }
    }
}
