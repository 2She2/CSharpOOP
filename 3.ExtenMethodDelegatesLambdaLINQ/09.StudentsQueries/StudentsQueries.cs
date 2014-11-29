namespace _09.StudentsQueries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    static class StudentsQueries
    {
        public static void Main()
        {
            // 09. Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber.
            //     Create a List<Student> with sample students. Select only the students that are from group number 2.

            List<Student> students = new List<Student>() 
            {
                new Student("Pesho", "Peshev", 130906, "0888555555", "pesho@abv.bg", 2, new List<int> {3, 4}, new Group(201, "Mathematics")),
                new Student("Gosho", "Goshev", 450809, "029994433", "goshkata@mail.bg", 3, new List<int> {5, 6, 2}, new Group(104, "Rocket science")),
                new Student("Tosho", "Toshev", 913010, "0899112233", "tosho@abv.bg", 2, new List<int> {3, 4, 5, 3}, new Group(203, "Mathematics")),
                new Student("Sasho", "Sashev", 411206, "0888665544", "sashko@yahoo.com", 3, new List<int> {6, 6, 3, 2, 5}, new Group(102, "Drink and eat")),
                new Student("Misho", "Mishev", 710806, "021112233", "misho@abv.bg", 2, new List<int> {4, 6}, new Group(201, "Mathematics"))
            };

            // 09. Select only the students that are from group number 2.
            //     Use LINQ query. Order the students by FirstName
            var groupTwoStudentsQuery =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            Console.WriteLine("Students in group 2, with LINQ query:");
            foreach (var student in groupTwoStudentsQuery)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // 10. Implement the previous using the same query expressed with extension methods.
            // Set the extension method into extension method :)
            // F12 on the method to see it!
            var groupTwoStudentsWithExtension = students.SortStudentsByGroupAndName();

            Console.WriteLine("Students in group 2, with extension methods:");
            foreach (var student in groupTwoStudentsWithExtension)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // 11. Extract all students that have email in abv.bg. Use string methods and LINQ.
            var studentsByEmail =
                from student in students
                where student.Email.EndsWith("abv.bg", StringComparison.OrdinalIgnoreCase) // email always end with the provider
                select student;

            Console.WriteLine("Students with email at abv.bg:");
            foreach (var student in studentsByEmail)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // 12. Extract all students with phones in Sofia. Use LINQ.
            var studentsByPhone =
                from student in students
                where student.Tel.StartsWith("02") // Made it simple. Phone must start with the code. If we want more complex stuff we can use Regular Expressions
                select student;

            Console.WriteLine("Students with phones in Sofia:");
            foreach (var student in studentsByPhone)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // 13. Select all students that have at least one mark Excellent (6)
            //    into a new anonymous class that has properties – FullName and Marks. Use LINQ.
            var studentsWithExcellent =
                from student in students
                where student.GetMarks().Contains(6)
                select new { FullName = student.FirstName + student.LastName, Marks = student.MarksToString() };

            Console.WriteLine("Students with at least one mark Excellent:");
            foreach (var student in studentsWithExcellent)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // 14. Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
            // Set the extension method into extension method :)
            // F12 on the method to see it!
            var studentsWithTwoMarks = students.FindStudentsWithTwoMarks();

            Console.WriteLine("Students with at least two marks:");
            foreach (var student in studentsWithTwoMarks)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // 15. Extract all Marks of the students that enrolled in 2006.
            //     (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            var studentsEnrolledIn06 =
                from student in students
                where student.FN.ToString().Substring(4, 2) == "06" // Use substring from index 4, because FN can be longer and not last 2 digits to be 5 and 6
                select student.MarksToString();

            Console.WriteLine("Marks of students that enrolled in 2006, with LINQ query:");
            foreach (var student in studentsEnrolledIn06)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // 15. Extract all Marks of the students that enrolled in 2006.
            // Set the extension method into extension method :)
            // F12 on the method to see it!
            var studentsEnrolledIn06WithLambda = students.FindStudentsEnrolledIn06();

            Console.WriteLine("Marks of students that enrolled in 2006, with extension methods:");
            foreach (var student in studentsEnrolledIn06WithLambda)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // 16. * Create a class Group with properties GroupNumber and DepartmentName.
            //     Introduce a property Group in the Student class. Extract all students from "Mathematics" department.
            //     Use the Join operator.

            List<Group> departments = new List<Group>
            {
                new Group(103, "Mathematics"),
                new Group(201, "Rocket science"),
                new Group(102, "Drink and eat"),
                new Group(204, "Learn LINQ")
            };

            // Using LINQ Query to solve the task
            var mathematicsDepartmentStudents =
                from department in departments
                join student in students on department.DepartmentName equals student.Group.DepartmentName
                where student.Group.DepartmentName == "Mathematics"
                select new { Department = student.Group.DepartmentName, Name = student.FirstName + ' ' + student.LastName };

            Console.WriteLine("students from \"Mathematics\" department, with LINQ Query");
            foreach (var student in mathematicsDepartmentStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Using Lambda expressions to solve the task
            // This task is more readable and understandable with LINQ Query(at least for me) 
            var mathStudents = departments
                .Join(students,
                department => department.DepartmentName,
                student => student.Group.DepartmentName,
                (department, student) => new { Department = student.Group.DepartmentName, Name = student.FirstName + ' ' + student.LastName })
                .Where(department => department.Department == "Mathematics");

            Console.WriteLine("students from \"Mathematics\" department, with extension methods");
            foreach (var student in mathStudents)
            {
                Console.WriteLine(student);
            }
        }

        /// <summary>
        /// Extension method to find students by group and sort them by first name then by last name
        /// </summary>
        /// <param name="students">List with students to apply to</param>
        /// <returns>IEnumerable<Student></returns>
        public static IEnumerable<Student> SortStudentsByGroupAndName(this List<Student> students)
        {
            // Using Lambda expressions
            var sortedStudents = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            return sortedStudents;
        }

        /// <summary>
        /// Extension method to find students with exactly two marks 
        /// </summary>
        /// <param name="students">List with students to apply to</param>
        /// <returns>IEnumerable<Student></returns>
        public static IEnumerable<Student> FindStudentsWithTwoMarks(this List<Student> students)
        {
            // Using Lambda expressions
            var studentsWithTwoMarks = students.Where(s => s.GetMarks().Count() == 2);
            return studentsWithTwoMarks;
        }

        /// <summary>
        /// Extension method to find students enrolled in 2006
        /// </summary>
        /// <param name="students">List with students to apply to</param>
        /// <returns>IEnumerable<Student></returns>
        public static IEnumerable<string> FindStudentsEnrolledIn06(this List<Student> students)
        {
            // Using Lambda expressions
            var studentsEnrolledIn06 = students.Where(s => s.FN.ToString().Substring(4, 2) == "06").Select(s => s.MarksToString());
            return studentsEnrolledIn06;
        }
    }
}
