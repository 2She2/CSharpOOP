// 04. Create a class Person with two fields – name and age.
//     Age can be left unspecified (may contain null value. 
//     Override ToString() to display the information of a person and if age is not specified – to say so.
//     Write a program to test this functionality.

namespace _4.PersonExercise
{
    using System;

    class PersonExercise
    {
        static void Main()
        {
            // Make two instance of the class "Person", to test
            Person pesho = new Person("Pesho");
            Person gosho = new Person("Gosho", 25);

            // Print with overriden method "ToString()"
            Console.WriteLine(pesho);
            Console.WriteLine(gosho);
        }
    }
}
