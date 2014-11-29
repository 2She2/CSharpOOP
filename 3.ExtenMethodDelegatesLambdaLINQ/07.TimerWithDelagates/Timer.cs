// 07. Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace _07.TimerWithDelagates
{
    using System;
    using System.Threading;

    public class Timer
    {
        // Declare a delegate and make instance of it, so anyone can access it and set it method
        public delegate void DelegateToPerform();
        public DelegateToPerform currentDelegate;

        public int SleepSeconds { get; set; }
        public int TotalSeconds { get; set; }
        
        /// <summary>
        /// Only constructor of class Timer
        /// </summary>
        /// <param name="sleepSeconds">Seconds for thread to sleep</param>
        /// <param name="totalSeconds">Total seconds to run the timer</param>
        public Timer(int sleepSeconds, int totalSeconds)
        {
            // Multiply by 1000 so we can get the seconds
            this.SleepSeconds = sleepSeconds * 1000;
            this.TotalSeconds = totalSeconds * 1000;
        }

        /// <summary>
        /// Start timer and perform methods set to the delegate
        /// </summary>
        public void Run()
        {
            int time = 0;
            int currentCall = 1;

            while (time < this.TotalSeconds)
            {
                // On each iteration display the current call of the delegate
                Console.WriteLine("Call {0}", currentCall);

                // Make the thread sleep for given seconds
                Thread.Sleep(this.SleepSeconds);

                // If this check is not made and no methods are assigned to the delegate
                // "NullReferenceException" is thrown
                if (currentDelegate != null)
                {
                    currentDelegate();
                }

                Console.WriteLine(new string('=', 30));

                // On each loop we add the sleep seconds, so when they get equal or greather than "TotalSeconds" the loop stops
                time += this.SleepSeconds;
                currentCall++;
            }
        }
    }
}
