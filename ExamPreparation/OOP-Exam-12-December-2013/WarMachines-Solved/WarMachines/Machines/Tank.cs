namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    class Tank : Machine, WarMachines.Interfaces.ITank
    {
        private const int InitialHealthPoints = 100;
        private const int ToggleDefensePointsValue = 30;
        private const int ToggleAttackPointsValue = 40;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, InitialHealthPoints, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                this.DefenseMode = false;
            }
            else
            {
                this.DefenseMode = true;
            }

           this.ToggleHealthAndDefensePoints();
        }

        private void ToggleHealthAndDefensePoints()
        {
            if (this.DefenseMode)
            {
                this.DefensePoints += ToggleAttackPointsValue;
                this.AttackPoints -= ToggleAttackPointsValue;
            }
            else
            {
                this.DefensePoints -= ToggleDefensePointsValue;
                this.AttackPoints += ToggleAttackPointsValue;
            }
        }

        public override string ToString()
        {
            StringBuilder tankInfo = new StringBuilder();

            tankInfo.AppendFormat("- {0}\n", this.Name);
            tankInfo.Append(" *Type: Tank\n");

            tankInfo.Append(base.ToString());

            tankInfo.AppendFormat(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF");

            return tankInfo.ToString();
        }
    }
}
