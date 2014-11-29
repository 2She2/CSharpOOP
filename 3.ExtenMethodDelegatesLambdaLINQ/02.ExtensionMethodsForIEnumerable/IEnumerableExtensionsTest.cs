// 02. Implement a set of extension methods for IEnumerable<T> that implement the following group functions:
//     sum, product, min, max, average.

namespace _02.ExtensionMethodsForIEnumerable
{
    using System;
    using System.Collections.Generic;

    class IEnumerableExtensionsTest
    {
        static void Main()
        {
            // Declare array of int and try if all extension methods works properly
            int[] arrayNumbers = new int[] { 6, 3, 1, 4, 2, 5 };
            int arraySum = arrayNumbers.Sum<int>();
            int arrayProduct = arrayNumbers.Product<int>();
            int arrayMin = arrayNumbers.Min<int>();
            int arrayMax = arrayNumbers.Max<int>();
            int arrayAverage = arrayNumbers.Average<int>();

            // Print the values calculated by the extension methods
            Console.WriteLine("Sum of numbers in array: {0}".PadLeft(35), arraySum);
            Console.WriteLine("Product of numbers in array: {0}".PadLeft(35), arrayProduct);
            Console.WriteLine("Minimal number in array: {0}".PadLeft(35), arrayMin);
            Console.WriteLine("Maximal number in array: {0}".PadLeft(35), arrayMax);
            Console.WriteLine("Average number in array: {0}".PadLeft(35), arrayAverage);

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Declare list of double and try if all extension methods works properly
            List<double> listNumbers = new List<double> { 6.6, 3.3, 1.1, 4.4, 2.2, 5.5 };
            double listSum = listNumbers.Sum<double>();
            double listProduct = listNumbers.Product<double>();
            double listMin = listNumbers.Min<double>();
            double listMax = listNumbers.Max<double>();
            double listAverage = listNumbers.Average<double>();

            // Print the values calculated by the extension methods
            Console.WriteLine("Sum of numbers in list: {0}".PadLeft(35), listSum);
            Console.WriteLine("Product of numbers in list: {0}".PadLeft(35), listProduct);
            Console.WriteLine("Minimal number in list: {0}".PadLeft(35), listMin);
            Console.WriteLine("Maximal number in list: {0}".PadLeft(35), listMax);
            Console.WriteLine("Average number in list: {0}".PadLeft(35), listAverage);
        }
    }
}
