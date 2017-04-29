namespace Infestation
{
    public class AbstractSupplement : ISupplement
    {
        public AbstractSupplement()
        {
        }

        public AbstractSupplement(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public virtual int PowerEffect { get; protected set; }

        public virtual int HealthEffect { get; protected set; }

        public virtual int AggressionEffect { get; protected set; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {

        }
    }
}
