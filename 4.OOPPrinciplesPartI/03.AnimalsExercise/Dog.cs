namespace _03.AnimalsExercise
{
    using System;

    /// <summary>
    /// Inherit class "Animal"
    /// </summary>
    public class Dog : Animal
    {
        /// <summary>
        /// Only constructor. All variables are initialized by the parent(base) class
        /// </summary>
        /// <param name="age">Dog age</param>
        /// <param name="name">Dog name</param>
        /// <param name="sex">Dog sex</param>
        public Dog(int age, string name, bool sex)
            : base(age, name, sex)
        {
        }

        /// <summary>
        /// Overriden to print the specific "sound"
        /// </summary>
        public override void ProduceSound()
        {
            Console.WriteLine("Bauu");
        }
    }
}
