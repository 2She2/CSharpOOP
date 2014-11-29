namespace _03.FindStudentsNamesWithLINQ
{
    using System;

    public class Student
    {
        /// <summary>
        /// Constructor with no parameters
        /// </summary>
        public Student()
            : this(null, null, 0)
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        public Student(string firstName, string lastName)
            : this(firstName, lastName, 0)
        {
        }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="age">Age</param>
        public Student(string firstName, string lastName, byte age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        // Needed fields(properties) for the exercise
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public byte Age
        {
            get;
            set;
        }
    }
}
