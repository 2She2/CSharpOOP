// 12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
//     Create an instance of the GSM class.
//     Add few calls.
//     Display the information about the calls.
//     Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
//     Remove the longest call from the history and calculate the total price again.
//     Finally clear the call history and print it.

namespace GSMCallHistoryTes
{
    using GSMTest;
    using System;

    class GSMCallHistoryTes
    {
        static void Main()
        {
            // Declare gsm
            GSM apple = new GSM("iPhone5s", "Apple");

            // Directly add call, using inner initializer
            apple.AddCall(new Call(DateTime.Now, "0888 887766", 56));
            apple.AddCall(new Call(new DateTime(2014, 1, 5, 13, 43, 16), "0877 997755", 93));

            // Declare variable of type "Call" and add it to call history of gsm
            Call appleCall = new Call(new DateTime(2014, 1, 4, 16, 10, 37), "+359 888 112233", 347);
            apple.AddCall(appleCall);

            // Assign the array with all calls, returned by the propertie "CallHistory"
            Call[] appleCalls = apple.CallHistory;

            // Print all calls
            for (int i = 0; i < appleCalls.Length; i++)
            {
                Console.WriteLine(appleCalls[i]);
            }

            // Print current total price of all calls.
            // Method "ClalcTotalCallsPrice" take one parameter - price per minute
            Console.WriteLine("Total price: {0}", apple.ClalcTotalCallsPrice(0.37M));

            // Delete longets duration call and print again the total cost of all calls
            apple.DeleteLongestCall();
            Console.WriteLine("Total price after remove of longets call: {0}", apple.ClalcTotalCallsPrice(0.37M));

            // Clear entire call history
            apple.ClearCallHistory();
            // Once again get the call history, to see that it is empty
            appleCalls = apple.CallHistory;

            for (int i = 0; i < appleCalls.Length; i++)
            {
                Console.WriteLine(appleCalls[i]);
            }
        }
    }
}
