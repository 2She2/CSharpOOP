// 18. Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.

namespace _18.ExtractStudentsByGroupName
{
    using System;
    using System.Linq;
    using _09.StudentsQueries;

    public static class ExtractStudentsByGroupName
    {
        static void Main(string[] args)
        {
            // Using class "Student" from previous exercises
            Student[] students = new Student[] 
            {
                new Student("Pesho", "Peshev", "First group"),
                new Student("Gosho", "Goshev", "Second group"),
                new Student("Tosho", "Toshev", "First group"),
                new Student("Sasho", "Sashev", "Third group"),
                new Student("Misho", "Mishev", "Second group")
            };

            // Grouping students with LINQ Query
            var groupedStudentsWithQuery =
                from student in students
                group student by student.GroupName into studentsByGroup
                select studentsByGroup;

            // Grouping students with Extension methods and Lambda expression
            var groupedStudentsWithLambda = students.GroupBy(st => st.GroupName);

            // Using two nested foreach to print the students for each group
            foreach (var nameGroup in groupedStudentsWithQuery)
            {
                Console.WriteLine(nameGroup.Key);
                foreach (var student in nameGroup)
                {
                    Console.WriteLine(student.StudentToString());
                }
            }
        }

        /// <summary>
        /// Extension method to set student properties to string
        /// </summary>
        /// <param name="student">Student to apply to</param>
        /// <returns>String with student properties values</returns>
        public static string StudentToString(this Student student)
        {
            return string.Format("{0} {1}, Group: {2}", student.FirstName, student.LastName, student.GroupName);
        }
    }
}
