// 11. Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and
//     methods and holds a version in the format major.minor (e.g. 2.11).
//     Apply the version attribute to a sample class and display its version at runtime.

namespace VersionExercise
{
    using System;

    // Set attribute version
    [Version(1.13)]
    class VersionTest
    {
        static void Main(string[] args)
        {
            // Get the type of the "VersionAttribute"
            Type type = typeof(Version);

            // Get all custom attributes to an array
            object[] attributes = type.GetCustomAttributes(false);

            // Print version attribute
            foreach (VersionAttribute attribute in attributes)
            {
                Console.WriteLine("version: {0}", attribute.Version);
            }
        }
    }
}
