namespace _01.SchoolExercise
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represent a class of students. Implement interface "IComment"
    /// </summary>
    public class Class : IComment
    {
        // Needed fields(properties)
        public string Identifier { get; set; }
        List<Teacher> teachers;
        List<Student> students;

        /// <summary>
        /// Only constructor. Initialize all variables(properties)
        /// </summary>
        /// <param name="identifier">Class unique identifier</param>
        /// <param name="teachers">Class teachers</param>
        /// <param name="students">Class students</param>
        public Class(string identifier, List<Teacher> teachers, List<Student> students)
        {
            this.Identifier = identifier;
            this.teachers = teachers;
            this.students = students;
        }

        /// <summary>
        /// Optional comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Remove all students from the class
        /// </summary>
        public void RemoveAllStudents()
        {
            this.students.Clear();
        }

        /// <summary>
        /// Get teachers from the current class
        /// </summary>
        public Teacher[] GetTeachers
        {
            get { return this.teachers.ToArray(); }
        }

        /// <summary>
        /// Get students from the current class
        /// </summary>
        public Student[] GetStudents
        {
            get { return this.students.ToArray(); }
        }

        /// <summary>
        /// Add teachers for the class
        /// </summary>
        /// <param name="teacher">Teacher to add</param>
        public void AddTeacher(Teacher teacher)
        {
            // If it is null, we can't add techers, so we initialize it
            if (this.teachers == null)
            {
                this.teachers = new List<Teacher>();
            }

            this.teachers.Add(teacher);
        }

        /// <summary>
        /// Remove a teacher from the class
        /// </summary>
        /// <param name="teacher">Teacher to remove</param>
        public void RemoveTeacher(Teacher teacher)
        {
            // If teachers list is not initialized(null) or the count of the techers is 0, an exception is thrown
            if (this.teachers == null)
            {
                throw new ArgumentNullException("There is no instance of Teachers. Can't remove from a null!");
            }

            if (this.teachers.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Teachers count is 0. Can't remove from Teachers!");
            }

            this.teachers.Remove(teacher);
        }

        /// <summary>
        /// Remove all teachers from the class
        /// </summary>
        public void RemoveAllTeachers()
        {
            this.teachers.Clear();
        }

        /// <summary>
        /// Add student to the class
        /// </summary>
        /// <param name="student">Student to add</param>
        public void AddStudent(Student student)
        {
            // If it is null, we can't add students, so we initialize it
            if (this.students == null)
            {
                this.students = new List<Student>();
            }

            this.students.Add(student);
        }

        /// <summary>
        /// Remove a student from the class
        /// </summary>
        /// <param name="student">Student to remove</param>
        public void RemoveStudent(Student student)
        {
            // If students list is not initialized(null) or the count of the students is 0, an exception is thrown
            if (this.students == null)
            {
                throw new ArgumentNullException("There is no instance of Teachers. Can't remove from a null!");
            }

            if (this.students.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Teachers count is 0. Can't remove from Teachers!");
            }

            this.students.Remove(student);
        }
    }
}
