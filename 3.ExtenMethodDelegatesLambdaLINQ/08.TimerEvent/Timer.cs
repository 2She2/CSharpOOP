namespace _08.TimerEvent
{
    using System;
    using System.Threading;

    public class Timer
    {
        public event TimerEventHandler RaiseTimerEvent;

        public int SleepSeconds { get; set; }
        public int TotalSeconds { get; set; }

        // Only constructor
        public Timer(int sleepSeconds, int totalSeconds)
        {
            this.SleepSeconds = sleepSeconds * 1000;
            this.TotalSeconds = totalSeconds * 1000;
        }

        // By convention this method must be "protected", so it can be inherit
        protected void OnTimer(string msg)
        {
            // Check if we have any subscribers
            if (RaiseTimerEvent != null)
            {
                // Raise event with string parameter passed from another method
                TimerEventArgs e = new TimerEventArgs(msg);
                RaiseTimerEvent(this, e);
            }
        }

        public void Run()
        {
            // Track how many seconds are passed
            int time = 0;

            while (time < this.TotalSeconds)
            {
                Thread.Sleep(this.SleepSeconds);
                time += this.SleepSeconds;

                // Give as parameter seconds passed
                OnTimer((time / 1000).ToString());
            }
        }
    }
}
