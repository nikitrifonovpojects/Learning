using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Tires
{
    public class FalkenAzenisTiresSet : TiresSet, ITunningPart, ITireSet, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        private const int FalkenAzenisTiresSetWeightInGrams = 7800;
        private const int FalkenAzenisTiresSetAccelerationBonus = 3;
        private const int FalkenAzenisTiresSetTopSpeedBonus = 0;
        private const decimal FalkenAzenisTiresSetPrice = 359;

        public FalkenAzenisTiresSet() 
            : base(FalkenAzenisTiresSetPrice, FalkenAzenisTiresSetWeightInGrams, FalkenAzenisTiresSetAccelerationBonus, FalkenAzenisTiresSetTopSpeedBonus, TunningGradeType.LowGrade, TireType.OffRoadTire)
        {
        }
    }
}
