namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class AbstractMachine : IMachine
    {
        private string name;
        private double healthPoints;
        private double attackPoints;
        private double defencePoints;
        private IPilot pilot;

        public AbstractMachine(string name, double healthPoints, double attackPoints, double defencePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defencePoints;
            this.Targets = new List<string>();
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            set
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

        public virtual IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Pilot cannot be null");
                }
                else
                {
                    this.pilot = value;
                }
            }
        }

        public virtual double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Health cannot be zero or less");
                }
                else
                {
                    this.healthPoints = value;
                }
            }
        }

        public virtual double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Attack cannot be zero or less");
                }
                else
                {
                    this.attackPoints = value;
                }
            }
        }

        public virtual double DefensePoints
        {
            get
            {
                return this.defencePoints;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Defence cannot be zero or less");
                }
                else
                {
                    this.defencePoints = value;
                }
            }
        }

        public virtual IList<string> Targets { get; }

        public virtual void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));

            if (this.Targets.Count < 1)
            {
                result.Append(" *Targets: None");
            }
            else
            {
                result.Append(" *Targets: ");

                for (int i = 0; i < this.Targets.Count; i++)
                {
                    if (i != this.Targets.Count - 1)
                    {
                        result.Append(string.Format("{0}, ", this.Targets[i]));
                    }
                    else
                    {
                        result.Append(string.Format("{0}", this.Targets[i]));
                    }
                }
            }
            
            return result.ToString();
        }
    }
}
