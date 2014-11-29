namespace _01.SchoolExercise
{
    using System;

    /// <summary>
    /// Represent a discipline in school. Implement interface "IComment"
    /// </summary>
    public class Discipline : IComment
    {
        // Needed properties
        public string Name { get; private set; } // Discipline name can't be chaged
        public int LecturesNumber { get; set; }
        public int ExercisesNumber { get; set; }
        public string Comment { get; set; }

        /// <summary>
        /// Only constructor. Initialize all variables(properties)
        /// </summary>
        /// <param name="name">Discipline name</param>
        /// <param name="lecturesNumber">Lectures count</param>
        /// <param name="exercisesNumber">Exercises count</param>
        public Discipline(string name, int lecturesNumber, int exercisesNumber)
        {
            this.Name = name;
            this.LecturesNumber = lecturesNumber;
            this.ExercisesNumber = exercisesNumber;
        }
    }
}
