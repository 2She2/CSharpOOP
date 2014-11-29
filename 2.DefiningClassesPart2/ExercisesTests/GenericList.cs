// 05. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
//     Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
//     Implement methods for adding element, accessing element by index, removing element by index,
//     inserting element at given position, clearing the list, finding element by its value and ToString().
//     Check all input parameters to avoid accessing elements at invalid positions.

namespace Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Generic class that keeps a list of elements of some parametric type T.
    /// </summary>
    /// <typeparam name="T">Parameters type</typeparam>
    public class GenericList<T>
    {
        private T[] list;
        private readonly int capacity;
        private int count = 0;

        /// <summary>
        /// Initialize array with given length
        /// </summary>
        /// <param name="capacity">Capacity of the list</param>
        public GenericList(int capacity)
        {
            // Validate the input number
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greather than 0!");
            }

            this.capacity = capacity;
            list = new T[capacity];
        }

        /// <summary>
        /// Get capacity of the list
        /// </summary>
        public int Capacity
        {
            get { return this.capacity; }
        }

        /// <summary>
        /// Get count of the elements in the list
        /// </summary>
        public int Count
        {
            get { return this.count; }
            // set is private, because we don't want anyone else to edit this value
            private set { this.count = value; }
        }

        /// <summary>
        /// Add elements in the list
        /// </summary>
        /// <param name="element">Element to add</param>
        public void Add(T element)
        {
            // Use method to check if the capacity is reached, if it is, exception is thrown
            // Not sure, that separate method throw the exception, is good indea, probably not!
            CheckCapacityLimit();

            this.list[Count] = element;
            // Each time element is added we increment the count of the elements
            Count++;
        }

        /// <summary>
        /// Indexator to access the elements in the list
        /// </summary>
        /// <param name="index">Index to be accessed</param>
        /// <returns>Element at "index"</returns>
        public T this[int index]
        {
            get
            {
                // Use method to check if given index is in range, if not exception is thrown
                // Not sure, that separate method throw the exception, is good indea, probably not!
                CheckIndexRange(index);
                return list[index];
            }
            set
            {
                CheckIndexRange(index);
                this.list[index] = value;
            }
        }

        /// <summary>
        /// Remove element at given index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            // Use method to check if given index is in range, if not exception is thrown
            // Not sure, that separate method throw the exception, is good indea, probably not!
            CheckIndexRange(index);

            // Iterate through the list, from the given index, to move all elements after it one place back
            for (int i = index; i < this.Count; i++)
            {
                list[i] = list[i + 1];
            }

            list[this.Count - 1] = default(T);
            // Each time element is removed we decrement the count of the elements
            Count--;
        }

        /// <summary>
        /// Insert element at given index
        /// </summary>
        /// <param name="index">Index to insert the element</param>
        /// <param name="element">Element to instert</param>
        public void Insert(int index, T element)
        {
            // Use method to check if the capacity is reached, if it is, exception is thrown
            CheckCapacityLimit();

            // Check if index is in bounds, if not, exception is thrown
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of bounds!");
            }

            // Iterate through the list and move all elements from "index", one place forward
            for (int i = this.Count; i > index - 1; i--)
            {
                this.list[i] = this.list[i - 1];
            }

            this.list[index] = element;
            // Each time element is added we increment the count of the elements
            Count++;
        }

        /// <summary>
        /// Clear all elements in the list. Set elements to their default value.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                list[i] = default(T);
            }

            this.Count = 0;
        }

        /// <summary>
        /// Check if given element exist
        /// </summary>
        /// <param name="element">Element to check for</param>
        /// <returns>Index if the found element or -1 if it is not found</returns>
        public int Find(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.list[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Convert all ellemetns in the array to a string. Each element is on a new line.
        /// </summary>
        /// <returns>Return string with all elements</returns>
        public override string ToString()
        {
            StringBuilder listItems = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                listItems.AppendFormat("{0}", list[i]);

                if (i < this.Count - 1)
                {
                    listItems.Append('\n');
                }
            }

            return listItems.ToString();
        }

        /// <summary>
        /// Check if given index is in range of the list. If no, exception is thrown.
        /// </summary>
        /// <param name="index">Index to be checked</param>
        private void CheckIndexRange(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of bounds!");
            }
        }

        /// <summary>
        /// Check if capacity is reached. If so, exception is thrown
        /// </summary>
        private void CheckCapacityLimit()
        {
            if (this.Count >= this.capacity)
            {
                throw new InvalidOperationException("Capacity limit reached!");
            }
        }
    }
}
