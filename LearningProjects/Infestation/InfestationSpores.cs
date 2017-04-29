using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : AbstractSupplement
    {
        private const int Aggression = 20;
        private const int Power = -1;
        private bool foundDuplicate = false;

        public override int AggressionEffect
        {
            get
            {
                if (this.foundDuplicate)
                {
                    return 0;
                }
                else
                {
                    return InfestationSpores.Aggression;
                }
            }
        }

        public override int PowerEffect
        {
            get
            {
                if (this.foundDuplicate)
                {
                    return 0;
                }
                else
                {
                    return InfestationSpores.Power;
                }
            }
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == this.GetType().Name)
            {
                this.foundDuplicate = true;
            }
        }
    }
}
