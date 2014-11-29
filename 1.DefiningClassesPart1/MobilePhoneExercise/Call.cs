// 08. Create a class Call to hold a call performed through a GSM.
//     It should contain date, time, dialed phone number and duration (in seconds).

namespace GSMTest
{
    using System;
    using System.Collections.Generic;

    public class Call
    {
        private DateTime date;
        private string dialedPhoneNumber;
        private uint durationInSeconds; // This field intentionally is not set to nullable. Call duration can't be null

        /// <summary>
        /// Only constructor for calls
        /// </summary>
        /// <param name="date">Date and time of the call</param>
        /// <param name="dialedPhoneNumber">Dialed phone number</param>
        /// <param name="durationInSeconds">Conversation duration in seconds</param>
        public Call(DateTime date, string dialedPhoneNumber, uint durationInSeconds)
        {
            this.Date = date;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.DurationInSeconds = durationInSeconds;
        }

        /// <summary>
        /// Get date of conversation. 
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            // Set is private, because we have only one constructor to which we give the date
            private set
            {
                // Can't add future date, because the call is still not made
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Can't add future date!");
                }
                else
                {
                    this.date = value;
                }
            }
        }

        /// <summary>
        /// Get date of conversation. 
        /// </summary>
        public string DialedPhoneNumber
        {
            get { return this.dialedPhoneNumber; }
            //Set is private, because we have only one constructor to which we give the phone number
            private set
            {
                // Phone number must be at least 7 digits(with '+' and spaces)
                if (value.Length < 7)
                {
                    throw new ArgumentException("Phone number can't be less than 7 digits!");
                }

                // First char can be '+' or digit
                if (value[0] != '+' && !char.IsDigit(value[0]))
                {
                    throw new ArgumentException("Pone number can contain '+' in the begining and only digits!");
                }

                // Rest of the chars can be only digits or space
                for (int i = 1; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]) && value[i] != ' ')
                    {
                        throw new ArgumentException("Pone number can contain '+' in the begining and only digits!");
                    }
                }

                this.dialedPhoneNumber = value;
            }
        }

        /// <summary>
        /// Get duration of conversation. 
        /// </summary>
        public uint DurationInSeconds
        {
            get { return this.durationInSeconds; }
            //Set is private, because we have only one constructor to which we give the phone number
            private set { this.durationInSeconds = value; }
        }

        /// <summary>
        /// Overriden to get the conversation date, phone number and duration
        /// </summary>
        /// <returns>Return the gsm model and manufacturer</returns>
        public override string ToString()
        {
            return string.Format("Date: {0}, Number: {1}, Duration: {2} Seconds", date, dialedPhoneNumber, durationInSeconds);
        }
    }
}
