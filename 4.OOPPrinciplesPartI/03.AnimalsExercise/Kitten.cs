namespace _03.AnimalsExercise
{
    using System;

    /// <summary>
    /// Inherit class "Kitten" and its parents
    /// </summary>
    public class Kitten : Cat
    {
        /// <summary>
        /// Only constructor. All variables are initialized by the parent(base) class
        /// </summary>
        /// <param name="age">Kitten age</param>
        /// <param name="name">Kitten name</param>
        public Kitten(int age, string name)
            : base(age, name, false) // kittens are always female, so we directly put "false" in the base constructor
        {
        }

        /// <summary>
        /// Overriden to print the specific "sound"
        /// </summary>
        public override void ProduceSound()
        {
            Console.WriteLine("Kitten sound");
        }
    }
}
