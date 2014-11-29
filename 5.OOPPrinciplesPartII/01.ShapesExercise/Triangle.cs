namespace _01.ShapesExercise
{
    using System;

    /// <summary>
    /// Represent a triangle. Inherit abstract class "Shape"
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Only constructor of the class. Initialize all fields
        /// </summary>
        /// <param name="width">Width of triangle</param>
        /// <param name="height">Height of triangle</param>
        public Triangle(double width, double height)
            : base(width, height) // call base constructor
        {
        }

        /// <summary>
        /// Calculate surface of triangle. Overriden from abstract class "Shape"
        /// </summary>
        /// <returns>Surface of triangle</returns>
        public override double CalculateSurface()
        {
            return base.Width * base.Height / 2;
        }
    }
}
