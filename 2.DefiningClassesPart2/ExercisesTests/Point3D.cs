// 01. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
//     Implement the ToString() to enable printing a 3D point.

// 02. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
//     Add a static property to return the point O.

namespace Exercises
{
    using System;

    // Implement interface "IComparable<Point3D>", so we can compare two points
    public struct Point3D : IComparable<Point3D>
    {
        private static readonly Point3D pointO;

        /// <summary>
        /// Parameterless constructor. Set initial coordinates to 0. It is not necessary, but it is more readable.
        /// </summary>
        static Point3D()
        {
            pointO.X = 0;
            pointO.Y = 0;
            pointO.Z = 0;
        }

        /// <summary>
        /// Constructor to set initial coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Point3D(int x, int y, int z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Get and set coordinates
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        /// <summary>
        /// Get coordinates of the start of the coordinate system
        /// </summary>
        public static Point3D PointO
        {
            get { return pointO; }
        }

        /// <summary>
        /// Set the coordinates of the point to a string
        /// </summary>
        /// <returns>String with all coordinates</returns>
        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }

        /// <summary>
        /// Compare two points by their distance from the start of the coordinate system
        /// </summary>
        /// <param name="point">Point to compare to</param>
        /// <returns>
        /// 1, if current point is more far away from the start of the coordinate system
        /// -1 if current point is closer to the start of the coordinate system
        /// 0 if points have equal distance from the start of the coordinate system
        /// </returns>
        public int CompareTo(Point3D point)
        {

            double dist1 = _3DSpace.CalcDistanceBetweenTwoPoints(new Point3D(0, 0, 0), this);
            double dist2 = _3DSpace.CalcDistanceBetweenTwoPoints(new Point3D(0, 0, 0), point);

            if (dist1 > dist2)
            {
                return 1;
            }
            else if (dist1 < dist2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
