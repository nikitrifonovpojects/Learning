using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Tires
{
    public class MichelinPilotTiresSet : TiresSet, ITunningPart, ITireSet, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        private const int MichelinPilotTireSetWeightInGrams = 6500;
        private const int MichelinPilotTireSetAccelerationBonus = 7;
        private const int MichelinPilotTireSetTopSpeedBonus = 1;
        private const decimal MichelinPilotTireSetPrice = 1399;

        public MichelinPilotTiresSet() 
            : base(MichelinPilotTireSetPrice, MichelinPilotTireSetWeightInGrams, MichelinPilotTireSetAccelerationBonus, MichelinPilotTireSetTopSpeedBonus, TunningGradeType.HighGrade, TireType.PerformanceTire)
        {
        }
    }
}
