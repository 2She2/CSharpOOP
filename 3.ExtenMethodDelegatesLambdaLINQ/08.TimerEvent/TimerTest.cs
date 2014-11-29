// 08. * Read in MSDN about the keyword event in C# and how to publish events.
//      Re-implement the above using .NET events and following the best practices.

namespace _08.TimerEvent
{
    using System;
    using System.Threading;

    public class TimerTest
    {
        static void Main()
        {
            Timer timer = new Timer(2, 10);
            // Add delegate to an event
            // Our event show how many seconds are passed
            timer.RaiseTimerEvent += new TimerEventHandler(PastSeconds);

            // Start the timer in separate thread, so the execution of the program can continue
            Thread timerThread = new Thread(new ThreadStart(timer.Run));
            timerThread.Start();

            Console.WriteLine("If timer is not in separate thread, this will be last!");
        }

        // Method to be added to the "TimerEventHandler" delegate
        static void PastSeconds(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Seconds past: {0}", e.Message);
        }
    }
}
