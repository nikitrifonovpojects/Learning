namespace Infestation
{
    public class HealthCatalyst : AbstractSupplement
    {
        private const int Health = 3;

        public override int HealthEffect
        {
            get
            {
                return HealthCatalyst.Health;
            }
        }
    }
}
