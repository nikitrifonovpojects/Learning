namespace Infestation
{
    public class Tank : Unit
    {
        public const int BaseHealth = 20;
        public const int BasePower = 25;
        public const int BaseAggerssion = 25;

        public Tank(string id) 
            : base(id, UnitClassification.Mechanical, Tank.BaseHealth, Tank.BasePower, Tank.BaseAggerssion)
        {
        }
    }
}
