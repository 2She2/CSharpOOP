namespace _01.SchoolExercise
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represent a teacher from school. Inherits abstract class "People" and interface "IComment"
    /// </summary>
    public class Teacher : People, IComment
    {
        // Needed properties
        public string Comment { get; set; }
        private List<Discipline> disciplines;

        /// <summary>
        /// Only constructor. Initialize all variables(properties)
        /// </summary>
        /// <param name="name">Name of the teacher</param>
        /// <param name="disciplines">Discipline of the teacher</param>
        public Teacher(string name, List<Discipline> disciplines)
            : base(name) // initialized by the parent class(People)
        {
            this.disciplines = disciplines;
        }

        /// <summary>
        /// Add discipline for the teacher
        /// </summary>
        /// <param name="discipline">Discipline to add</param>
        public void AddDiscipline(Discipline discipline)
        {
            // If it is null, we can't add discipline, so we initialize it
            if (this.disciplines == null)
            {
                this.disciplines = new List<Discipline>();
            }

            this.disciplines.Add(discipline);
        }

        /// <summary>
        /// Remove discipline for the teacher
        /// </summary>
        /// <param name="discipline">Discipline to remove</param>
        public void RemoveDiscipline(Discipline discipline)
        {
            // If disciplines list is not initialized(null) or the count of the disciplines is 0, an exception is thrown
            if (this.disciplines == null)
            {
                throw new ArgumentNullException("There is no instance of Disciplines. Can't remove from a null!");
            }

            if (this.disciplines.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Disciplines count is 0. Can't remove from discipline!");
            }

            this.disciplines.Remove(discipline);
        }

        /// <summary>
        /// Remove all disciplines for the teacher
        /// </summary>
        public void RemoveAllDisciplines()
        {
            this.disciplines.Clear();
        }

        /// <summary>
        /// Get all discipline of teacher
        /// </summary>
        /// <returns>Array of "Discipline"</returns>
        public Discipline[] GetDisciplines()
        {
            return this.disciplines.ToArray();
        }
    }
}
