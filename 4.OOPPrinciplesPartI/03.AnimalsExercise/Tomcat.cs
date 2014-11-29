namespace _03.AnimalsExercise
{
    using System;

    /// <summary>
    /// Inherit class "Kitten" and its parents
    /// </summary>
    public class Tomcat : Cat
    {
        /// <summary>
        /// Only constructor. All variables are initialized by the parent(base) class
        /// </summary>
        /// <param name="age">Tomcat age</param>
        /// <param name="name">Tomcat name</param>
        public Tomcat(int age, string name)
            : base(age, name, true) // tomcats are always male, so we directly put "true" in the base constructor
        {
        }

        /// <summary>
        /// Overriden to print the specific "sound"
        /// </summary>
        public override void ProduceSound()
        {
            Console.WriteLine("Tomcat sound");
        }
    }
}
