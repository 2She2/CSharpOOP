// 03. Write a method that from a given array of students finds all students
//     whose first name is before its last name alphabetically. Use LINQ query operators.

// 04. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

// 05. Using the extension methods OrderBy() and ThenBy() with lambda expressions
//     sort the students by first name and last name in descending order. Rewrite the same with LINQ.

namespace _03.FindStudentsNamesWithLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StudentsTests
    {
        static void Main()
        {
            //// First way is to make class "Student" and add its instances to a list
            //// Make several instance of the class "Students" 
            //Student pesho = new Student("Pesho", "Yanev", 16);
            //Student gosho = new Student("Gosho", "Goshev", 23);
            //Student kiro = new Student("Aleksandar", "Kirilov", 20);
            //Student sasho = new Student("Sasho", "Sashev", 17);
            //Student ivo = new Student("Ivo", "Pavlov", 21);
            //Student teodor = new Student("Teodor", "Todorov", 25);

            //// Make list of students and add them to it
            //List<Student> students = new List<Student>();
            //students.Add(pesho);
            //students.Add(gosho);
            //students.Add(kiro);
            //students.Add(sasho);
            //students.Add(ivo);
            //students.Add(teodor);

            // Second way is to use anonymous types array
            var students = new[]
            { 
                new { FirstName = "Pesho", LastName = "Yanev", Age = 16 }, 
                new {FirstName = "Gosho", LastName = "Goshev", Age = 23 },
                new {FirstName = "Aleksandar", LastName = "Kirilov", Age = 20 },
                new {FirstName = "Sasho", LastName = "Sashev", Age = 17 },
                new {FirstName = "Ivo", LastName = "Pavlov", Age = 21 },
                new {FirstName = "Teodor", LastName = "Todorov", Age = 25 }
            };

            // Using LINQ query operators to find wanted students by name
            var chosenStudentsByName =
                from student in students
                where student.FirstName.CompareTo(student.LastName) == -1
                select student;

            // Print students names
            Console.WriteLine("Students chosen by name:");
            foreach (var student in chosenStudentsByName)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Using LINQ query operators to find wanted students by age
            var chosenStudentsByAge =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student;

            // Print students names and age
            Console.WriteLine("Students chosen by age:");
            foreach (var student in chosenStudentsByAge)
            {
                Console.WriteLine("{0}, age: {1}", student.FirstName, student.Age);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Sort the students by first name and last name in descending order with lambda expressions
            var sortedNamesStudentsLambda = students.OrderByDescending(x => x.FirstName).ThenByDescending(y => y.LastName);

            // Print students names
            Console.WriteLine("Students sorted by name in descending order with lambda expressions:");
            foreach (var student in sortedNamesStudentsLambda)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Sort the students by first name and last name in descending order with LINQ Query
            var sortedNamesStudentsQuery =
               from student in students
               orderby student.FirstName descending, student.LastName descending
               select student;

            // Print students names
            Console.WriteLine("Students sorted by name in descending order with LINQ Query:");
            foreach (var student in sortedNamesStudentsQuery)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}
