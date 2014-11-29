// 11. Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and
//     methods and holds a version in the format major.minor (e.g. 2.11).
//     Apply the version attribute to a sample class and display its version at runtime.

namespace VersionExercise
{
    using System;

    /// <summary>
    /// Attribute can be applied to the following
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    class VersionAttribute : System.Attribute
    {
        /// <summary>
        /// Get attribute version
        /// </summary>
        public double Version { get; private set; }

        /// <summary>
        /// Constructor to se the current version
        /// </summary>
        /// <param name="version">Current version</param>
        public VersionAttribute(double version)
        {
            this.Version = version;
        }
    }
}
