namespace GSMTest
{
    using System;

    public class Display
    {
        // Using '?' to make the variable nullable, by request
        private ushort? height;
        private ushort? width;
        private uint? colorsCount;

        /// <summary>
        /// Default constructor - constructor with no parameters
        /// </summary>
        public Display()
            : this(null, null, null)
        {
        }

        public Display(uint? colorsCount)
            : this(colorsCount, null, null)
        {
        }

        public Display(ushort? height, ushort? width)
            : this(null, height, width)
        {
        }

        /// <summary>
        /// Full constructor. Set values to all fields
        /// </summary>
        /// <param name="colorsCount">Current display colors count</param>
        /// <param name="height">Current display height in pixels</param>
        /// <param name="width">Current display width in pixels</param>
        public Display(uint? colorsCount, ushort? height, ushort? width)
        {
            this.ColorsCount = colorsCount;
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// Get and set Height of the display. Height is in pixels.
        /// </summary>
        public ushort? Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Get and set Width of the display. Width is in pixels.
        /// </summary>
        public ushort? Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Get size of the display. Size is in pixels.
        /// </summary>
        public string Size
        {
            get { return string.Format("{0}x{1}", this.Height, this.Width); }
        }

        /// <summary>
        /// Get and set count of colors of the display.
        /// </summary>
        public uint? ColorsCount
        {
            get { return this.colorsCount; }
            set { this.colorsCount = value; }
        }
    }
}
