// 01. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
//     Implement the ToString() to enable printing a 3D point.

namespace Exercises
{
    using System;
    using System.Collections.Generic;

    class ExercisesTests
    {
        static void Main()
        {
            // Display the coordinates of the start of the coordinate system, with overriden method "ToString()"
            // No need to explicitly call method "ToString()"
            Console.WriteLine("Center of the coordinate system(static Point0): {0}", Point3D.PointO);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Instance of the class "Point3D" with parameterless constructor
            Point3D p1 = new Point3D();
            // Instances of the class "Point3D" with constructor with parameters
            Point3D p2 = new Point3D(2, 2, 2);
            Point3D p3 = new Point3D(3, 3, 3);
            Point3D p4 = new Point3D(4, 4, 4);
            Point3D p5 = new Point3D(5, 5, 5);
            Point3D p6 = new Point3D(6, 6, 6);
            Point3D p7 = new Point3D(7, 7, 7);

            // Set values to the coordinate, using properties
            p1.X = 1;
            p1.Y = 1;
            p1.Z = 1;

            // Display points with overriden method "ToString()"
            Console.WriteLine("p1 coordinates: {0}", p1);
            Console.WriteLine("p2 coordinates: {0}", p2);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Calculate the distance between two points
            // Using static class "_3DSpace" and static method "CalcDistanceBetweenTwoPoints"
            double distance = _3DSpace.CalcDistanceBetweenTwoPoints(Point3D.PointO, p1);
            Console.WriteLine("Distance between center of the coordinate system and point {0}\n: {1}", p1.ToString(), distance);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Create instance of the class "Path" and add points with method "AddPoint"
            Path path1 = new Path();
            path1.AddPoint(p1);
            path1.AddPoint(p2);
            path1.AddPoint(p3);
            path1.AddPoint(p4);
            path1.AddPoint(p5);
            path1.AddPoint(p6);
            path1.AddPoint(p7);

            // Save points in "path1", using static class "PathStorage" and static method "SavePathToFile"
            PathStorage.SavePathToFile(path1, @"..\..\paths.txt");

            Path path2 = new Path();
            // Read points from file and add the to "path2"
            path2 = PathStorage.ReadPathFromFile(@"..\..\paths.txt");

            // Print the point in "path2" to check if method works properly
            Console.WriteLine("Points in \"path2\", read from a file.");
            for (int i = 0; i < path2.Count; i++)
            {
                Console.WriteLine(path2[i]);
            }

            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Create instance of the class "GenericList<T>" and add points with method "Add"
            GenericList<Point3D> pointList = new GenericList<Point3D>(10); // Set capacity to 10
            pointList.Add(p1);
            pointList.Add(p2);
            pointList.Add(p3);
            pointList.Add(p4);
            pointList.Add(p5);
            pointList.Add(p6);
            pointList.Add(p7);

            Console.WriteLine("pointList capacity: {0}", pointList.Capacity);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Display all elements in the list, with overriden method "ToString()"
            Console.WriteLine("Elements in the list:\n{0}", pointList);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Remove element at index 1 and display the elements in the list
            pointList.RemoveAt(1);
            Console.WriteLine("Elements after element at index 1 is removed:\n{0}", pointList);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Remove element at index 0 and display the elements in the list
            pointList.RemoveAt(0);
            Console.WriteLine("Elements after element at index 0 is removed:\n{0}", pointList);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Insert element at index 2 and prin the elements in the list
            pointList.Insert(2, p2);
            Console.WriteLine("Elements after element at index 2 is inserted:\n{0}", pointList);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Try to find if element "p5" exist in the list. If so the index of the found element is displayed
            Console.WriteLine("Index of element \"p5\": {0}", pointList.Find(p5));
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Clear all elements in the list. Clear means to set elements to their default values
            pointList.Clear();

            // Try to find if element "p5" exist in the list. If element is not found, -1 is returned
            Console.WriteLine("Index of element \"p5\": {0}", pointList.Find(p5));
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Create instance of the generic list with auto-grow functionality
            GenericListWithAutoGrow<Point3D> listWithAutoGrow = new GenericListWithAutoGrow<Point3D>(2);

            // Add two points, check the capacity and print the list
            listWithAutoGrow.Add(p1);
            listWithAutoGrow.Add(p2);
            Console.WriteLine("Capacity: {0}", listWithAutoGrow.Capacity);
            Console.WriteLine(listWithAutoGrow);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Add one point, check the capacity and print the list
            listWithAutoGrow.Add(p3);
            Console.WriteLine("Capacity: {0}", listWithAutoGrow.Capacity);
            Console.WriteLine(listWithAutoGrow);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Add two points, check the capacity and print the list
            listWithAutoGrow.Add(p4);
            listWithAutoGrow.Add(p5);
            Console.WriteLine("Capacity: {0}", listWithAutoGrow.Capacity);
            Console.WriteLine(listWithAutoGrow);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            listWithAutoGrow.Add(p6);
            listWithAutoGrow.Add(p7);
            listWithAutoGrow.Add(p4);

            // Print maximal and minimai elements indeces
            Console.WriteLine("Maximal element index: {0}", listWithAutoGrow.Max<Point3D>());
            Console.WriteLine("Minimal element index: {0}", listWithAutoGrow.Min<Point3D>());
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Set matrices with size 2, 2
            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            Matrix<int> matrix2 = new Matrix<int>(2, 2);
            Matrix<int> sum = new Matrix<int>(2, 2);
            Matrix<int> subtraction = new Matrix<int>(2, 2);
            Matrix<int> product = new Matrix<int>(2, 2);

            int currentElementValue = 1;

            // Assign values to matrices 1 and 2. Values are from 1 to 4
            for (int row = 0; row < matrix1.GetRows; row++)
            {
                for (int col = 0; col < matrix1.GetCols; col++)
                {
                    matrix1[row, col] = currentElementValue;
                    matrix2[row, col] = currentElementValue;
                    // On each iteration increment the value assigned to the matrices
                    currentElementValue++;
                }
            }

            // Print the values of matrices 1 and 2
            Console.WriteLine("Matrix 1 and 2 values:\n{0}", matrix1);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Sum two matrices and print them
            sum = matrix1 + matrix2;
            Console.WriteLine("Sum of matrices:\n{0}", sum);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Subtract two matrices and print them
            subtraction = matrix1 - matrix2;
            Console.WriteLine("Subtraction of matrices:\n{0}", subtraction);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Multiply two matrices and print them
            product = matrix1 * matrix2;
            Console.WriteLine("Product of matrices:\n{0}", product);
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Check if matrix have non-zero elements
            if (subtraction)
            {
                Console.WriteLine("Matrix have non-zero elements.");
            }
            else
            {
                Console.WriteLine("Matrix doesn't have non-zero elements.");
            }
        }
    }
}
