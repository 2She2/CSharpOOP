namespace _01.ShapesExercise
{
    using System;

    /// <summary>
    /// Abstract class, represent a shape
    /// </summary>
    public abstract class Shape
    {
        // Needed fields
        private double width;
        private double height;

        /// <summary>
        /// Only constructor of the class. Initialize all fields
        /// </summary>
        /// <param name="width">Width of the shape</param>
        /// <param name="height">Height of the shape</param>
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Calculate surface. Abstract method to be implemented by the inherits
        /// </summary>
        /// <returns>Surface of the shape</returns>
        public abstract double CalculateSurface();

        /// <summary>
        /// Get and set width of the shape
        /// </summary>
        public double Width
        {
            get { return this.width; }
            set
            {
                // If value is equal or less than 0, exception is thrown
                if (value <= 0)
                {
                    throw new ArgumentException("Width can't be equal or less than 0!");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Get and set height of the shape
        /// </summary>
        public double Height
        {
            get { return this.height; }
            set
            {
                // If value is equal or less than 0, exception is thrown
                if (value <= 0)
                {
                    throw new ArgumentException("Height can't be equal or less than 0!");
                }

                this.height = value;
            }
        }
    }
}
