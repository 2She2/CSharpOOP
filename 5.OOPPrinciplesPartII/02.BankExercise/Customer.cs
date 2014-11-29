namespace _02.BankExercise
{
    using System;

    /// <summary>
    /// Represent a bank customer. Abstract class, can't maki instances of it
    /// </summary>
    public abstract class Customer
    {
        // Needed fields
        private string name;
        private string address;

        /// <summary>
        /// Only constructor. Initialize all fields
        /// </summary>
        /// <param name="name">Name of customer</param>
        /// <param name="address">Address of customer</param>
        public Customer(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

        /// <summary>
        /// Get name of customer
        /// </summary>
        public string Name
        {
            get { return this.name; }
            // Once a name is assign, we don't want anyone to change it
            // Make some simple validation of the input name
            private set
            {
                if (value.Length < 3 || value == null)
                {
                    throw new ArgumentException("Name must be at least 3 letters!");
                }

                if (!char.IsLetter(value[0]))
                {
                    throw new ArgumentException("Name must start with letter!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Get address of customer
        /// </summary>
        public string Address
        {
            get { return this.address; }
            // Once a address is assign, we don't want anyone to change it
            // Make some simple validation of the input address
            private set
            {
                if (value.Length < 4 || value == null)
                {
                    throw new ArgumentException("Address must be at least 5 letters!");
                }

                this.address = value;
            }
        }
    }
}
