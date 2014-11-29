// 02. Implement a set of extension methods for IEnumerable<T> that implement the following group functions:
//     sum, product, min, max, average.

namespace _02.ExtensionMethodsForIEnumerable
{
    using System;
    using System.Collections;

    public static class IEnumerableExtensions
    {
        // Values to use when searching for minimal and maximal elements
        private const int MinIntValue = int.MinValue;
        private const int MaxIntValue = int.MaxValue;

        /// <summary>
        /// Calculate the sum of elements in collection
        /// </summary>
        /// <typeparam name="T">Type of the elements in the collection</typeparam>
        /// <param name="collection">Collection to sum it's elements</param>
        /// <returns>Sum of the elements</returns>
        public static T Sum<T>(this IEnumerable collection) // Implement the following interfaces, so only numbers can be used
            where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>
        {
            // "dynamic" is allowed to use, because it determinate the type of the used variables during runtime
            // "default(T)" sets the default variable value: 0, 0.0
            dynamic sum = default(T);

            // Iterate through the collection and sum all elements
            foreach (T element in collection)
            {
                sum += element;
            }

            return sum;
        }

        /// <summary>
        /// Calculate the product of elements in collection
        /// </summary>
        /// <typeparam name="T">Type of the elements in the collection</typeparam>
        /// <param name="collection">Collection to multiply it's elements</param>
        /// <returns>Product of the elements</returns>
        public static T Product<T>(this IEnumerable collection) // Implement the following interfaces, so only numbers can be used
            where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>
        {
            // "dynamic" is allowed to use, because it determinate the type of the used variables during runtime
            // Set to 1, because if it is 0 the result will be 0 too
            dynamic product = 1;

            // Iterate through the collection and multiply all elements
            foreach (T element in collection)
            {
                product *= element;
            }

            return product;
        }

        /// <summary>
        /// Find the minimal element in the collection
        /// </summary>
        /// <typeparam name="T">Type of the elements in the collection</typeparam>
        /// <param name="collection">Collection to search for minial element</param>
        /// <returns>Minimal element</returns>
        public static T Min<T>(this IEnumerable collection) // Implement the following interfaces, so only numbers can be used
            where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>
        {
            // "dynamic" is allowed to use, because it determinate the type of the used variables during runtime
            // Set dynamic to intiger max value. If elements values are grether than intiger max value, the program will not work properly
            dynamic minimalValue = MaxIntValue;

            // Iterate through the collection and check for minimal value
            foreach (T element in collection)
            {
                if (element < minimalValue)
                {
                    minimalValue = element;
                }
            }

            return minimalValue;
        }

        /// <summary>
        /// Find the maximal element in the collection
        /// </summary>
        /// <typeparam name="T">Type of the elements in the collection</typeparam>
        /// <param name="collection">Collection to search for maximal element</param>
        /// <returns>Maximal element</returns>
        public static T Max<T>(this IEnumerable collection) // Implement the following interfaces, so only numbers can be used
            where T: struct, IComparable, IFormattable, IConvertible, IComparable<T>
        {
            // "dynamic" is allowed to use, because it determinate the type of the used variables during runtime
            // Set dynamic to intiger min value. If elements values are lower than intiger min value, the program will not work properly
            dynamic maximalValue = MinIntValue;

            // Iterate through the collection and check for maximal value
            foreach (T element in collection)
            {
                if (element > maximalValue)
                {
                    maximalValue = element;
                }
            }

            return maximalValue;
        }

        /// <summary>
        /// Calculate the average number of elements in collection
        /// </summary>
        /// <typeparam name="T">Type of the elements in the collection</typeparam>
        /// <param name="collection">Collection to calculat average number</param>
        /// <returns>Average number</returns>
        public static T Average<T>(this IEnumerable collection) // Implement the following interfaces, so only numbers can be used
            where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>
        {
            // "dynamic" is allowed to use, because it determinate the type of the used variables during runtime
            // "default(T)" sets the default variable value: 0, 0.0
            dynamic average = default(T);
            dynamic elementsCout = 0;

            // Iterate through the collection and sum all values
            foreach (T element in collection)
            {
                average += element;
                elementsCout++;
            }

            // Divide the sum of all elements to their count to find the average number
            average /= elementsCout;
            return average;
        }
    }
}
