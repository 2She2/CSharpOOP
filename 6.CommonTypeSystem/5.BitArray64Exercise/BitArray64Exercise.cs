// 05. Define a class BitArray64 to hold 64 bit values inside an ulong value.
//     Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

namespace _5.BitArray64Exercise
{
    using System;
    using System.Collections.Generic;

    class BitArray64Exercise
    {
        static void Main()
        {
            // Make instance of class "BitArray64"
            BitArray64 array1 = new BitArray64(5);
            BitArray64 array2 = null;
            BitArray64 array3 = new BitArray64(5);

            // Check if "IEnumerable<int>" is properly implemented
            Console.WriteLine("Bits in array, print with the help of IEnumerable<int>");
            foreach (var number in array1)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Check if method "Equals()" is properly implemented
            Console.WriteLine("Is array1 equals array2: {0}", array1.Equals(array2));
            Console.WriteLine("Is array1 equals array3: {0}", array1.Equals(array3));

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Check if operator "==" is properly implemented
            Console.WriteLine("Is array1 equals array2: {0}", array1 == array2);
            Console.WriteLine("Is array1 equals array3: {0}", array1 == array3);

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Check if operator "!=" is properly implemented
            Console.WriteLine("Is array1 don't equals array2: {0}", array1 != array2);
            Console.WriteLine("Is array1 don't equals array2: {0}", array1 != array3);

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Check if indexator is properly implemented
            Console.WriteLine("Bit at position 2: {0}", array1[2]);

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Check if "ToString" is properly implemented
            Console.WriteLine(array1);
            
        }
    }
}
