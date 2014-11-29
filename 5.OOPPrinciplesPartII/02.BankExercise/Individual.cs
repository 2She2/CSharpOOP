namespace _02.BankExercise
{
    using System;

    /// <summary>
    /// Represent individual(personal) customer. Inherit abstract class "customer"
    /// </summary>
    public class Individual : Customer
    {
        // Field needed for the validation
        private long egn;

        /// <summary>
        /// Only constructor. Initialize all fields
        /// </summary>
        /// <param name="name">Name of customer</param>
        /// <param name="address">Address of customer</param>
        /// <param name="egn">EGN of customer</param>
        public Individual(string name, string address, long egn)
            : base(name, address) // call constructor from the base class
        {
            this.Egn = egn;
        }

        /// <summary>
        /// Get EGN of customer
        /// </summary>
        public long Egn
        {
            get { return this.egn; }
            // Once a EGN is assign, we don't want anyone to change it
            // Make some simple validation of the input EGN
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Egn can't be negative!");
                }

                if (value.ToString().Length != 10)
                {
                    throw new ArgumentException("EGN must be 10 digits long!");
                }

                if (int.Parse(value.ToString().Substring(2, 2)) > 12 || int.Parse(value.ToString().Substring(4, 2)) > 31)
                {
                    throw new ArgumentException("Month can't be greater than 12, nor day of month, greater than 31!");
                }

                this.egn = value;
            }
        }
    }
}
