namespace _01.ExtensionMethodSubstring
{
    using System;
    using System.Text;

    public static class SubstringExtension
    {
        /// <summary>
        /// Extension method to get a substring from a StringBuilder
        /// </summary>
        /// <param name="text">Shows that the current method is for StringBuilder</param>
        /// <param name="index">Start index</param>
        /// <param name="length">Length of substring</param>
        /// <returns>Substring with given start index and length</returns>
        public static StringBuilder Substring(this StringBuilder text, int index, int length)
        {
            StringBuilder substring = new StringBuilder(text.ToString(), index, length, length);

            return substring;
        }
    }
}
