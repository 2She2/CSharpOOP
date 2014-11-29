namespace _03.AnimalsExercise
{
    using System;

    /// <summary>
    /// Inherit class "Animal"
    /// </summary>
    public class Cat : Animal // Intentionaly didn't make it abstract. Because we can make just a cat.
    {
        /// <summary>
        /// Only constructor. All variables are initialized by the parent(base) class
        /// </summary>
        /// <param name="age">Cat age</param>
        /// <param name="name">Cat name</param>
        /// <param name="sex">Cat sex</param>
        public Cat(int age, string name, bool sex)
            : base(age, name, sex)
        {
        }

        /// <summary>
        /// Overriden to print the specific "sound"
        /// </summary>
        public override void ProduceSound()
        {
            Console.WriteLine("Miauuu");
        }
    }
}
