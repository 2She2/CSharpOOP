using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        private List<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.Courses = new List<ICourse>();
        }

        public List<ICourse> Courses
        {
            get { return new List<ICourse>(this.courses); }
            private set { this.courses = value; }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendFormat("Teacher: Name={0}", this.Name);

            if (this.Courses.Count > 0)
            {
                str.Append("; Courses=[");
                str.Append(string.Join(", ", this.Courses.Select(x => x.Name)));
                str.Append("]");
            }

            return str.ToString();
        }
    }
}
