namespace _02.HumanExercise
{
    using System;

    /// <summary>
    /// Inherite abstract class "Human", so we get all its properties
    /// </summary>
    public class Student : Human
    {
        // Field as requered in the description of the exrecise
        private int grade;

        /// <summary>
        /// Only constructor of the class. Initialize all fields and properties
        /// </summary>
        /// <param name="firstName">First name of the student</param>
        /// <param name="lastName">Last name of the student</param>
        /// <param name="grade">Grade of the student</param>
        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            // Initialize all variables(properties)
            this.Grade = grade;
        }

        /// <summary>
        /// Get and set grade. It must be between 2 and 6. Otherwise exception is thrown
        /// </summary>
        public int Grade
        {
            get { return this.grade; }
            set 
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("Greade must be between 2 and 6!");
                }

                this.grade = value;
            }
        }

        /// <summary>
        /// Overriden to get first, last name and grade of the student as a string
        /// </summary>
        /// <returns>First, last name and grade of the student as a string</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}, grade: {2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}
