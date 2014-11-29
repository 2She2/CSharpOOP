// 06. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
//     Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

namespace _06.NumbersDivisibleBy7And3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class NumbersDivisibleBy7And3
    {
        static void Main()
        {
            int[] intArray = new int[] { 3, 7, 14, 21, 35, 42, 48, 51 };

            // Find numbers with built-in extension methods and lambda expressions
            var divisibleNumbersLambda = intArray.Where(x => x % 7 == 0 && x % 3 == 0); // we can use 21 instead of 7 and 3

            // Print numbers
            Console.WriteLine("Using built-in extension methods and lambda expressions");
            Console.WriteLine("Numbers divisible by 7 and 3:");
            foreach (var item in divisibleNumbersLambda)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Find numbers with LINQ Query
            var divisibleNumbersQuery =
                from number in intArray
                where number % 7 == 0 && number % 3 == 0  // we can use 21 instead of 7 and 3
                select number;

            // Print numbers
            Console.WriteLine("Using LINQ Query");
            Console.WriteLine("Numbers divisible by 7 and 3:");
            foreach (var number in divisibleNumbersQuery)
            {
                Console.WriteLine(number);
            }
        }
    }
}
