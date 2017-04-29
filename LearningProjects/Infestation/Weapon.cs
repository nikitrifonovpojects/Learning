using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Weapon : AbstractSupplement
    {
        private const int Power = 10;
        private const int Aggerssion = 3;
        protected bool foundInteraction = false;

        public override int AggressionEffect
        {
            get
            {
                if (this.foundInteraction)
                {
                    return Weapon.Aggerssion;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override int PowerEffect
        {
            get
            {
                if (this.foundInteraction)
                {
                    return Weapon.Power;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.foundInteraction = true;
            }
        }
    }
}
