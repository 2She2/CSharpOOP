// 03. Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.
//     It should hold error message and a range definition [start … end].

namespace _03.ExceptionExercise
{
    using System;

    /// <summary>
    /// Generic exception
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class InvalidRangeException<T> : ApplicationException // Here we can inherit Exception. Nakov said to use "ApplicationException"
        where T : IComparable<T> // Wee need this, because we must compare the parameters to see if it is in range
    {
        // Needed fiaelds, by requirement
        private T start;
        private T end;

        /// <summary>
        /// Constructor to set all fields, except for inner exception
        /// </summary>
        /// <param name="message">Message of the exception</param>
        /// <param name="start">Range start</param>
        /// <param name="end">Range end</param>
        public InvalidRangeException(string message, T start, T end)
            : base(message) // call base constructor
        {
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// This is optional, because in this exercise we don't need inner exception
        /// Full constructor. Initialize all fields
        /// </summary>
        /// <param name="message">Message of the exception</param>
        /// <param name="start">Range start</param>
        /// <param name="end">Range end</param>
        /// <param name="innerExc">Inner Exception</param>
        public InvalidRangeException(string message, T start, T end, Exception innerExc)
            : base(message, innerExc) // call base constructor
        {
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Get range start. We set only getter.
        /// </summary>
        public T Start
        {
            get { return this.start; }
        }

        /// <summary>
        /// Get range end. We set only getter.
        /// </summary>
        public T End
        {
            get { return this.end; }
        }
    }
}
