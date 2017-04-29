namespace Infestation
{
    public class AggressionCatalyst : AbstractSupplement
    {
        private const int Aggression = 3;

        public override int AggressionEffect
        {
            get
            {
                return AggressionCatalyst.Aggression;
            }
        }
    }
}
