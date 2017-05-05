using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Tires
{
    public class YokohamaAdvanTiresSet : TiresSet, ITunningPart, ITireSet, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        private const int YokohamaAdvanTireSetWeightInGrams = 6600;
        private const int YokohamaAdvanTireSetAccelerationBonus = 5;
        private const int YokohamaAdvanTireSetTopSpeedBonus = 1;
        private const decimal YokohamaAdvanTireSetPrice = 589;

        public YokohamaAdvanTiresSet() 
            : base(YokohamaAdvanTireSetPrice, YokohamaAdvanTireSetWeightInGrams, YokohamaAdvanTireSetAccelerationBonus, YokohamaAdvanTireSetTopSpeedBonus, TunningGradeType.MidGrade, TireType.AllTerrainTire)
        {
        }
    }
}
