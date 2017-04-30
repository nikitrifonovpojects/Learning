namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int WoodValue = 2;

        public Wood(string name, Location location = null) 
            : base(name, Wood.WoodValue, ItemType.Wood, location)
        {

        }

        public override void UpdateWithInteraction(string interaction)
        {
            switch (interaction)
            {
                case "drop":
                    if (this.Value > 0)
                    {
                        this.Value -= 1;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
