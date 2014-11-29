// 03. Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

namespace GSMTest
{
    using System;

    /// <summary>
    /// Enumeration be requirement
    /// </summary>
    public enum BatteryType
    {
        LiIon, NiMH, NiCd, LiPro
    }

    public class Battery
    {
        // Variables are made nullable be requirement
        private string model;
        private ushort? idleHours;
        private ushort? talkHours;
        private BatteryType? batteryType;

        /// <summary>
        /// Default constructor - constructor with no parameters
        /// </summary>
        public Battery()
            : this(null, null, null, null)
        {
        }

        public Battery(string model)
            : this(model, null, null, null)
        {
        }


        public Battery(ushort? idleHours)
            : this(null, idleHours, null, null)
        {
        }

        public Battery(ushort? idleHours, ushort? talkHours)
            : this(null, idleHours, talkHours, null)
        {
        }

        /// <summary>
        /// Full constructor. Set values to all fields
        /// </summary>
        /// <param name="model">Battery model</param>
        /// <param name="idleHours">Battery idle hours</param>
        /// <param name="talkHours">Battery talk hours</param>
        /// <param name="batteryType">Battery type</param>
        public Battery(string model, ushort? idleHours, ushort? talkHours, BatteryType? batteryType)
        {
            this.Model = model;
            this.IdleHours = idleHours;
            this.TalkHours = talkHours;
            this.BatteryType = batteryType;
        }

        /// <summary>
        /// Get and set model of the battery
        /// </summary>
        public string Model
        {
            get { return this.model; }
            set
            {
                // Battery model length can't be less than 3 chars, otherwise an exeption is thrown
                if (value != null && value.Length < 3)
                {
                    throw new ArgumentException("Battery model can't be less than 3 symbols!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        /// <summary>
        /// Get and set idle hourse
        /// </summary>
        public ushort? IdleHours
        {
            get { return this.idleHours; }
            set { this.idleHours = value; }
        }

        /// <summary>
        /// Get and set talk hourse
        /// </summary>
        public ushort? TalkHours
        {
            get { return this.talkHours; }
            set { this.talkHours = value; }
        }

        /// <summary>
        /// Get and set battery type
        /// </summary>
        public BatteryType? BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        /// <summary>
        /// Overriden to get the battery model, idle hourse, talk hourse and battery type
        /// </summary>
        /// <returns>Return the gsm model and manufacturer</returns>
        public override string ToString()
        {
            return string.Format("Model: {0}\nIdle hours: {1}, Talk hours: {2}\nBattery type: {3}",
                this.Model ?? "unknown", this.IdleHours, this.TalkHours, this.BatteryType);
        }
    }
}
