namespace _01.SchoolExercise
{
    using System;

    /// <summary>
    /// Represent a student from school. Inherits abstract class "People" and interface "IComment"
    /// </summary>
    public class Student : People, IComment
    {
        // Needed properties
        public string Comment { get; set; }
        public int ClassNumber { get; private set; } // Class number is unique, so we can't change it

        /// <summary>
        /// Only constructor. Initialize all variables(properties)
        /// </summary>
        /// <param name="name">Name of the student</param>
        /// <param name="classNumber">Unique class number of the student</param>
        public Student(string name, int classNumber)
            : base(name) // initialized by the parent class(People)
        {
            this.ClassNumber = classNumber;
        }
    }
}
