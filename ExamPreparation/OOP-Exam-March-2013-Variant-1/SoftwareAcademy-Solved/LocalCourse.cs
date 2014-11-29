using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get { return this.lab; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            string toStr = "LocalCourse: " + base.ToString() + "; " + this.Lab;
            
            return toStr;
        }
    }
}
