namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    class Fighter : Machine, WarMachines.Interfaces.IFighter
    {
        private const int initialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, initialHealthPoints, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            if (StealthMode)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }

        public override string ToString()
        {
            StringBuilder fighterInfo = new StringBuilder();

            fighterInfo.AppendFormat("- {0}\n", this.Name);
            fighterInfo.Append(" *Type: Fighter\n");

            fighterInfo.Append(base.ToString());

            fighterInfo.AppendFormat(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF");

            return fighterInfo.ToString();
        }
    }
}
