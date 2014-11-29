namespace _08.TimerEvent
{
    using System;

    // By convention the name of the delegate must end with "EventHandler"
    public delegate void TimerEventHandler(object sender, TimerEventArgs e);

    /// <summary>
    /// Custom event. Must inherit "EventArgs"
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        public string Message { get; set; }

        public TimerEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
