namespace _02.HumanExercise
{
    using System;

    /// <summary>
    /// Inherite abstract class "Human", so we get all its properties
    /// </summary>
    public class Worker : Human
    {
        // Needed fields
        private decimal weekSalary;
        private int workHoursPerDay;

        /// <summary>
        /// Only constructor of the class. Initialize all fields and properties
        /// </summary>
        /// <param name="firstName">First name of the worker</param>
        /// <param name="lastName">Last name of the worker</param>
        /// <param name="weekSalary">Week salary</param>
        /// <param name="workHoursPerDay">Work hours per day</param>
        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay) : base(firstName, lastName)
        {
            // Initialize all variables(properties)
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        /// <summary>
        /// Get and set week salary. It must be positive number. Otherwise exception is thrown
        /// </summary>
        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Week salary can't be negative!");
                }

                this.weekSalary = value;
            }
        }

        /// <summary>
        /// Get and set work hours per day. It must be positive number. Otherwise exception is thrown
        /// </summary>
        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Work hours per day can't be negative!");
                }

                this.workHoursPerDay = value;
            }
        }

        /// <summary>
        /// Calculate money per hour
        /// </summary>
        /// <returns>Money per hour</returns>
        public decimal MoneyPerHour()
        {
            // Get the salary per day by dividing by 5(working days)
            decimal salaryPerDay = this.WeekSalary / 5;
            return (salaryPerDay / this.WorkHoursPerDay);
        }

        /// <summary>
        /// Overriden to get first, last name and week salary of the worker as a string
        /// </summary>
        /// <returns>First, last name and week salary of the worker as a string</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}, week salary: {2}", this.FirstName, this.LastName, this.WeekSalary);
        }
    }
}
