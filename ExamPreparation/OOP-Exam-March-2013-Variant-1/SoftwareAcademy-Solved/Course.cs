using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        private string name;
        private List<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Topics = new List<string>();
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

        public ITeacher Teacher { get; set; }

        public List<string> Topics
        {
            get { return new List<string>(this.topics); }
            private set { this.topics = value; }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder toStr = new StringBuilder();

            toStr.AppendFormat("Name={0}", this.Name);

            if (this.Teacher != null)
            {
                toStr.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }

            if (this.Topics.Count > 0)
            {
                toStr.Append("; Topics=[");
                toStr.Append(string.Join(", ", Topics));
                toStr.Append("]");
            }

            return toStr.ToString();
        }
    }
}
