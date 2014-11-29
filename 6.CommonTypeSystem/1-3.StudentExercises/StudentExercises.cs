namespace _1_3.StudentExercises
{
    using System;

    class StudentExercises
    {
        static void Main()
        {
            // Make two instance of the class "Student"
            Student pesho = new Student("Pesho", "Peshov", "Peshev", 8203173804, "Sofia city", 0888334455,
                "pesho@mail.bg", 3, UniversitySpecialty.DotNetNinja, University.MIT, Faculty.EngineeringAndTechnology);

            Student gosho = null;//new Student("Gosho", "Goshov", "Goshev", 8410092185, "Sofia city", 0888667788,
                //"pesho@mail.bg", 3, UniversitySpecialty.CSharpProgrammer, University.MIT, Faculty.EngineeringAndTechnology);
            
            // Print student with overriden "ToString()". There is no need to explicitly call ".ToString()"
            Console.WriteLine(pesho);
            Console.WriteLine(gosho);

            // Check if students are equal with overriden "Equals(Object obj)"
            Console.WriteLine("Pesho equals Gosho: {0}", pesho.Equals(gosho));

            // Check if students are equal with overriden operator "=="
            Console.WriteLine("Pesho == Gosho: {0}", pesho == gosho);

            // Check if students are not equal with overriden operator "!="
            Console.WriteLine("Pesho != Gosho: {0}", pesho != gosho);

            // Get hash code with overriden "GetHashCode()"
            Console.WriteLine("Pesho's hash code: {0}", pesho.GetHashCode());

            // Clone Student "Pesho" and print its values with overriden method "ToString()". There is no need to explicitly call ".ToString()"
            Student peshoClone = pesho.Clone();
            Console.WriteLine("Pesho's clone: {0}", peshoClone);

            // Compare Pesho and Gosho with our method ComapreTo
            Console.WriteLine("Pesho compare to Gosho: {0}", pesho.CompareTo(gosho));
            // Compare Pesho with its clone
            Console.WriteLine("Pesho compare to Pesho's clone: {0}", pesho.CompareTo(peshoClone));

            // Add students into array
            Student[] students = new Student[] { pesho, gosho, peshoClone };
            // Sort the students. Array.Sort() use IComparable(CompareTo) to sort
            Array.Sort(students);

            // Print all students, to see if they are properly sorted
            Console.WriteLine("Sorted studetns:");
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i]);
            }
        }
    }
}
