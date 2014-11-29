// 01. Define a class that holds information about a mobile phone device:
//     model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk)
//     and display characteristics (size and number of colors).
//     Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

// 02. Define several constructors for the defined classes that take different sets of arguments
//     (the full information for the class or part of it). 
//     Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

// 04. Add a method in the GSM class for displaying all information about it. Try to override ToString().

// 05. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
//     Ensure all fields hold correct data at any given time.

// 06. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.

// 09. Add a property CallHistory in the GSM class to hold a list of the performed calls.
//     Try to use the system class List<Call>.

// 10. Add methods in the GSM class for adding and deleting calls from the calls history.
//     Add a method to clear the call history.

// 11. Add a method that calculates the total price of the calls in the call history.
//     Assume the price per minute is fixed and is provided as a parameter.

namespace GSMTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GSM
    {
        private static GSM IPhone4S;

        private string model;
        private string manufacturer;
        private decimal? price; // Using '?' to make the variable nullable, other variables are nullable by default
        private string owner;
        private Battery battery;
        private Display display;

        private List<Call> callHistory = new List<Call>();

        /// <summary>
        /// Static constructor, to initialize the static field
        /// </summary>
        static GSM()
        {
            IPhone4S = new GSM("iPhone4s", "Apple", 450, "Pesho",
           new Battery("Non-removable Li-Po 1432 mAh battery (5.3 Wh)", 200, 14, BatteryType.LiPro),
           new Display(16, 960, 640));
        }

        /// <summary>
        /// Minimum requested constructor. Set model and manufacturer of the gsm
        /// </summary>
        /// <param name="model"></param>
        /// <param name="manufacturer"></param>
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner)
            : this(model, manufacturer, price, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, null)
        {
        }

        /// <summary>
        /// Full constructor. Set values to all fields
        /// </summary>
        /// <param name="model">Model of the current gsm</param>
        /// <param name="manufacturer">Manufacturer of the current gsm</param>
        /// <param name="price">Price of the current gsm</param>
        /// <param name="owner">Owner of the current gsm</param>
        /// <param name="battery">Battery of the current gsm</param>
        /// <param name="display">Display of the current gsm</param>
        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        /// <summary>
        /// Get and set Model of the gsm
        /// </summary>
        public string Model
        {
            get { return this.model; }
            set
            {
                // Minimum length of the string is 3 chars, otherwise an exeption is thrown
                if (value != null && value.Length < 3)
                {
                    throw new ArgumentException("GSM model can't be less than 3 symbols!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        /// <summary>
        /// Get and set Manufacturer of the gsm
        /// </summary>
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                // Minimum length of the string is 3 chars, otherwise an exeption is thrown
                if (value != null && value.Length < 3)
                {
                    throw new ArgumentException("GSM manufacturer can't be less than 3 symbols!");
                }
                else
                {
                    this.manufacturer = value;
                }
            }
        }

        /// <summary>
        /// Get and set Price of the gsm. If we do not know the price we can make it null
        /// </summary>
        public decimal? Price
        {
            get { return this.price; }
            set
            {
                // The price can't be negative
                if (value != null && value < 0)
                {
                    throw new ArgumentException("GSM price can't be negative!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        /// <summary>
        /// Get and set Owner of the gsm
        /// </summary>
        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (value != null && value.Length < 3)
                {
                    throw new ArgumentException("GSM owner name can't be less than 3 symbols!!");
                }
                else
                {
                    this.owner = value;
                }
            }
        }

        /// <summary>
        /// Get and set Battery of the gsm
        /// </summary>
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        /// <summary>
        /// Get and set Display of the gsm
        /// </summary>
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        /// <summary>
        /// Get static properties of "IPhone4s"
        /// </summary>
        public static GSM IPhone4s
        {
            get { return IPhone4S; }
        }

        /// <summary>
        /// Return a copy of call history, because if we return the original List, elements can be changed from anyone
        /// </summary>
        public Call[] CallHistory
        {
            get
            {
                Call[] copy = new Call[callHistory.Count];
                callHistory.CopyTo(copy);
                return copy;
            }
        }

        /// <summary>
        /// Add calls to call history
        /// </summary>
        /// <param name="call">Call to be added</param>
        public void AddCall(Call call)
        {
            callHistory.Add(call);
        }

        /// <summary>
        /// Delete the last call in call history
        /// </summary>
        public void DeleteLastCall()
        {
            if (callHistory.Count == 0)
            {
                throw new ArgumentNullException("Trying to delete element in empty array!");
            }
            else
            {
                callHistory.RemoveAt(callHistory.Count - 1);
            }
        }

        /// <summary>
        /// Delete the call with longet duration
        /// </summary>
        public void DeleteLongestCall()
        {
            uint longestDuration = 0;
            int longestDurationIndex = 0;

            // Iterate through the List, to fing the call with longest duration
            for (int i = 0; i < callHistory.Count; i++)
            {
                if (callHistory[i].DurationInSeconds > longestDuration)
                {
                    longestDuration = callHistory[i].DurationInSeconds;
                    longestDurationIndex = i;
                }
            }

            callHistory.RemoveAt(longestDurationIndex);
        }

        /// <summary>
        /// Clear entire call history
        /// </summary>
        public void ClearCallHistory()
        {
            callHistory.Clear();
        }

        /// <summary>
        /// Calculate the cost of all calls in call history
        /// </summary>
        /// <param name="pricePerMinute">Price per minute</param>
        /// <returns></returns>
        public decimal ClalcTotalCallsPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0M;
            ulong totalDurationInMinutes = 0;
            // Sum all call durations in call history
            for (int i = 0; i < callHistory.Count; i++)
            {
                totalDurationInMinutes += callHistory[i].DurationInSeconds;
            }

            // Transform seconds to minutes
            totalDurationInMinutes /= 60;
            totalPrice = pricePerMinute * totalDurationInMinutes;
            return totalPrice;
        }

        /// <summary>
        /// Overriden to get the gsm model and manufacturer
        /// </summary>
        /// <returns>Return the gsm model and manufacturer</returns>
        public override string ToString()
        {
            return string.Format("Model: {0}, Manufacturer: {1}", this.model, this.manufacturer);
        }
    }
}
