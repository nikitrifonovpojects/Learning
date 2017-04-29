namespace WarMachines.Machines
{
    using System.Text;
    using WarMachines.Interfaces;

    public class Fighter : AbstractMachine, IFighter
    {
        private bool stealthMode;
        private const double FighterHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, Fighter.FighterHealthPoints, attackPoints, defensePoints)
        {
            this.stealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
        }

        public void ToggleStealthMode()
        {
            this.stealthMode = !this.stealthMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString());

            if (this.stealthMode)
            {
                result.Append(" *Stealth: ON");
            }
            else
            {
                result.Append(" *Stealth: OFF");
            }

            return result.ToString();
        }
    }
}
