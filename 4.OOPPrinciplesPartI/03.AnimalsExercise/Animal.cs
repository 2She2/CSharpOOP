namespace _03.AnimalsExercise
{
    using System;

    /// <summary>
    /// Abstract class. Inherit "ISound"
    /// </summary>
    public abstract class Animal : ISound
    {
        private int age;
        
        /// <summary>
        /// Constructor to initialize all variables(properties)
        /// </summary>
        /// <param name="age">Animal age</param>
        /// <param name="name">Animal name</param>
        /// <param name="sex">Animal sex</param>
        public Animal(int age, string name, bool sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        /// <summary>
        /// Get and set animal age. If age is negative an exception is thrown
        /// </summary>
        public int Age 
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Animal age can't be negative!");
                }

                this.age = value;
            }
        }

        /// <summary>
        /// Get and set animal name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get and set animal sex. True for male, false for femail
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// Abstract method to be implemented by inherits
        /// </summary>
        public abstract void ProduceSound();

        /// <summary>
        /// Overriden to get name and age of the animal
        /// </summary>
        /// <returns>Get name and age of the animal</returns>
        public override string ToString()
        {
            return string.Format("name: {0}, age: {1}", this.Name, this.Age);
        }
    }
}
