namespace WarMachines.Machines
{
    using System.Text;
    using WarMachines.Interfaces;

    public class Tank : AbstractMachine, ITank
    {
        private const double TankHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, Tank.TankHealthPoints, attackPoints, defensePoints)
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            else
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }

            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString());

            if (this.DefenseMode)
            {
                result.Append(" *Defense: ON");
            }
            else
            {
                result.Append(" *Defense: OFF");
            }

            return result.ToString();
        }
    }
}
