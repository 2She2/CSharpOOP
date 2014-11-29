// 07. Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace _07.TimerWithDelagates
{
    using System;
    using System.Threading;

    delegate void printTime();

    public class TimerTest
    {
        static void Main()
        {
            // Make instance of class Timer 
            // with 2 seconds to sleep the thread and 10 seconds to run the timer
            Timer timer = new Timer(2, 10);

            // Add method to the delegate of the instance
            timer.currentDelegate = PrintTimeNow;

            // Add second method to the delegate of the instance
            timer.currentDelegate += new TimerTest().PrintDayOfWeek;

            // Start the timer in separate thread, so the execution of the program can continue
            Thread timerThread = new Thread(new ThreadStart(timer.Run));
            timerThread.Start();

            Console.WriteLine("If timer is not in separate thread, this will be last!");
        }

        // Just some methods to add to the delegate and to display something to the console
        public static void PrintTimeNow()
        {
            Console.WriteLine("Current date: {0}", DateTime.Now.ToShortDateString());
        }

        public void PrintDayOfWeek()
        {
            Console.WriteLine("Current day of week: {0}", DateTime.Now.DayOfWeek);
        }
    }
}
