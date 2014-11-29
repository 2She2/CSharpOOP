namespace _01.SchoolExercise
{
    using System;

    /// <summary>
    /// Abstract class
    /// </summary>
    public abstract class People // Or abstract class?
    {
        /// <summary>
        /// Only constructor of the class. Initialize name
        /// </summary>
        /// <param name="name"></param>
        public People(string name)
        {
            this.Name = name;
        }

        string Name { get; set; }
    }
}
