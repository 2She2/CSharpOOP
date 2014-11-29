/* 01. We are given a school. In the school there are classes of students. Each class has a set of teachers.
 * Each teacher teaches a set of disciplines. Students have name and unique class number.
 * Classes have unique text identifier. Teachers have name.
 * Disciplines have name, number of lectures and number of exercises. Both teachers and students are people.
 * Students, classes, teachers and disciplines could have optional comments (free text block).
 *
 * Your task is to identify the classes (in terms of  OOP) and their attributes and operations,
 * encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
*/
namespace _01.SchoolExercise
{
    using System;
    using System.Collections.Generic;

    public class SchoolExercise
    {
        static void Main()
        {
            Student Pesho = new Student("Pesho", 23910);
            Student Gosho = new Student("Gosho", 31637);
            Student Sasho = new Student("Sasho", 25903);
            Student Misho = new Student("Misho", 29470);
            Student Tosho = new Student("Tosho", 27991);
            Student Mitko = new Student("Mitko", 30419);
            Student Ivo = new Student("Ivo", 26637);
            Student Emo = new Student("Emo", 27797);

            Discipline mathematics = new Discipline("Mathematics", 50, 60);
            Discipline biology = new Discipline("Biology", 40, 45);
            Discipline geography = new Discipline("Geography", 40, 50);
            Discipline history = new Discipline("History", 45, 45);
            Discipline chemistry = new Discipline("Chemistry", 35, 40);
            Discipline karate = new Discipline("Karate", 10, 75);
            Discipline taekwondo = new Discipline("Taekwondo", 15, 85);

            Teacher mimiTheTeacher = new Teacher("Mimi the teacher", new List<Discipline> { mathematics, geography, history });
            Teacher penkaTheTeacher = new Teacher("Penka the teacher", new List<Discipline> { biology, chemistry });
            Teacher senseiTheMaster = new Teacher("Sensei the master", new List<Discipline> { karate, taekwondo });

            Class retardedClass = new Class("Special students",
                new List<Teacher> { mimiTheTeacher, penkaTheTeacher },
                new List<Student> { Pesho, Sasho, Mitko, Ivo, Emo });

            Class sportsClass = new Class("Sports class",
                new List<Teacher> { senseiTheMaster },
                new List<Student> { Gosho, Misho, Tosho });

            
        }
    }
}
