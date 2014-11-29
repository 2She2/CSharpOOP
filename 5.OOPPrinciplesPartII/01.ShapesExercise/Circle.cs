namespace _01.ShapesExercise
{
    using System;

    /// <summary>
    /// Represent a circle. Inherit abstract class "Shape"
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Only constructor of the class. Initialize all fields
        /// </summary>
        /// <param name="radius">Radius of the circle</param>
        public Circle(double radius)
            : base(radius, radius) // call base constructor
        {
        }

        /// <summary>
        /// Calculate surface of circle. Overriden from abstract class "Shape"
        /// </summary>
        /// <returns>Surface of circle</returns>
        public override double CalculateSurface()
        {
            return base.Height * base.Width * Math.PI;
        }
    }
}
