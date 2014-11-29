/* 01. Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
 * Define two new classes Triangle and Rectangle that implement the virtual method
 * and return the surface of the figure (height*width for rectangle and height*width/2 for triangle).
 * Define class Circle and suitable constructor so that at initialization height must be kept equal to width
 * and implement the CalculateSurface() method.
 * Write a program that tests the behavior of the CalculateSurface() method for
 * different shapes (Circle, Rectangle, Triangle) stored in an array.
*/

namespace _01.ShapesExercise
{
    using System;

    class ShapesExercise
    {
        static void Main()
        {
            // Pu different types of shapes into array of type "Shape"
            Shape[] shapes = new Shape[]
            {
                new Rectangle(2.3, 4.6),
                new Triangle(4.2, 6.1),
                new Circle(3.9),
            };

            // Print the surface of each kind of shape. If possible, use "for loop" instead of "foreach". For loop is several times faster, as I can remember
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("{0, 10} are is: {1}", shapes[i].GetType().Name, shapes[i].CalculateSurface());
            }
        }
    }
}
