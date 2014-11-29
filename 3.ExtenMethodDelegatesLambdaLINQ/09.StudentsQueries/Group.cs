// 16. * Create a class Group with properties GroupNumber and DepartmentName.
//     Introduce a property Group in the Student class. Extract all students from "Mathematics" department.
//     Use the Join operator.

namespace _09.StudentsQueries
{
    using System;

    public class Group
    {
        // Needed properties
        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }

        // Only constructor of the class. initialize the needed properties
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }
    }
}
