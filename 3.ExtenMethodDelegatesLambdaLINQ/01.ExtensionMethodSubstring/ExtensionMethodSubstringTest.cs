// 01. Implement an extension method Substring(int index, int length) for the class StringBuilder
//     that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace _01.ExtensionMethodSubstring
{
    using System;
    using System.Text;

    class ExtensionMethodSubstringTest
    {
        static void Main()
        {
            // Initialize two variables to test the extension method "Substring"
            StringBuilder fullName = new StringBuilder("Pesho Peshev Peshov");
            StringBuilder middleName = new StringBuilder();

            // Using extension method "Substring" to get the middle name
            middleName = fullName.Substring(6, 6);
            Console.WriteLine("Middle name: \"{0}\"", middleName);
        }
    }
}
