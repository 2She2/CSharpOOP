// 04. // 04. Create a class Person with two fields – name and age.
//     Age can be left unspecified (may contain null value. 
//     Override ToString() to display the information of a person and if age is not specified – to say so.
//     Write a program to test this functionality.

namespace _4.PersonExercise
{
    using System;

    public class Person
    {
        // Fields needed for validation
        private string name;
        private byte? age;

        /// <summary>
        /// Only constructor. Initialize all fields(age is optional)
        /// </summary>
        /// <param name="name">Name of person</param>
        /// <param name="age">Age of person</param>
        public Person(string name, byte? age = null) // Set it to byte, that we don't have to make validation for negative numbers
        {
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Get name of person. Set is private
        /// </summary>
        public string Name
        {
            get { return this.name; }
            private set
            {
                // If name is less than 3 letters or first symbol is not a letter, an exception is thrown
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name can't be less than 3 letters!");
                }

                if (!char.IsLetter(value[0]))
                {
                    throw new ArgumentException("First symbol must be a letter!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Get age of person. Set is private
        /// </summary>
        public byte? Age
        {
            get { return this.age; }
            private set
            {
                // If age is more than 120, an exception is thrown. Age can't be negative, because we use "byte"
                if (value > 120)
                {
                    throw new ArgumentException("Age can't be more than 120!");
                }

                this.age = value;
            }
        }

        /// <summary>
        /// Overriden to get string with person's properties values
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string message;

            // Check if optional field "age" is defferent from null
            // Can be made with operator (? a : b), but I don't like this syntax
            if (this.Age != null)
            {
                message = this.Age.ToString();
            }
            else
            {
                message = "Age not specified";
            }

            return string.Format("Name: {0}, Age: {1}", this.Name, message);
        }
    }
}
