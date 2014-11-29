// 05. Define a class BitArray64 to hold 64 bit values inside an ulong value.
//     Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

namespace _5.BitArray64Exercise
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represent an array of 64 bits
    /// </summary>
    public class BitArray64 : IEnumerable<int>
    {
        // Using magic numbers is Evil :) Better set it as constants. This way is easier to manage the code
        private const int arrayLowerBound = 0;
        private const int arrayUpperBound = 63;

        /// <summary>
        /// Only constructor. Initialize all fields(properties)
        /// </summary>
        /// <param name="number">Number, representing array of bits</param>
        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Get and private set for Number
        /// </summary>
        public ulong Number { get; private set; }

        /// <summary>
        /// Override "IEnumerator" to get the enumeration of the 64 bit array
        /// </summary>
        /// <returns>Enumeration of 64 bit array</returns>
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = arrayUpperBound; i >= arrayLowerBound; i--)
            {
                yield return this[i];
            }
        }

        /// <summary>
        /// Call upper method. Needed for the correct implementation of "IEnumerable<int>"
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Overriden to check if two bit arrays are equal
        /// </summary>
        /// <param name="obj">Later is cast to a "BitArray64"</param>
        /// <returns>True or false of two BitArray64 comparison</returns>
        public override bool Equals(object obj)
        {
            BitArray64 bitArr = obj as BitArray64;

            if (obj == null) // We can add another check: this == null, otherwise it throws an exception
            {
                return false;
            }

            return Object.Equals(this.Number, bitArr.Number);
        }

        /// <summary>
        /// Indexator for array of bits
        /// </summary>
        /// <param name="index">Index to check bit</param>
        /// <returns>Bit at given index</returns>
        public int this[int index]
        {
            get
            {
                // If index is not in the correct range, an exception is thrown
                if (index < arrayLowerBound || index > arrayUpperBound)
                {
                    throw new ArgumentOutOfRangeException("index", "Index can't be negative or more than 63!");
                }

                return (int)(this.Number >> index) & 1;
            }
        }

        /// <summary>
        /// Overriden to get hash code of Number
        /// </summary>
        /// <returns>Hash code of Number</returns>
        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        /// <summary>
        /// Overriden to compare the values of bit arrays
        /// </summary>
        /// <param name="bitArray1">First bit array</param>
        /// <param name="bitArray2">Second bit array</param>
        /// <returns>Comparison of two bit arrays</returns>
        public static bool operator ==(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return BitArray64.Equals(bitArray1, bitArray2);
        }

        /// <summary>
        /// Overriden to compare the values of bit arrays
        /// </summary>
        /// <param name="bitArray1">First bit array</param>
        /// <param name="bitArray2">Second bit array</param>
        /// <returns>Comparison of two bit arrays</returns>
        public static bool operator !=(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return !(BitArray64.Equals(bitArray1, bitArray2));
        }

        /// <summary>
        /// Overriden to get correct string of 64 bits
        /// </summary>
        /// <returns>64 bits array as string</returns>
        public override string ToString()
        {
            StringBuilder bits = new StringBuilder();

            for (int i = arrayUpperBound; i >= arrayLowerBound; i--)
            {
                bits.Append(this[i]);
            }

            return bits.ToString();
        }
    }
}
