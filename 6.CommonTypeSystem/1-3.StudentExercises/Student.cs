// 01. Define a class Student, which contains data about a student – first, middle and last name, SSN,
//     permanent address, mobile phone e-mail, course, specialty, university, faculty.
//     Use an enumeration for the specialties, universities and faculties.
//     Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

// 02. Add implementations of the ICloneable interface. The Clone() method should deeply copy
//     all object's fields into a new object of type Student.

// 03. Implement the  IComparable<Student> interface to compare students by names
//     (as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order).

namespace _1_3.StudentExercises
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        // Fields needed for validation
        private long ssn;
        private int course;

        /// <summary>
        /// Only constructo. Initialize all fields(properties)
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="middleName">Middle name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="ssn">Social security number </param>
        /// <param name="permanentAddress">Permanent address</param>
        /// <param name="mobilePhone">Mobile phone number</param>
        /// <param name="email">e-mail</param>
        /// <param name="course">Course</param>
        /// <param name="specialty">Specialty</param>
        /// <param name="university">University</param>
        /// <param name="faculty">Faculty</param>
        public Student(string firstName, string middleName, string lastName, long ssn, string permanentAddress,
            long mobilePhone, string email, int course,
            UniversitySpecialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.University = university;
            this.Specialty = specialty;
            this.Faculty = faculty;
        }

        /// <summary>
        /// Get and set First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Get and set Middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Get and set Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Get and set Social security number
        /// </summary>
        public long SSN
        {
            get { return this.ssn; }
            private set
            {
                // If value is negative, exception is thrown
                if (value < 0)
                {
                    throw new ArgumentException("SSN can't be negative number!");
                }

                this.ssn = value;
            }
        }

        /// <summary>
        /// Get and set Permanent address
        /// </summary>
        public string PermanentAddress { get; private set; }

        /// <summary>
        /// Get and set Mobile phone number
        /// </summary>
        public long MobilePhone { get; private set; }

        /// <summary>
        /// Get and set e-mail
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Get and set Course
        /// </summary>
        public int Course
        {
            get { return this.course; }
            private set
            {
                // If value is negative, exception is thrown
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Course can't be less than 1 and greater than 5!");
                }

                this.course = value;
            }
        }

        /// <summary>
        /// Get and set niversity Specialty. Enumeration is used
        /// </summary>
        public UniversitySpecialty Specialty { get; private set; }

        /// <summary>
        /// Get and set University. Enumeration is used
        /// </summary>
        public University University { get; private set; }

        /// <summary>
        /// Get and set Faculty. Enumeration is used
        /// </summary>
        public Faculty Faculty { get; private set; }

        /// <summary>
        /// Check if students have the same first name, last name, course, university, specialty, faculty
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>true, if students parameters are equal</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Student student = obj as Student;

            return (Object.Equals(this.FirstName, student.FirstName) &&
                    Object.Equals(this.LastName, student.LastName) &&
                    Object.Equals(this.Course, student.Course) &&
                    Object.Equals(this.University, student.University) &&
                    Object.Equals(this.Specialty, student.Specialty) &&
                    Object.Equals(this.Faculty, student.Faculty));
        }

        /// <summary>
        /// Check if students have the same first name, last name, course, university, specialty, faculty
        /// </summary>
        /// <param name="student1">First student to compare</param>
        /// <param name="student2">Second student to compare</param>
        /// <returns>true, if students parameters are equal</returns>
        public static bool operator ==(Student student1, Student student2)
        {
            // First way - easier
            return Student.Equals(student1, student2);

            // Second way
            //return (Object.Equals(student1.FirstName, student2.FirstName) &&
            //        Object.Equals(student1.LastName, student2.LastName) &&
            //        Object.Equals(student1.Course, student2.Course) &&
            //        Object.Equals(student1.University, student2.University) &&
            //        Object.Equals(student1.Specialty, student2.Specialty) &&
            //        Object.Equals(student1.Faculty, student2.Faculty));
        }

        /// <summary>
        /// Check if some of students parameters first name, last name, course, university, specialty, faculty are different
        /// </summary>
        /// <param name="student1">First student to compare</param>
        /// <param name="student2">Second student to compare</param>
        /// <returns>true, if students parameters are not equal</returns>
        public static bool operator !=(Student student1, Student student2)
        {
            // First way - easier
            return Student.Equals(student1, student2);

            // Second way
            //return (!Object.Equals(student1.FirstName, student2.FirstName) ||
            //        !Object.Equals(student1.LastName, student2.LastName) ||
            //        !Object.Equals(student1.Course, student2.Course) ||
            //        !Object.Equals(student1.University, student2.University) ||
            //        !Object.Equals(student1.Specialty, student2.Specialty) ||
            //        !Object.Equals(student1.Faculty, student2.Faculty));
        }

        /// <summary>
        /// Get string with student first name, last name, course, university, specialty, faculty
        /// </summary>
        /// <returns>String with student information</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}, {2}, {3}, {4}, {5}", this.FirstName, this.LastName, this.University, this.Faculty, this.Specialty, this.Course);
        }

        /// <summary>
        /// Get hash code as XOR operation on student mobile phone number and social security number
        /// </summary>
        /// <returns>Student Hash code</returns>
        public override int GetHashCode()
        {
            return this.MobilePhone.GetHashCode() ^ this.SSN.GetHashCode();
        }

        /// <summary>
        /// Implicit interface implementation
        /// </summary>
        /// <returns>Clone of the object</returns>
        object ICloneable.Clone()
        {
            // Allow us to use our correct method
            return this.Clone();
        }

        /// <summary>
        /// Make deep clone of "Student"
        /// </summary>
        /// <returns>Deep clone of Student</returns>
        public Student Clone()
        {
            // Cope the original values, directly in the constructor of the new instance of type "Student"
            Student clone = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddress,
            this.MobilePhone, this.Email, this.Course,
            this.Specialty, this.University, this.Faculty);

            return clone;
        }

        /// <summary>
        /// Overriden method, to compare students by names and by social security number
        /// </summary>
        /// <param name="otherStudent">Student to compare</param>
        /// <returns>
        /// Negative if first student is "greater" than other student
        /// Positive if other student is "greater" than first student
        /// Zero(0) if students are equal
        /// </returns>
        public int CompareTo(Student otherStudent)
        {
            // First compare student by first name, if they are equal,
            // then compare middle and last names. If they are equal too,
            // finally compare the social security number
            if (this.FirstName != otherStudent.FirstName)
            {
                return this.FirstName.CompareTo(otherStudent.FirstName);
            }
            else if (this.MiddleName != otherStudent.MiddleName)
            {
                return this.MiddleName.CompareTo(otherStudent.MiddleName);
            }
            else if (this.LastName != otherStudent.LastName)
            {
                return this.LastName.CompareTo(otherStudent.LastName);
            }
            else
            {
                return this.SSN.CompareTo(otherStudent.SSN);
            }
        }
    }
}
