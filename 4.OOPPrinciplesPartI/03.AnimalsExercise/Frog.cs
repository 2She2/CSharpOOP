namespace _03.AnimalsExercise
{
    using System;

    /// <summary>
    /// Inherit class "Animal"
    /// </summary>
    public class Frog : Animal
    {
        /// <summary>
        /// Only constructor. All variables are initialized by the parent(base) class
        /// </summary>
        /// <param name="age">Frog age</param>
        /// <param name="name">Frog name</param>
        /// <param name="sex">Frog sex</param>
        public Frog(int age, string name, bool sex)
            : base(age, name, sex)
        {
        }

        /// <summary>
        /// Overriden to print the specific "sound"
        /// </summary>
        public override void ProduceSound()
        {
            Console.WriteLine("Frog sound");
        }
    }
}
