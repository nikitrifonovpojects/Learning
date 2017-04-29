namespace Infestation
{
    public class PowerCatalyst : AbstractSupplement
    {
        private const int Power = 3;

        public override int PowerEffect
        {
            get
            {
                return PowerCatalyst.Power;
            }
        }
    }
}
