// Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime>
// by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].

namespace _03.ExceptionExercise
{
    using System;
    using System.Globalization;

    class ExceptionExercise
    {
        static void Main()
        {
            // Male variables of type int, to use in the example
            int startRange = 1;
            int endRange = 100;
            int input = 110; // Intentionaly put invalide number, so we can see the exception

            Console.WriteLine("First exception:");

            // Make date validation as required
            try
            {
                if (input < startRange || input > endRange)
                {
                    // Set the type(generic) to be "int". We are using our constructor for the exception
                    throw new InvalidRangeException<int>("Number you entered is too big or too small!", startRange, endRange);
                }
            }
            catch (InvalidRangeException<int> ire)
            {
                // Print the message from the exception, start and end number. After that print the stack trace
                Console.WriteLine("{0}, range start: {1}, range end: {2}", ire.Message, ire.Start, ire.End);
                Console.WriteLine(ire.StackTrace);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Make variables of type DateTime, to use in the example
            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31);
            DateTime date = new DateTime(2014, 5, 19); // Intentionaly put invalide date, so we can see the exception

            Console.WriteLine("Second exception:");

            // Make date validation as required
            try
            {
                if (date < startDate || date > endDate)
                {
                    // Set the type(generic) to be "DateTime" We are using our constructor for the exception
                    throw new InvalidRangeException<DateTime>("Date you etered is either too further in time or too back in the past!",
                        startDate, endDate);
                }
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                // Print the message from the exception, start and end date. After that print the stack trace
                Console.WriteLine("{0}, range start date: {1}, range end date: {2}", ire.Message, startDate.ToShortDateString(), endDate.ToShortDateString());
                Console.WriteLine(ire.StackTrace);
            }
        }
    }
}
