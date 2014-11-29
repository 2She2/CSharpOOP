namespace _01.ShapesExercise
{
    using System;

    /// <summary>
    /// Represent a rectangle. Inherit abstract class "Shape"
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Only constructor of the class. Initialize all fields
        /// </summary>
        /// <param name="width">Width of rectangle</param>
        /// <param name="height">Height of rectangle</param>
        public Rectangle(double width, double height)
            : base(width, height) // call base constructor
        {
        }

        /// <summary>
        /// Calculate surface of rectangle. Overriden from abstract class "Shape"
        /// </summary>
        /// <returns>Surface of rectangle</returns>
        public override double CalculateSurface()
        {
            return base.Width * base.Height;
        }
    }
}
