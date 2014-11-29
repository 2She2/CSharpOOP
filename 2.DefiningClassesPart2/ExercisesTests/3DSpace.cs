// 03. Write a static class with a static method to calculate the distance between two points in the 3D space.

namespace Exercises
{
    using System;

    /// <summary>
    /// Static class to calculate the distance between two points in 3D space
    /// </summary>
    public static class _3DSpace
    {
        /// <summary>
        /// Calculate the distance between two points in 3D space
        /// </summary>
        /// <param name="point1">First point</param>
        /// <param name="point2">Second point</param>
        /// <returns>The distance between the points</returns>
        public static double CalcDistanceBetweenTwoPoints(Point3D point1, Point3D point2)
        {

            double distance = (point1.X - point2.X) * (point1.X - point2.X) +
                              (point1.Y - point2.Y) * (point1.Y - point2.Y) +
                              (point1.Z - point2.Z) * (point1.Z - point2.Z);
            distance = Math.Sqrt(distance);

            return distance;
        }
    }
}
