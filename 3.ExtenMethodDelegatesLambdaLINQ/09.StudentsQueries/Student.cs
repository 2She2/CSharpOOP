// 09. Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. 

namespace _09.StudentsQueries
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        // Lest where marks will be kept
        private List<int> marks;

        // Needed properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public int GroupNumber { get; set; }
        public Group Group { get; set; }

        // This is for exercise 18! Thats way I don't initialize it in the other constructors
        public string GroupName { get; set; }

        // This is for exercise 18! Thats way I don't initialize it in the other constructors
        public Student(string firstName, string lastName, string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GroupName = groupName;
        }

        // Optional constructors
        public Student()
            : this(null, null, 0, null, null, 0, null, null)
        {
        }

        public Student(string firstName, string lastName)
            : this(firstName, lastName, 0, null, null, 0, null, null)
        {
        }

        // Full constructor of the class
        public Student(string firstName, string lastName, int fN, string tel, string email, int groupNumber, List<int> marks, Group group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fN;
            this.Tel = tel;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.marks = marks;
            this.Group = group;
        }

        /// <summary>
        /// Add mark in the list with marks
        /// </summary>
        /// <param name="mark">Mark to add</param>
        public void AddMark(int mark)
        {
            ValidateMark(mark);
            this.marks.Add(mark);
        }

        /// <summary>
        /// Remove mark from the list with marks
        /// </summary>
        /// <param name="mark">Mark to remove</param>
        public void RemoveMark(int mark)
        {
            ValidateMark(mark);
            this.marks.Remove(mark);
        }

        /// <summary>
        /// Return the count of the marks
        /// </summary>
        public int MarksCount
        {
            get { return marks.Count; }
        }

        /// <summary>
        /// Get marks as an array of ints
        /// </summary>
        /// <returns>Array of ints</returns>
        public int[] GetMarks()
        {
            return marks.ToArray();
        }

        /// <summary>
        /// Remove all marks from the list
        /// </summary>
        public void RemoveAllMarks()
        {
            marks.Clear();
        }

        /// <summary>
        /// Overriden to get all properties of the class
        /// </summary>
        /// <returns>String with student properties</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}, FN: {2}, Tel: {3}, Email: {4}, Marks: {5}",
                this.FirstName, this.LastName, this.FN, this.Tel, this.Email, MarksToString());
        }

        /// <summary>
        /// Get all marks
        /// </summary>
        /// <returns>All marks as a string</returns>
        public string MarksToString()
        {
            // Use string buidler, because of performance
            StringBuilder marksBuilder = new StringBuilder();

            for (int i = 0; i < this.MarksCount; i++)
            {
                marksBuilder.Append(marks[i]);

                if (i < this.MarksCount - 1)
                {
                    // We don't want redundant spaces at the end of the string
                    marksBuilder.Append(' ');
                }
            }

            return marksBuilder.ToString();
        }

        /// <summary>
        /// Validate if mark is correct
        /// </summary>
        /// <param name="mark">Mark to validate</param>
        private void ValidateMark(int mark)
        {
            if (mark < 2 || mark > 6)
            {
                throw new ArgumentException("Mark must be between 2 and 6!");
            }
        }
    }
}
