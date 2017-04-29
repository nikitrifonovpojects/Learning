namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> pilotMachines;

        public Pilot(string name)
        {
            this.Name = name;
            this.pilotMachines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.pilotMachines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();
            result.Append(string.Format("{0} - {1} {2}", this.Name,
                this.pilotMachines.Count != 0 ? this.pilotMachines.Count.ToString() : "no",
                this.pilotMachines.Count != 1 ? "machines" : "machine"));

            if (this.pilotMachines.Count > 0)
            {
                result.Append(Environment.NewLine);
            }

            for (int i = 0; i < this.pilotMachines.Count; i++)
            {
                if (i != this.pilotMachines.Count - 1)
                {
                    result.AppendLine(this.pilotMachines[i].ToString());
                }
                else
                {
                    result.Append(this.pilotMachines[i]);
                }
            }

            return result.ToString();
        }
    }
}
