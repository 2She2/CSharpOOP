namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    class Pilot : WarMachines.Interfaces.IPilot
    {
        private IList<IMachine> machines;
        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot name can't be null!");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("Machine to add can't be null!");
            }

            machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendFormat("{0} - ", this.Name);

            if (this.machines.Count == 0)
            {
                report.Append("no");
            }
            else
            {
                report.Append(this.machines.Count);
            }

            if (this.machines.Count == 1)
            {
                report.Append(" machine");
            }
            else
            {
                report.Append(" machines");
            }

            var orderedMachines = this.machines
                .OrderBy(x => x.HealthPoints)
                .ThenBy(y => y.Name);

            foreach (IMachine machine in orderedMachines)
            {
                report.AppendFormat("\n{0}", machine.ToString());
            }

            return report.ToString();
        }
    }
}
