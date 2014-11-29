// 04. Create a class Path to hold a sequence of points in the 3D space...

namespace Exercises
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class to hold a sequence of points in the 3D space
    /// </summary>
    public class Path
    {
        // List where point will be hold in
        private List<Point3D> points;
        // Track the count of the input points
        private int count = 0;

        /// <summary>
        /// Parameterless constructor. Initialize the List where point are hold in
        /// </summary>
        public Path()
        {
            points = new List<Point3D>();
        }

        /// <summary>
        /// Get array of points
        /// </summary>
        public Point3D[] Points
        {
            get
            {
                Point3D[] returnedArray = new Point3D[points.Count];
                this.points.CopyTo(returnedArray);
                return returnedArray;
            }
        }

        /// <summary>
        /// Add point in the List
        /// </summary>
        /// <param name="point">Point to add</param>
        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
            count++;
        }

        /// <summary>
        /// Get count of points
        /// </summary>
        public int Count
        {
            get { return this.count; }
        }

        /// <summary>
        /// Indexer to access the points in the array
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Point3D this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index!");
                }

                return points[index];
            }
        }
    }
}
