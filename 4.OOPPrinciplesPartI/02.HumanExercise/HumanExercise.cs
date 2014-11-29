/* 02. Define abstract class Human with first name and last name.
 * Define new class Student which is derived from Human and has new field – grade. 
 * Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and
 * method MoneyPerHour() that returns money earned by hour by the worker. 
 * Define the proper constructors and properties for this hierarchy.
 * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
 * Initialize a list of 10 workers and sort them by money per hour in descending order.
 * Merge the lists and sort them by first name and last name.
*/

namespace _02.HumanExercise
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    class HumanExercise
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

            // Initialize a list of 10 students
            // and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
            List<Student> students = new List<Student>
            {
                new Student("Pesho", "Peshev", 4),
                new Student("Gosho", "Goshev", 6),
                new Student("Sasho", "Sashev", 3),
                new Student("Misho", "Mishev", 5),
                new Student("Tosho", "Toshev", 4),
                new Student("Mitko", "Mitev", 6),
                new Student("Ivo", "Ivov", 4),
                new Student("Emo", "Emov", 2),
                new Student("Zdravka", "Zdravkova", 6),
                new Student("Penka", "Penkova", 5)
            };

            // Using Extension methods to sort the students
            // We can add .ThenBy(x => x.FirstName) if we want to sort the students with same grade, by first name
            var sortedStudentsByGrade = students.OrderBy(student => student.Grade);

            // Using LINQ Query to sort the students
            //var studentsSortedByGrade =
            //    from student in students
            //    orderby student.Grade ascending
            //    select student;

            Console.WriteLine("Students sorted by grade: ");
            foreach (Student student in sortedStudentsByGrade)
            {
                Console.WriteLine("{0,30}", student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Initialize a list of 10 workers and sort them by money per hour in descending order.
            // Merge the lists and sort them by first name and last name.
            List<Worker> workers = new List<Worker>
            {
                new Worker("Pesho", "Goshev", 350M, 8),
                new Worker("Gosho", "Peshev", 400M, 8),
                new Worker("Sasho", "Sashev", 360M, 7),
                new Worker("Misho", "Zdravkov", 510M, 10),
                new Worker("Tosho", "Peshev", 490M, 7),
                new Worker("Mitko", "Ivov", 440M, 8),
                new Worker("Ivo", "Emov", 560M, 9),
                new Worker("Emo", "Mitev", 550M, 6),
                new Worker("Zdravka", "Misheva", 612M, 8),
                new Worker("Penka", "Penkova", 545, 7)
            };

            // Using extension methods
            var workersSortedByMoneyPerHour = workers.OrderByDescending(worker => worker.MoneyPerHour());

            Console.WriteLine("Workers sorted by money per hour in descending order.");
            foreach (Worker worker in workersSortedByMoneyPerHour)
            {
                Console.Write("{0,35}: ", worker);
                Console.WriteLine("{0:C} per hour", worker.MoneyPerHour());
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Merge both "Enumerators", using extension methods
            // Cast to (IEnumerable<Human>), so the extension method can work.
            // Then first order by first name and if they are equal order by last name
            var mergedLists = sortedStudentsByGrade.Concat(
                (IEnumerable<Human>)workersSortedByMoneyPerHour
                .Where(p => true))
                .OrderBy(x => x.FirstName).ThenBy(y => y.LastName);

            Console.WriteLine("Merger enumerates, sorted by first name and last name.");
            foreach (Human item in mergedLists)
            {
                Console.WriteLine(item);
            }
        }
    }
}
