// 06. Implement auto-grow functionality: when the internal array is full,
//     create a new array of double size and move all elements to it.

// 07. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>.
//     You may need to add a generic constraints for the type T.

namespace Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Generic class that keeps a list of elements of some parametric type T. Auto-grow functionality is implemented.
    /// </summary>
    /// <typeparam name="T">Parameters type</typeparam>
    public class GenericListWithAutoGrow<T>
        where T : IComparable<T>  // T must implement interface "IComparable", so we can compare the elements
    {
        private T[] list;
        private int capacity;
        private int count = 0;

        /// <summary>
        /// Initialize array with given length
        /// </summary>
        /// <param name="capacity"></param>
        public GenericListWithAutoGrow(int capacity)
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
        /// Get count of the elements in the list
        /// </summary>
        public int Count
        {
            get { return this.count; }
            // set is private, because we don't want anyone else to edit this value
            private set { this.count = value; }
        }

        /// <summary>
        /// Get capacity of the list
        /// </summary>
        public int Capacity
        {
            get { return this.capacity; }
        }

        /// <summary>
        /// Add elements in the list
        /// </summary>
        /// <param name="element">Element to add</param>
        public void Add(T element)
        {
            // Double the size of the array, if elements count is reached the capacity
            AutoGrow();

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
        public void Remove(int index)
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
            // Check if index is in bounds, if not, exception is thrown
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("int index", "Index is out of bounds!");
            }

            // Double the size of the array, if elements count is reached the capacity
            AutoGrow();

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
        /// Double the size of the array
        /// </summary>
        private void AutoGrow()
        {
            // Check if elements count is reached the capacity
            if (this.Count == this.capacity)
            {
                // Check for overflow
                checked
                {
                    // Bitwise multiply by 2
                    capacity = (capacity << 1);
                }

                // Make new array and copy all elements to it.
                // Then set the reference of the current array to point to the new one and set old array to "null"
                T[] newList = new T[capacity];
                list.CopyTo(newList, 0);
                //list = null;
                list = newList;
                newList = null;
            }
        }

        /// <summary>
        /// Find the minimal element
        /// </summary>
        /// <typeparam name="T">Type of the elements</typeparam>
        /// <returns>The minimal element index</returns>
        public int Min<T>() // Here 'T' probably must be switch with 'K' or some other letter
        {
            int currentMinIndex = 0;

            // Iterate through the array and compare the elements
            // If current element is smaller, take its index
            for (int i = 0; i < this.Count - 1; i++)
            {
                int isGreather = this.list[i].CompareTo(this.list[currentMinIndex]);

                if (isGreather < 0)
                {
                    currentMinIndex = i;
                }
            }

            return currentMinIndex;
        }

        /// <summary>
        /// Find the maximal element
        /// </summary>
        /// <typeparam name="T">Type of the elements</typeparam>
        /// <returns>The maximal element index</returns>
        public int Max<T>() // Here 'T' probably must be switch with 'K' or some other letter
        {
            int currentMaxIndex = 0;

            // Iterate through the array and compare the elements
            // If current element is bigger, take its index
            for (int i = 1; i < this.Count; i++)
            {
                int isGreather = this.list[i].CompareTo(this.list[currentMaxIndex]);

                if (isGreather > 0)
                {
                    currentMaxIndex = i;
                }
            }

            return currentMaxIndex;
        }

        /// <summary>
        /// Check if given index is in range of the list. If no, exception is thrown.
        /// </summary>
        /// <param name="index">Index to be checked</param>
        private void CheckIndexRange(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("int index", "Index is out of bounds!");
            }
        }
    }
}
