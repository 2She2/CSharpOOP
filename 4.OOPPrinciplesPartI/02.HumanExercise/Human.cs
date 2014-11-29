namespace _02.HumanExercise
{
    using System;

    public abstract class Human
    {
        /// <summary>
        /// Argument for this constructor must be given by the inherited class
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Needed properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
