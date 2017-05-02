namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using ArmyOfCreatures.Logic.Battles;

    public class DoubleDamage : AbstractSpeciality
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds < 1 || rounds > 10)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be between 1 and 10, inclusive");
            }

            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                return currentDamage;
            }

            this.rounds--;
            return currentDamage *= 2;
        }

        protected override string GetFormatValue()
        {
            return this.rounds.ToString();
        }
    }
}
