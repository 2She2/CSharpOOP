/* 03. Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
 * Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
 * Kittens and tomcats are cats. All animals are described by age, name and sex.
 * Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
 * Create arrays of different kinds of animals and calculate the average age of each kind of animal
 * using a static method (you may use LINQ).
*/

namespace _03.AnimalsExercise
{
    using System;
    using System.Linq;

    class AnimalsExercise
    {
        static void Main()
        {
            // Array of different type of animals
            Animal[] zoo = new Animal[10]
            {
                new Cat(3, "Cat1", true),
                new Cat(2, "Cat2", false),
                new Dog(3, "Dog1", false),
                new Dog(6, "Dog2", true),
                new Dog(3, "Dog3", true),
                new Frog(1, "Frog1", true),
                new Frog(2, "Frog2", false),
                new Kitten(2, "Kittie1"),
                new Kitten(1, "Kittie2"),
                new Tomcat(3, "Tomcat")
            };

            // Call static method to calculate the average age of each kind of animal in the "zoo"
            CalcAverageAge(zoo);
        }

        /// <summary>
        /// Calculate the average age of each kind of animal
        /// </summary>
        /// <param name="animals">Array of animals to calculate their age</param>
        static void CalcAverageAge(Animal[] animals)
        {
            // Sort the animals by kind(type) with extension method "GroupBy"
            var sortedAnimals = animals.GroupBy(x => x.GetType());

            foreach (var groups in sortedAnimals)
            {
                // For each group(kind) of animals, calculate their average age with extension method "Average"
                double averageAge = groups.Average(x => x.Age);
                Console.WriteLine("Average age: {0}", averageAge);

                // Print all animals in each group(type)
                foreach (Animal animal in groups)
                {
                    Console.WriteLine(animal);
                }

                Console.WriteLine(new string('=', 30));
            }
        }
    }
}
