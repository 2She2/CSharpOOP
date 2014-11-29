// 04. Create a static class PathStorage with static methods to save and load paths from a text file.
//     Use a file format of your choice.

namespace Exercises
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Static class to save and load "paths" from a text file.
    /// </summary>
    public static class PathStorage
    {
        /// <summary>
        /// Save "Path" points to a file
        /// </summary>
        /// <param name="path">Sequence of points - "Path"</param>
        /// <param name="fileDestination">Destination of the file</param>
        public static void SavePathToFile(Path path, string fileDestination)
        {
            StreamWriter writer = new StreamWriter(fileDestination, false);

            StringBuilder coordinates = new StringBuilder();

            // Iterate through the array and put each point coordinates in StringBuilder.
            for (int i = 0; i < path.Points.Length; i++)
            {
                coordinates.AppendFormat("{0} {1} {2}", path.Points[i].X, path.Points[i].Y, path.Points[i].Z);

                // Set new line for each point
                if (i < path.Points.Length - 1)
                {
                    coordinates.AppendLine();
                }
            }

            // Write all points at once for better performance.
            using (writer)
            {
                writer.Write(coordinates);
            }
        }

        /// <summary>
        /// Read points from a file and put the into a "Path"
        /// </summary>
        /// <param name="fileDestination">Destination of the file to read</param>
        /// <returns>Path with all points in the file</returns>
        public static Path ReadPathFromFile(string fileDestination)
        {
            Path path = new Path();
            StreamReader reader = new StreamReader(fileDestination);
            string line;
            string[] coordinates;

            using (reader)
            {
                // Read each line. Split it by spaces (' ') to get the separate coordinates.
                // Put each line coordinates into a "Point3D" and put that point in "Path"
                while ((line = reader.ReadLine()) != null)
                {
                    coordinates = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    // Point indeces are hardcoded, because we will always have three coordinates
                    Point3D point = new Point3D(int.Parse(coordinates[0]), int.Parse(coordinates[1]), int.Parse(coordinates[2]));
                    path.AddPoint(point);
                }
            }

            return path;
        }
    }
}
