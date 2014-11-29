// 17. Write a program to return the string with maximum length from an array of strings. Use LINQ.

namespace _17.FindStringWithMaximumLength
{
    using System;
    using System.Linq;

    class FindStringWithMaximumLength
    {
        static void Main()
        {
            // Add some random strings
            string[] stringsToSearch = new string[]
            {
                "Use LINQ.",
                "Write a program to return the string",
                "Write a program",
                "Write a program to return the string with maximum length from an array of strings.",
                "Write a program to return the string with maximum length",
                "Write a program to return the string with maximum length from an array"
            };

            // Using extension methods and Lambda expressions to solve the task
            var maxLength = stringsToSearch.Aggregate((current, max) =>
                {
                    if (current.Length > max.Length) max = current;
                    return max;
                });

            // Print string with max length
            Console.WriteLine(maxLength);
        }
    }
}
