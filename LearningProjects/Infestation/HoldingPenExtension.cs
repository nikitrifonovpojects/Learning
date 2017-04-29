namespace Infestation
{
    class HoldingPenExtension : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Weapon":
                    GetUnit(commandWords[2]).AddSupplement(new Weapon());
                    break;
                case "AggressionCatalyst":
                    GetUnit(commandWords[2]).AddSupplement(new AggressionCatalyst());
                    break;
                case "HealthCatalyst":
                    GetUnit(commandWords[2]).AddSupplement(new HealthCatalyst());
                    break;
                case "PowerCatalyst":
                    GetUnit(commandWords[2]).AddSupplement(new PowerCatalyst());
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            base.ExecuteInsertUnitCommand(commandWords);
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            base.ProcessSingleInteraction(interaction);
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    break;
            }
        }
    }
}
