namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public abstract class Machine : WarMachines.Interfaces.IMachine
    {
        private IList<string> targets;
        private string name;
        private IPilot pilot;

        public Machine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Machine name can't be null!");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot can't be null!");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            // If don't return the original List(it's reference), program don't work
            get { return this.targets; }
        }

        public void Attack(string target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("Target to add can't be null!");
            }

            this.targets.Add(target);
        }

        public override string ToString()
        {
            // Here we can use this.GetType().Name, but I think that this is not a good idea,
            // because this will give us the name of the class.
            // In our program this is ok, but what if the name of the class is not exactlythe name we want?
            // I don't think this is a good practise!

            StringBuilder machineInfo = new StringBuilder();

            machineInfo.AppendFormat(" *Health: {0}\n", this.HealthPoints);
            machineInfo.AppendFormat(" *Attack: {0}\n", this.AttackPoints);
            machineInfo.AppendFormat(" *Defense: {0}\n", this.DefensePoints);
            machineInfo.Append(" *Targets: ");

            if (this.Targets.Count == 0)
            {
                machineInfo.Append("None\n");
            }
            else
            {
                machineInfo.Append(string.Join(", ", this.Targets));
                machineInfo.AppendLine();
            }

            return machineInfo.ToString();
        }
    }
}
